// ----------------------------------------------------------------------------
// The MIT License
// Types for Entity Component System framework https://github.com/Leopotam/ecs
// Copyright (c) 2017-2019 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;

namespace Leopotam.Ecs.Types {
    /// <summary>
    /// Matrix 3x3.
    /// </summary>
    [Serializable]
    [StructLayout (LayoutKind.Sequential)]
    public struct Float3x3 {
        public float M11;
        public float M12;
        public float M13;
        public float M21;
        public float M22;
        public float M23;
        public float M31;
        public float M32;
        public float M33;

        /// <summary>
        /// Identity matrix.
        /// </summary>
        public static readonly Float3x3 Identity = new Float3x3 (1f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 1f);

        /// <summary>
        /// Creates new instance of Float3x3.
        /// </summary>
        public Float3x3 (float m11, float m12, float m13, float m21, float m22, float m23, float m31, float m32, float m33) {
            M11 = m11;
            M12 = m12;
            M13 = m13;
            M21 = m21;
            M22 = m22;
            M23 = m23;
            M31 = m31;
            M32 = m32;
            M33 = m33;
        }

        /// <summary>
        /// Inverses matrix.
        /// </summary>
        public void Inverse () {
            var invDet = 1f / (M11 * M22 * M33 - M11 * M23 * M32 - M12 * M21 * M33 + M12 * M23 * M31 + M13 * M21 * M32 - M13 * M22 * M31);

            var num11 = M22 * M33 - M23 * M32;
            var num12 = M13 * M32 - M12 * M33;
            var num13 = M12 * M23 - M22 * M13;
            var num21 = M23 * M31 - M33 * M21;
            var num22 = M11 * M33 - M31 * M13;
            var num23 = M13 * M21 - M23 * M11;
            var num31 = M21 * M32 - M31 * M22;
            var num32 = M12 * M31 - M32 * M11;
            var num33 = M11 * M22 - M21 * M12;

            M11 = num11 * invDet;
            M12 = num12 * invDet;
            M13 = num13 * invDet;
            M21 = num21 * invDet;
            M22 = num22 * invDet;
            M23 = num23 * invDet;
            M31 = num31 * invDet;
            M32 = num32 * invDet;
            M33 = num33 * invDet;
        }

        /// <summary>
        /// Transposes matrix (switch rows / columns).
        /// </summary>
        public void Transpose () {
            var t = M12;
            M12 = M21;
            M21 = t;
            t = M13;
            M13 = M31;
            M31 = t;
            t = M23;
            M23 = M32;
            M32 = t;
        }

        /// <summary>
        /// Creates matrix from axis and angle around this axis.
        /// </summary>
        /// <param name="axis">Axis.</param>
        /// <param name="angle">Angle.</param>
        public static Float3x3 FromAxisAngle (ref Float3 axis, float angle) {
            var x = axis.X;
            var y = axis.Y;
            var z = axis.Z;
            var sin = (float) Math.Sin (angle);
            var cos = (float) Math.Cos (angle);
            var xx = x * x;
            var yy = y * y;
            var zz = z * z;
            var xy = x * y;
            var xz = x * z;
            var yz = y * z;
            Float3x3 res;
            res.M11 = xx + (cos * (1f - xx));
            res.M12 = (xy - (cos * xy)) + (sin * z);
            res.M13 = (xz - (cos * xz)) - (sin * y);
            res.M21 = (xy - (cos * xy)) - (sin * z);
            res.M22 = yy + (cos * (1f - yy));
            res.M23 = (yz - (cos * yz)) + (sin * x);
            res.M31 = (xz - (cos * xz)) + (sin * y);
            res.M32 = (yz - (cos * yz)) - (sin * x);
            res.M33 = zz + (cos * (1f - zz));
            return res;
        }

        /// <summary>
        /// Creates Matrix3x3 from quaternion.
        /// </summary>
        /// <param name="quat">Quaternion.</param>
        public static Float3x3 FromQuat (ref Quat quat) {
            float xx = quat.X * quat.X;
            float yy = quat.Y * quat.Y;
            float zz = quat.Z * quat.Z;
            float xy = quat.X * quat.Y;
            float zw = quat.Z * quat.W;
            float zx = quat.Z * quat.X;
            float yw = quat.Y * quat.W;
            float yz = quat.Y * quat.Z;
            float xw = quat.X * quat.W;
            Float3x3 res;
            res.M11 = 1f - (2f * (yy + zz));
            res.M12 = 2f * (xy + zw);
            res.M13 = 2f * (zx - yw);
            res.M21 = 2f * (xy - zw);
            res.M22 = 1f - (2f * (zz + xx));
            res.M23 = 2f * (yz + xw);
            res.M31 = 2f * (zx + yw);
            res.M32 = 2f * (yz - xw);
            res.M33 = 1f - (2f * (yy + xx));
            return res;
        }

