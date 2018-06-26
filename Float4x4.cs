// ----------------------------------------------------------------------------
// The MIT License
// Types for Entity Component System framework https://github.com/Leopotam/ecs
// Copyright (c) 2017-2018 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;

#if NET_4_6
using System.Runtime.CompilerServices;
#endif

namespace Leopotam.Ecs.Types {
    /// <summary>
    /// Matrix 4x4.
    /// </summary>
    [Serializable]
    [StructLayout (LayoutKind.Sequential)]
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

        static readonly Float4x4 _identity = new Float4x4 (1f, 0f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f, 1f);

        /// <summary>
        /// Creates new instance of Float4x4.
        /// </summary>
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

        /// <summary>
        /// Transforms point with perspective correction.
        /// </summary>
        /// <param name="point">Point to transform.</param>
#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float3 Transform (ref Float4x4 mat, ref Float3 point) {
            Float3 res;
            var w = 1f / (mat.M41 * point.X + mat.M42 * point.Y + mat.M43 * point.Z + mat.M44);
            res.X = w * (mat.M11 * point.X + mat.M12 * point.Y + mat.M13 * point.Z + mat.M14);
            res.Y = w * (mat.M21 * point.X + mat.M22 * point.Y + mat.M23 * point.Z + mat.M24);
            res.Z = w * (mat.M31 * point.X + mat.M32 * point.Y + mat.M33 * point.Z + mat.M34);
            return res;
        }

        /// <summary>
        /// Transforms point without perspective correction.
        /// </summary>
        /// <param name="point">Point to transform.</param>
#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float3 TransformFast (ref Float4x4 mat, ref Float3 point) {
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
#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float3 TransformDirection (ref Float4x4 mat, ref Float3 dir) {
            Float3 res;
            res.X = mat.M11 * dir.X + mat.M12 * dir.Y + mat.M13 * dir.Z;
            res.Y = mat.M21 * dir.X + mat.M22 * dir.Y + mat.M23 * dir.Z;
            res.Z = mat.M31 * dir.X + mat.M32 * dir.Y + mat.M33 * dir.Z;
            return res;
        }

        /// <summary>
        /// Multiplies matrices.
        /// </summary>
        /// <param name="lhs">First matrix.</param>
        /// <param name="rhs">Second matrix.</param>
#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float4x4 Mul (ref Float4x4 lhs, ref Float4x4 rhs) {
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
        /// Gets Identity matrix.
        /// </summary>
#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float4x4 Identity () {
            return _identity;
        }

        /// <summary>
        /// Creates matrix from euler angles.
        /// </summary>
        /// <param name="x">Rotation around x-axis in radians.</param>
        /// <param name="y">Rotation around y-axis in radians.</param>
        /// <param name="z">Rotation around z-axis in radians.</param>
#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float4x4 FromEuler (float x, float y, float z) {
            var cr = (float) Math.Cos (x);
            var sr = (float) Math.Sin (x);
            var cp = (float) Math.Cos (y);
            var sp = (float) Math.Sin (y);
            var cy = (float) Math.Cos (z);
            var sy = (float) Math.Sin (z);
            var srsp = sr * sp;
            var crsp = cr * sp;
            Float4x4 mat;
            mat.M11 = cp * cy;
            mat.M12 = cp * sy;
            mat.M13 = -sp;
            mat.M14 = 0f;
            mat.M21 = srsp * cy - cr * sy;
            mat.M22 = srsp * sy + cr * cy;
            mat.M23 = sr * cp;
            mat.M24 = 0f;
            mat.M31 = crsp * cy + sr * sy;
            mat.M32 = crsp * sy - sr * cy;
            mat.M33 = cr * cp;
            mat.M34 = 0f;
            mat.M41 = 0f;
            mat.M42 = 0f;
            mat.M43 = 0f;
            mat.M44 = 1f;
            return mat;
        }
    }
}