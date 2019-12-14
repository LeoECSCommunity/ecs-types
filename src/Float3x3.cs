// ----------------------------------------------------------------------------
// The MIT License
// Types for Entity Component System framework https://github.com/Leopotam/ecs
// Copyright (c) 2017-2019 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Leopotam.Ecs.Types {
    /// <summary>
    /// Matrix 3x3.
    /// </summary>
    [Serializable]
    [StructLayout (LayoutKind.Sequential)]
    // ReSharper disable once InconsistentNaming
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
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Float3x3 FromAxisAngle (in Float3 axis, float angle) {
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
        /// Returns determinant of matrix.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public float GetDeterminant () {
            return M11 * M22 * M33 - M11 * M23 * M32 - M12 * M21 * M33 +
                M12 * M23 * M31 + M13 * M21 * M32 - M13 * M22 * M31;
        }

        /// <summary>
        /// Calculates the inverse of a give matrix.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public Float3x3 GetInversed () {
            var invDet = 1f / (M11 * M22 * M33 - M11 * M23 * M32 - M12 * M21 * M33 + M12 * M23 * M31 + M13 * M21 * M32 - M13 * M22 * M31);
            Float3x3 res;
            res.M11 = (M22 * M33 - M23 * M32) * invDet;
            res.M12 = (M13 * M32 - M12 * M33) * invDet;
            res.M13 = (M12 * M23 - M22 * M13) * invDet;
            res.M21 = (M23 * M31 - M33 * M21) * invDet;
            res.M22 = (M11 * M33 - M31 * M13) * invDet;
            res.M23 = (M13 * M21 - M23 * M11) * invDet;
            res.M31 = (M21 * M32 - M31 * M22) * invDet;
            res.M32 = (M12 * M31 - M32 * M11) * invDet;
            res.M33 = (M11 * M22 - M21 * M12) * invDet;
            return res;
        }

        /// <summary>
        /// Returns transposed matrix (switched rows / columns).
        /// </summary>
        public Float3x3 GetTransposed () {
            Float3x3 res;
            res.M11 = M11;
            res.M12 = M21;
            res.M13 = M31;
            res.M21 = M12;
            res.M22 = M22;
            res.M23 = M32;
            res.M31 = M13;
            res.M32 = M23;
            res.M33 = M33;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Float3x3 operator * (in Float3x3 lhs, in Float3x3 rhs) {
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

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Float3x3 operator + (in Float3x3 lhs, in Float3x3 rhs) {
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

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Float3x3 operator - (in Float3x3 lhs, in Float3x3 rhs) {
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
        /// Returns scaled matrix.
        /// </summary>
        /// <param name="mat">Matrix.</param>
        /// <param name="scale">Scale.</param>
        public static Float3x3 operator * (in Float3x3 mat, float scale) {
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
        /// Transforms point with matrix.
        /// </summary>
        /// <param name="lhs">Matrix.</param>
        /// <param name="rhs">Point.</param>
        public static Float3 operator * (in Float3x3 lhs, Float3 rhs) {
            Float3 res;
            res.X = rhs.X * lhs.M11 + rhs.Y * lhs.M21 + rhs.Z * lhs.M31;
            res.Y = rhs.X * lhs.M12 + rhs.Y * lhs.M22 + rhs.Z * lhs.M32;
            res.Z = rhs.X * lhs.M13 + rhs.Y * lhs.M23 + rhs.Z * lhs.M33;
            return res;
        }

        public static implicit operator Float3x3 (in Quat lhs) {
            var xx = lhs.X * lhs.X;
            var yy = lhs.Y * lhs.Y;
            var zz = lhs.Z * lhs.Z;
            var xy = lhs.X * lhs.Y;
            var zw = lhs.Z * lhs.W;
            var zx = lhs.Z * lhs.X;
            var yw = lhs.Y * lhs.W;
            var yz = lhs.Y * lhs.Z;
            var xw = lhs.X * lhs.W;
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
    }
}