        /// <summary>
        /// Returns result of multiplied matrices.
        /// </summary>
        /// <param name="lhs">First matrix.</param>
        /// <param name="rhs">Second matrix.</param>
        public static Float3x3 Mul (ref Float3x3 lhs, ref Float3x3 rhs) {
            Float3x3 res;
            res.M11 = lhs.M11 * rhs.M11 + lhs.M12 * rhs.M21 + lhs.M13 * rhs.M31;
            res.M12 = lhs.M11 * rhs.M12 + lhs.M12 * rhs.M22 + lhs.M13 * rhs.M32;
            res.M13 = lhs.M11 * rhs.M13 + lhs.M12 * rhs.M23 + lhs.M13 * rhs.M33;
            res.M21 = lhs.M21 * rhs.M11 + lhs.M22 * rhs.M21 + lhs.M23 * rhs.M31;
            res.M22 = lhs.M21 * rhs.M12 + lhs.M22 * rhs.M22 + lhs.M23 * rhs.M32;
            res.M23 = lhs.M21 * rhs.M13 + lhs.M22 * rhs.M23 + lhs.M23 * rhs.M33;
            res.M31 = lhs.M31 * rhs.M11 + lhs.M32 * rhs.M21 + lhs.M33 * rhs.M31;
            res.M32 = lhs.M31 * rhs.M12 + lhs.M32 * rhs.M22 + lhs.M33 * rhs.M32;
            res.M33 = lhs.M31 * rhs.M13 + lhs.M32 * rhs.M23 + lhs.M33 * rhs.M33;
            return res;
        }

        /// <summary>
        /// Returns sum of 2 matrices.
        /// </summary>
        /// <param name="lhs">First matrix.</param>
        /// <param name="rhs">Second matrix.</param>
        public static Float3x3 Add (ref Float3x3 lhs, ref Float3x3 rhs) {
            Float3x3 res;
            res.M11 = lhs.M11 + rhs.M11;
            res.M12 = lhs.M12 + rhs.M12;
            res.M13 = lhs.M13 + rhs.M13;
            res.M21 = lhs.M21 + rhs.M21;
            res.M22 = lhs.M22 + rhs.M22;
            res.M23 = lhs.M23 + rhs.M23;
            res.M31 = lhs.M31 + rhs.M31;
            res.M32 = lhs.M32 + rhs.M32;
            res.M33 = lhs.M33 + rhs.M33;
            return res;
        }

        /// <summary>
        /// Returns substract of 2 matrices.
        /// </summary>
        /// <param name="lhs">First matrix.</param>
        /// <param name="rhs">Second matrix.</param>
        public static Float3x3 Sub (ref Float3x3 lhs, ref Float3x3 rhs) {
            Float3x3 res;
            res.M11 = lhs.M11 - rhs.M11;
            res.M12 = lhs.M12 - rhs.M12;
            res.M13 = lhs.M13 - rhs.M13;
            res.M21 = lhs.M21 - rhs.M21;
            res.M22 = lhs.M22 - rhs.M22;
            res.M23 = lhs.M23 - rhs.M23;
            res.M31 = lhs.M31 - rhs.M31;
            res.M32 = lhs.M32 - rhs.M32;
            res.M33 = lhs.M33 - rhs.M33;
            return res;
        }

        /// <summary>
        /// Returns determinant of matrix.
        /// </summary>
        /// <param name="mat">Matrix.</param>
        public static float Det (ref Float3x3 mat) {
            return mat.M11 * mat.M22 * mat.M33 - mat.M11 * mat.M23 * mat.M32 - mat.M12 * mat.M21 * mat.M33 +
                mat.M12 * mat.M23 * mat.M31 + mat.M13 * mat.M21 * mat.M32 - mat.M13 * mat.M22 * mat.M31;
        }

