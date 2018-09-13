// ----------------------------------------------------------------------------
// The MIT License
// Types for Entity Component System framework https://github.com/Leopotam/ecs
// Copyright (c) 2017-2018 Leopotam <leopotam@gmail.com>
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
        public float M11; // 1st row vector
        public float M12;
        public float M13;
        public float M21; // 2nd row vector
        public float M22;
        public float M23;
        public float M31; // 3rd row vector
        public float M32;
        public float M33;

        /// <summary>
        /// Identity matrix.
        /// </summary>
        public static readonly Float3x3 Identity = new Float3x3 (1f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 1f);

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

        public static Float3x3 FromQuat (ref Quat quat) {
            var x = quat.X * 2f;
            var y = quat.Y * 2f;
            var z = quat.Z * 2f;
            var xx = quat.X * x;
            var yy = quat.Y * y;
            var zz = quat.Z * z;
            var xy = quat.X * y;
            var xz = quat.X * z;
            var yz = quat.Y * z;
            var wx = quat.W * x;
            var wy = quat.W * y;
            var wz = quat.W * z;
            Float3x3 res;
            res.M11 = 1f - (yy + zz);
            res.M12 = xy - wz;
            res.M13 = xz + wy;
            res.M21 = xy + wz;
            res.M22 = 1f - (xx + zz);
            res.M23 = yz - wx;
            res.M31 = xz - wy;
            res.M32 = yz + wx;
            res.M33 = 1f - (xx + yy);
            return res;
        }

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

        public float Trace () {
            return this.M11 + this.M22 + this.M33;
        }

        public static float Det (ref Float3x3 lhs) {
            return lhs.M11 * lhs.M22 * lhs.M33 - lhs.M11 * lhs.M23 * lhs.M32 - lhs.M12 * lhs.M21 * lhs.M33 +
                lhs.M12 * lhs.M23 * lhs.M31 + lhs.M13 * lhs.M21 * lhs.M32 - lhs.M13 * lhs.M22 * lhs.M31;
        }

        /// <summary>
        /// Calculates the inverse of a give matrix.
        /// </summary>
        /// <param name="matrix">The matrix to invert.</param>
        public static Float3x3 Inverse (ref Float3x3 matrix) {
            var invDet = 1f / (matrix.M11 * matrix.M22 * matrix.M33 -
                matrix.M11 * matrix.M23 * matrix.M32 -
                matrix.M12 * matrix.M21 * matrix.M33 +
                matrix.M12 * matrix.M23 * matrix.M31 +
                matrix.M13 * matrix.M21 * matrix.M32 -
                matrix.M13 * matrix.M22 * matrix.M31);

            Float3x3 res;
            res.M11 = (matrix.M22 * matrix.M33 - matrix.M23 * matrix.M32) * invDet;
            res.M12 = (matrix.M13 * matrix.M32 - matrix.M12 * matrix.M33) * invDet;
            res.M13 = (matrix.M12 * matrix.M23 - matrix.M22 * matrix.M13) * invDet;
            res.M21 = (matrix.M23 * matrix.M31 - matrix.M33 * matrix.M21) * invDet;
            res.M22 = (matrix.M11 * matrix.M33 - matrix.M31 * matrix.M13) * invDet;
            res.M23 = (matrix.M13 * matrix.M21 - matrix.M23 * matrix.M11) * invDet;
            res.M31 = (matrix.M21 * matrix.M32 - matrix.M31 * matrix.M22) * invDet;
            res.M32 = (matrix.M12 * matrix.M31 - matrix.M32 * matrix.M11) * invDet;
            res.M33 = (matrix.M11 * matrix.M22 - matrix.M21 * matrix.M12) * invDet;
            return res;
        }

        public static Float3x3 Mul (ref Float3x3 matrix1, float scaleFactor) {
            Float3x3 result;
            result.M11 = matrix1.M11 * scaleFactor;
            result.M12 = matrix1.M12 * scaleFactor;
            result.M13 = matrix1.M13 * scaleFactor;
            result.M21 = matrix1.M21 * scaleFactor;
            result.M22 = matrix1.M22 * scaleFactor;
            result.M23 = matrix1.M23 * scaleFactor;
            result.M31 = matrix1.M31 * scaleFactor;
            result.M32 = matrix1.M32 * scaleFactor;
            result.M33 = matrix1.M33 * scaleFactor;
            return result;
        }

        public static Float3x3 CreateFromQuaternion (ref Quat quaternion) {
            float x2 = quaternion.X * quaternion.X;
            float y2 = quaternion.Y * quaternion.Y;
            float z2 = quaternion.Z * quaternion.Z;
            float num6 = quaternion.X * quaternion.Y;
            float num5 = quaternion.Z * quaternion.W;
            float num4 = quaternion.Z * quaternion.X;
            float num3 = quaternion.Y * quaternion.W;
            float num2 = quaternion.Y * quaternion.Z;
            float num = quaternion.X * quaternion.W;
            Float3x3 res;
            res.M11 = 1f - (2f * (y2 + z2));
            res.M12 = 2f * (num6 + num5);
            res.M13 = 2f * (num4 - num3);
            res.M21 = 2f * (num6 - num5);
            res.M22 = 1f - (2f * (z2 + x2));
            res.M23 = 2f * (num2 + num);
            res.M31 = 2f * (num4 + num3);
            res.M32 = 2f * (num2 - num);
            res.M33 = 1f - (2f * (y2 + x2));
            return res;
        }

        public static Float3x3 Transpose (ref Float3x3 matrix) {
            Float3x3 res;
            res.M11 = matrix.M11;
            res.M12 = matrix.M21;
            res.M13 = matrix.M31;
            res.M21 = matrix.M12;
            res.M22 = matrix.M22;
            res.M23 = matrix.M32;
            res.M31 = matrix.M13;
            res.M32 = matrix.M23;
            res.M33 = matrix.M33;
            return res;
        }

        public static Float3x3 Abs (ref Float3x3 matrix) {
            Float3x3 res;
            res.M11 = matrix.M11 >= 0f ? matrix.M11 : -matrix.M11;
            res.M12 = matrix.M12 >= 0f ? matrix.M12 : -matrix.M12;
            res.M13 = matrix.M13 >= 0f ? matrix.M13 : -matrix.M13;
            res.M21 = matrix.M21 >= 0f ? matrix.M21 : -matrix.M21;
            res.M22 = matrix.M22 >= 0f ? matrix.M22 : -matrix.M22;
            res.M23 = matrix.M11 >= 0f ? matrix.M23 : -matrix.M23;
            res.M31 = matrix.M31 >= 0f ? matrix.M31 : -matrix.M31;
            res.M32 = matrix.M32 >= 0f ? matrix.M32 : -matrix.M32;
            res.M33 = matrix.M33 >= 0f ? matrix.M33 : -matrix.M33;
            return res;
        }

        public static Float3x3 CreateFromAxisAngle (ref Float3 axis, float angle) {
            float x = axis.X;
            float y = axis.Y;
            float z = axis.Z;
            float num2 = (float) Math.Sin (angle);
            float num = (float) Math.Cos (angle);
            float num11 = x * x;
            float num10 = y * y;
            float num9 = z * z;
            float num8 = x * y;
            float num7 = x * z;
            float num6 = y * z;
            Float3x3 res;
            res.M11 = num11 + (num * (1f - num11));
            res.M12 = (num8 - (num * num8)) + (num2 * z);
            res.M13 = (num7 - (num * num7)) - (num2 * y);
            res.M21 = (num8 - (num * num8)) - (num2 * z);
            res.M22 = num10 + (num * (1f - num10));
            res.M23 = (num6 - (num * num6)) + (num2 * x);
            res.M31 = (num7 - (num * num7)) + (num2 * y);
            res.M32 = (num6 - (num * num6)) - (num2 * x);
            res.M33 = num9 + (num * (1f - num9));
            return res;
        }

        public static Float3 TransposedTransform (ref Float3x3 mat, ref Float3 point) {
            Float3 result;
            result.X = point.X * mat.M11 + point.Y * mat.M12 + point.Z * mat.M13;
            result.Y = point.X * mat.M21 + point.Y * mat.M22 + point.Z * mat.M23;
            result.Z = point.X * mat.M31 + point.Y * mat.M32 + point.Z * mat.M33;
            return result;
        }

        public static Float3 Transform (ref Float3x3 mat, ref Float3 point) {
            Float3 res;
            res.X = point.X * mat.M11 + point.Y * mat.M21 + point.Z * mat.M31;
            res.Y = point.X * mat.M12 + point.Y * mat.M22 + point.Z * mat.M32;
            res.Z = point.X * mat.M13 + point.Y * mat.M23 + point.Z * mat.M33;
            return res;
        }
    }
}