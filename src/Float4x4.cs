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
    /// Matrix 4x4. Row-Column order compatible with unity Matrix4x4 class.
    /// </summary>
    [Serializable]
    [StructLayout (LayoutKind.Sequential)]
    // ReSharper disable once InconsistentNaming
    public struct Float4x4 {
        public float M11;
        public float M12;
        public float M13;
        public float M14;
        public float M21;
        public float M22;
        public float M23;
        public float M24;
        public float M31;
        public float M32;
        public float M33;
        public float M34;
        public float M41;
        public float M42;
        public float M43;
        public float M44;

        /// <summary>
        /// Returns identity matrix.
        /// </summary>
        public static readonly Float4x4 Identity = new Float4x4 (1f, 0f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f, 1f);

        /// <summary>
        /// Creates new instance of matrix.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public Float4x4 (
            float m11, float m12, float m13, float m14,
            float m21, float m22, float m23, float m24,
            float m31, float m32, float m33, float m34,
            float m41, float m42, float m43, float m44) {
            M11 = m11;
            M12 = m12;
            M13 = m13;
            M14 = m14;
            M21 = m21;
            M22 = m22;
            M23 = m23;
            M24 = m24;
            M31 = m31;
            M32 = m32;
            M33 = m33;
            M34 = m34;
            M41 = m41;
            M42 = m42;
            M43 = m43;
            M44 = m44;
        }
#if DEBUG
        public override string ToString () {
            return string.Format (System.Globalization.CultureInfo.InvariantCulture,
                "{0:F5}\t{1:F5}\t{2:F5}\t{3:F5}\n{4:F5}\t{5:F5}\t{6:F5}\t{7:F5}\n{8:F5}\t{9:F5}\t{10:F5}\t{11:F5}\n{12:F5}\t{13:F5}\t{14:F5}\t{15:F5}\n",
                M11, M12, M13, M14, M21, M22, M23, M24, M31, M32, M33, M34, M41, M42, M43, M44);
        }
