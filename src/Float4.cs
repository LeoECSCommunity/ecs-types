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
    /// Vector with 4 float components.
    /// </summary>
    [Serializable]
    [StructLayout (LayoutKind.Sequential)]
    public struct Float4 {
        public float X;
        public float Y;
        public float Z;
        public float W;

        /// <summary>
        /// Creates new instance of vector.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public Float4 (float x, float y, float z, float w) {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>
        /// Reverses vector direction inplace.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public void Neg () {
            X = -X;
            Y = -Y;
            Z = -Z;
            W = -W;
        }

        /// <summary>
        /// Sets vector component values.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public void Set (float x, float y, float z, float w) {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>
        /// Normalizes vector inplace.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public void Normalize () {
            var v = X * X + Y * Y + Z * Z + W * W;
            if (v > MathFast.Epsilon) {
                v = 1f / (float) Math.Sqrt (v);
                X *= v;
                Y *= v;
                Z *= v;
                W *= v;
            }
        }

#if DEBUG
        public override string ToString () {
            return string.Format (System.Globalization.CultureInfo.InvariantCulture, "({0:F5}, {1:F5}, {2:F5}, {3:F5})", X, Y, Z, W);
        }
#endif
        /// <summary>
        /// Returns dot product of vectors.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static float Dot (in Float4 lhs, in Float4 rhs) {
            return lhs.X * rhs.X + lhs.Y * rhs.Y + lhs.Z * rhs.Z + lhs.W * rhs.W;
        }

        /// <summary>
        /// Returns linear interpolated vector value between start and end vectors.
        /// </summary>
        /// <param name="lhs">Start vector.</param>
        /// <param name="rhs">End vector.</param>
        /// <param name="t">Factor in range [0f,1f].</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Float4 Lerp (in Float4 lhs, in Float4 rhs, float t) {
            if (t > 1f) {
                return rhs;
            }
            if (t < 0f) {
                return lhs;
            }
            Float4 res;
            res.X = (rhs.X - lhs.X) * t + lhs.X;
            res.Y = (rhs.Y - lhs.Y) * t + lhs.Y;
            res.Z = (rhs.Z - lhs.Z) * t + lhs.Z;
            res.W = (rhs.W - lhs.W) * t + lhs.W;
            return res;
        }

        /// <summary>
        /// Returns square magnitude of vector.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public float GetSqrMagnitude () {
            return X * X + Y * Y + Z * Z + W * W;
        }

        /// <summary>
        /// Returns magnitude of vector.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public float GetMagnitude () {
            return (float) Math.Sqrt (X * X + Y * Y + Z * Z + W * W);
        }

        /// <summary>
        /// Returns normalized version of vector.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public Float4 GetNormalized () {
            Float4 res;
            var v = X * X + Y * Y + Z * Z + W * W;
            v = v > MathFast.Epsilon ? 1f / (float) Math.Sqrt (v) : 0f;
            res.X = X * v;
            res.Y = Y * v;
            res.Z = Z * v;
            res.W = W * v;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Float4 operator + (in Float4 lhs, in Float4 rhs) {
            Float4 res;
            res.X = lhs.X + rhs.X;
            res.Y = lhs.Y + rhs.Y;
            res.Z = lhs.Z + rhs.Z;
            res.W = lhs.W + rhs.W;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Float4 operator - (in Float4 lhs, in Float4 rhs) {
            Float4 res;
            res.X = lhs.X - rhs.X;
            res.Y = lhs.Y - rhs.Y;
            res.Z = lhs.Z - rhs.Z;
            res.W = lhs.W - rhs.W;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Float4 operator * (in Float4 lhs, in Float4 rhs) {
            Float4 res;
            res.X = lhs.X * rhs.X;
            res.Y = lhs.Y * rhs.Y;
            res.Z = lhs.Z * rhs.Z;
            res.W = lhs.W * rhs.W;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Float4 operator * (in Float4 lhs, float rhs) {
            Float4 res;
            res.X = lhs.X * rhs;
            res.Y = lhs.Y * rhs;
            res.Z = lhs.Z * rhs;
            res.W = lhs.W * rhs;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Float4 operator / (in Float4 lhs, float rhs) {
            Float4 res;
            rhs = 1f / rhs;
            res.X = lhs.X * rhs;
            res.Y = lhs.Y * rhs;
            res.Z = lhs.Z * rhs;
            res.W = lhs.W * rhs;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Float4 operator - (in Float4 lhs) {
            Float4 res;
            res.X = -lhs.X;
            res.Y = -lhs.Y;
            res.Z = -lhs.Z;
            res.W = -lhs.W;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static bool operator == (in Float4 lhs, in Float4 rhs) {
            return (lhs.X - rhs.X) * (lhs.X - rhs.X) +
                   (lhs.Y - rhs.Y) * (lhs.Y - rhs.Y) +
                   (lhs.Z - rhs.Z) * (lhs.Z - rhs.Z) +
                   (lhs.W - rhs.W) * (lhs.W - rhs.W) < MathFast.Epsilon;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static bool operator != (in Float4 lhs, in Float4 rhs) {
            return (lhs.X - rhs.X) * (lhs.X - rhs.X) +
                   (lhs.Y - rhs.Y) * (lhs.Y - rhs.Y) +
                   (lhs.Z - rhs.Z) * (lhs.Z - rhs.Z) +
                   (lhs.W - rhs.W) * (lhs.W - rhs.W) >= MathFast.Epsilon;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode () {
            // ReSharper disable NonReadonlyMemberInGetHashCode
            return X.GetHashCode () ^ (Y.GetHashCode () << 2) ^ (Z.GetHashCode () >> 2) ^ (W.GetHashCode () >> 1);
            // ReSharper restore NonReadonlyMemberInGetHashCode
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public override bool Equals (object other) {
            if (!(other is Float4)) {
                return false;
            }
            var rhs = (Float4) other;
            return (
                       (X - rhs.X) * (X - rhs.X) +
                       (Y - rhs.Y) * (Y - rhs.Y) +
                       (Z - rhs.Z) * (Z - rhs.Z) +
                       (W - rhs.W) * (W - rhs.W)) < MathFast.Epsilon;
        }

#if UNITY_2018_3_OR_NEWER
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static implicit operator UnityEngine.Vector4 (in Float4 lhs) {
            UnityEngine.Vector4 res;
            res.x = lhs.X;
            res.y = lhs.Y;
            res.z = lhs.Z;
            res.w = lhs.W;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static implicit operator Float4 (in UnityEngine.Vector4 lhs) {
            Float4 res;
            res.X = lhs.x;
            res.Y = lhs.y;
            res.Z = lhs.z;
            res.W = lhs.w;
            return res;
        }
#endif
    }
}