        /// <summary>
        /// Calculates the inverse of a give matrix.
        /// </summary>
        /// <param name="mat">The matrix to invert.</param>
        public static Float3x3 Inverse (ref Float3x3 mat) {
            var invDet = 1f / (mat.M11 * mat.M22 * mat.M33 -
                mat.M11 * mat.M23 * mat.M32 -
                mat.M12 * mat.M21 * mat.M33 +
                mat.M12 * mat.M23 * mat.M31 +
                mat.M13 * mat.M21 * mat.M32 -
                mat.M13 * mat.M22 * mat.M31);

            Float3x3 res;
            res.M11 = (mat.M22 * mat.M33 - mat.M23 * mat.M32) * invDet;
            res.M12 = (mat.M13 * mat.M32 - mat.M12 * mat.M33) * invDet;
            res.M13 = (mat.M12 * mat.M23 - mat.M22 * mat.M13) * invDet;
            res.M21 = (mat.M23 * mat.M31 - mat.M33 * mat.M21) * invDet;
            res.M22 = (mat.M11 * mat.M33 - mat.M31 * mat.M13) * invDet;
            res.M23 = (mat.M13 * mat.M21 - mat.M23 * mat.M11) * invDet;
            res.M31 = (mat.M21 * mat.M32 - mat.M31 * mat.M22) * invDet;
            res.M32 = (mat.M12 * mat.M31 - mat.M32 * mat.M11) * invDet;
            res.M33 = (mat.M11 * mat.M22 - mat.M21 * mat.M12) * invDet;
            return res;
        }

        /// <summary>
        /// Returns scaled matrix.
        /// </summary>
        /// <param name="mat">Matrix.</param>
        /// <param name="scale">Scale.</param>
        public static Float3x3 Mul (ref Float3x3 mat, float scale) {
            Float3x3 res;
            res.M11 = mat.M11 * scale;
            res.M12 = mat.M12 * scale;
            res.M13 = mat.M13 * scale;
            res.M21 = mat.M21 * scale;
            res.M22 = mat.M22 * scale;
            res.M23 = mat.M23 * scale;
            res.M31 = mat.M31 * scale;
            res.M32 = mat.M32 * scale;
            res.M33 = mat.M33 * scale;
            return res;
        }

        /// <summary>
        /// Returns transposed matrix (switched rows / columns).
        /// </summary>
        /// <param name="mat">Matrix.</param>
        public static Float3x3 Transpose (ref Float3x3 mat) {
            Float3x3 res;
            res.M11 = mat.M11;
            res.M12 = mat.M21;
            res.M13 = mat.M31;
            res.M21 = mat.M12;
            res.M22 = mat.M22;
            res.M23 = mat.M32;
            res.M31 = mat.M13;
            res.M32 = mat.M23;
            res.M33 = mat.M33;
            return res;
        }

        /// <summary>
        /// Returns matrix with positive values.
        /// </summary>
        /// <param name="mat">Matrix.</param>
        public static Float3x3 Abs (ref Float3x3 mat) {
            Float3x3 res;
            res.M11 = mat.M11 >= 0f ? mat.M11 : -mat.M11;
            res.M12 = mat.M12 >= 0f ? mat.M12 : -mat.M12;
            res.M13 = mat.M13 >= 0f ? mat.M13 : -mat.M13;
            res.M21 = mat.M21 >= 0f ? mat.M21 : -mat.M21;
            res.M22 = mat.M22 >= 0f ? mat.M22 : -mat.M22;
            res.M23 = mat.M11 >= 0f ? mat.M23 : -mat.M23;
            res.M31 = mat.M31 >= 0f ? mat.M31 : -mat.M31;
            res.M32 = mat.M32 >= 0f ? mat.M32 : -mat.M32;
            res.M33 = mat.M33 >= 0f ? mat.M33 : -mat.M33;
            return res;
        }

        /// <summary>
        /// Transforms point with transposed version of matrix.
        /// </summary>
        /// <param name="mat">Matrix.</param>
        /// <param name="point">Point.</param>
        public static Float3 TransposedTransform (ref Float3x3 mat, ref Float3 point) {
            Float3 res;
            res.X = point.X * mat.M11 + point.Y * mat.M12 + point.Z * mat.M13;
            res.Y = point.X * mat.M21 + point.Y * mat.M22 + point.Z * mat.M23;
            res.Z = point.X * mat.M31 + point.Y * mat.M32 + point.Z * mat.M33;
            return res;
        }

        /// <summary>
        /// Transforms point with matrix.
        /// </summary>
        /// <param name="mat">Matrix.</param>
        /// <param name="point">Point.</param>
        public static Float3 Transform (ref Float3x3 mat, ref Float3 point) {
            Float3 res;
            res.X = point.X * mat.M11 + point.Y * mat.M21 + point.Z * mat.M31;
            res.Y = point.X * mat.M12 + point.Y * mat.M22 + point.Z * mat.M32;
            res.Z = point.X * mat.M13 + point.Y * mat.M23 + point.Z * mat.M33;
            return res;
        }
    }
}