#endif
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Float3 operator * (in Float4x4 lhs, in Float3 rhs) {
            Float3 res;
            var w = 1f / (lhs.M41 * rhs.X + lhs.M42 * rhs.Y + lhs.M43 * rhs.Z + lhs.M44);
            res.X = w * (lhs.M11 * rhs.X + lhs.M12 * rhs.Y + lhs.M13 * rhs.Z + lhs.M14);
            res.Y = w * (lhs.M21 * rhs.X + lhs.M22 * rhs.Y + lhs.M23 * rhs.Z + lhs.M24);
            res.Z = w * (lhs.M31 * rhs.X + lhs.M32 * rhs.Y + lhs.M33 * rhs.Z + lhs.M34);
            return res;
        }

        /// <summary>
        /// Transforms point without perspective correction.
        /// </summary>
        /// <param name="mat">Transform matrix.</param>
        /// <param name="point">Point to transform.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Float3 TransformFast (in Float4x4 mat, in Float3 point) {
            Float3 res;
            res.X = mat.M11 * point.X + mat.M12 * point.Y + mat.M13 * point.Z + mat.M14;
            res.Y = mat.M21 * point.X + mat.M22 * point.Y + mat.M23 * point.Z + mat.M24;
            res.Z = mat.M31 * point.X + mat.M32 * point.Y + mat.M33 * point.Z + mat.M34;
            return res;
        }

        /// <summary>
        /// Transforms direction vector.
        /// </summary>
        /// <param name="mat">Matrix.</param>
        /// <param name="dir">Direction vector.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Float3 TransformDirection (in Float4x4 mat, in Float3 dir) {
            Float3 res;
            res.X = mat.M11 * dir.X + mat.M12 * dir.Y + mat.M13 * dir.Z;
            res.Y = mat.M21 * dir.X + mat.M22 * dir.Y + mat.M23 * dir.Z;
            res.Z = mat.M31 * dir.X + mat.M32 * dir.Y + mat.M33 * dir.Z;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Float4x4 operator * (in Float4x4 lhs, in Float4x4 rhs) {
            Float4x4 res;
            res.M11 = lhs.M11 * rhs.M11 + lhs.M12 * rhs.M21 + lhs.M13 * rhs.M31 + lhs.M14 * rhs.M41;
            res.M12 = lhs.M11 * rhs.M12 + lhs.M12 * rhs.M22 + lhs.M13 * rhs.M32 + lhs.M14 * rhs.M42;
            res.M13 = lhs.M11 * rhs.M13 + lhs.M12 * rhs.M23 + lhs.M13 * rhs.M33 + lhs.M14 * rhs.M43;
            res.M14 = lhs.M11 * rhs.M14 + lhs.M12 * rhs.M24 + lhs.M13 * rhs.M34 + lhs.M14 * rhs.M44;
            res.M21 = lhs.M21 * rhs.M11 + lhs.M22 * rhs.M21 + lhs.M23 * rhs.M31 + lhs.M24 * rhs.M41;
            res.M22 = lhs.M21 * rhs.M12 + lhs.M22 * rhs.M22 + lhs.M23 * rhs.M32 + lhs.M24 * rhs.M42;
            res.M23 = lhs.M21 * rhs.M13 + lhs.M22 * rhs.M23 + lhs.M23 * rhs.M33 + lhs.M24 * rhs.M43;
            res.M24 = lhs.M21 * rhs.M14 + lhs.M22 * rhs.M24 + lhs.M23 * rhs.M34 + lhs.M24 * rhs.M44;
            res.M31 = lhs.M31 * rhs.M11 + lhs.M32 * rhs.M21 + lhs.M33 * rhs.M31 + lhs.M34 * rhs.M41;
            res.M32 = lhs.M31 * rhs.M12 + lhs.M32 * rhs.M22 + lhs.M33 * rhs.M32 + lhs.M34 * rhs.M42;
            res.M33 = lhs.M31 * rhs.M13 + lhs.M32 * rhs.M23 + lhs.M33 * rhs.M33 + lhs.M34 * rhs.M43;
            res.M34 = lhs.M31 * rhs.M14 + lhs.M32 * rhs.M24 + lhs.M33 * rhs.M34 + lhs.M34 * rhs.M44;
            res.M41 = lhs.M41 * rhs.M11 + lhs.M42 * rhs.M21 + lhs.M43 * rhs.M31 + lhs.M44 * rhs.M41;
            res.M42 = lhs.M41 * rhs.M12 + lhs.M42 * rhs.M22 + lhs.M43 * rhs.M32 + lhs.M44 * rhs.M42;
            res.M43 = lhs.M41 * rhs.M13 + lhs.M42 * rhs.M23 + lhs.M43 * rhs.M33 + lhs.M44 * rhs.M43;
            res.M44 = lhs.M41 * rhs.M14 + lhs.M42 * rhs.M24 + lhs.M43 * rhs.M34 + lhs.M44 * rhs.M44;
            return res;
        }

        /// <summary>
        /// Creates translated matrix from position.
        /// </summary>
        /// <param name="point">Position point.</param>
        public static Float4x4 FromPosition (in Float3 point) {
            Float4x4 mat;
            mat.M11 = 0f;
            mat.M12 = 0f;
            mat.M13 = 0f;
            mat.M14 = point.X;
            mat.M21 = 0f;
            mat.M22 = 0f;
            mat.M23 = 0f;
            mat.M24 = point.Y;
            mat.M31 = 0f;
            mat.M32 = 0f;
            mat.M33 = 0f;
            mat.M33 = 0f;
            mat.M34 = point.Z;
            mat.M41 = 0f;
            mat.M42 = 0f;
            mat.M43 = 0f;
            mat.M44 = 1f;
            return mat;
        }

        /// <summary>
        /// Creates rotated matrix from quaternion.
        /// </summary>
        /// <param name="quat">Quaternion.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Float4x4 FromRotation (in Quat quat) {
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
            Float4x4 mat;
            mat.M11 = 1f - (yy + zz);
            mat.M12 = xy - wz;
            mat.M13 = xz + wy;
            mat.M14 = 0f;
            mat.M21 = xy + wz;
            mat.M22 = 1f - (xx + zz);
            mat.M23 = yz - wx;
            mat.M24 = 0f;
            mat.M31 = xz - wy;
            mat.M32 = yz + wx;
            mat.M33 = 1f - (xx + yy);
            mat.M34 = 0f;
            mat.M41 = 0f;
            mat.M42 = 0f;
            mat.M43 = 0f;
            mat.M44 = 1f;
            return mat;
        }

        /// <summary>
        /// Creates scale matrix from vector.
        /// </summary>
        /// <param name="scale">Scale vector.</param>
        public static Float4x4 FromScale (in Float3 scale) {
            Float4x4 mat;
            mat.M11 = scale.X;
            mat.M12 = 0f;
            mat.M13 = 0f;
            mat.M14 = 0f;
            mat.M21 = 0f;
            mat.M22 = scale.Y;
            mat.M23 = 0f;
            mat.M24 = 0f;
            mat.M31 = 0f;
            mat.M32 = 0f;
            mat.M33 = scale.Z;
            mat.M33 = 0f;
            mat.M34 = 0f;
            mat.M41 = 0f;
            mat.M42 = 0f;
            mat.M43 = 0f;
            mat.M44 = 1f;
            return mat;
        }

        /// <summary>
        /// Creates matrix from translate / rotate / scale components.
        /// </summary>
        /// <param name="translate">Translate vector.</param>
        /// <param name="rotate">Quaternion.</param>
        /// <param name="scale">Scale vector.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Float4x4 FromTrs (in Float3 translate, in Quat rotate, in Float3 scale) {
            var rotX = rotate.X;
            var rotY = rotate.Y;
            var rotZ = rotate.Z;
            var xx = rotX * rotX;
            var yy = rotY * rotY;
            var zz = rotZ * rotZ;
            var xy = rotX * rotY;
            var zw = rotZ * rotate.W;
            var zx = rotZ * rotX;
            var yw = rotY * rotate.W;
            var yz = rotY * rotZ;
            var xw = rotX * rotate.W;
            Float4x4 mat;
            mat.M11 = (1f - 2f * (yy + zz)) * scale.X;
            mat.M12 = (2f * (xy - zw)) * scale.Y;
            mat.M13 = (2f * (zx + yw)) * scale.Z;
            mat.M14 = translate.X;
            mat.M21 = (2f * (xy + zw)) * scale.X;
            mat.M22 = (1f - 2f * (zz + xx)) * scale.Y;
            mat.M23 = (2f * (yz - xw)) * scale.Z;
            mat.M24 = translate.Y;
            mat.M31 = (2f * (zx - yw)) * scale.X;
            mat.M32 = (2f * (yz + xw)) * scale.Y;
            mat.M33 = (1f - 2f * (yy + xx)) * scale.Z;
            mat.M34 = translate.Z;
            mat.M41 = 0f;
            mat.M42 = 0f;
            mat.M43 = 0f;
            mat.M44 = 1f;
            return mat;
        }
    }
}