// ----------------------------------------------------------------------------
// The MIT License
// Types for Entity Component System framework https://github.com/Leopotam/ecs
// Copyright (c) 2017-2019 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;

#if NET_4_6 || NET_STANDARD_2_0
using System.Runtime.CompilerServices;
#endif

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
        public Float4 (float x, float y, float z, float w) {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>
        /// Reverses vector direction inplace.
        /// </summary>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Neg () {
            X = -X;
            Y = -Y;
            Z = -Z;
            W = -W;
        }

        /// <summary>
        /// Normalizes vector inplace.
        /// </summary>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Normalize () {
            var invMagnitude = 1f / (float) Math.Sqrt (X * X + Y * Y + Z * Z + W * W);
            X *= invMagnitude;
            Y *= invMagnitude;
            Z *= invMagnitude;
            W *= invMagnitude;
        }

        /// <summary>
        /// Adds new vector inplace.
        /// </summary>
        /// <param name="rhs">New vector.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Add (ref Float4 rhs) {
            X += rhs.X;
            Y += rhs.Y;
            Z += rhs.Z;
            W += rhs.W;
        }

        /// <summary>
        /// Adds offsets inplace.
        /// </summary>
        /// <param name="x">X offset.</param>
        /// <param name="y">Y offset.</param>
        /// <param name="z">Z offset.</param>
        /// <param name="w">W offset.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Add (float x, float y, float z, float w) {
            X += x;
            Y += y;
            Z += z;
            W += w;
        }

        /// <summary>
        /// Substracts new vector inplace.
        /// </summary>
        /// <param name="rhs">New vector.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Sub (ref Float4 rhs) {
            X -= rhs.X;
            Y -= rhs.Y;
            Z -= rhs.Z;
            W -= rhs.W;
        }

        /// <summary>
        /// Scales (multipies) vector with scalar factor inplace.
        /// </summary>
        /// <param name="scale">Scale factor.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Scale (float scale) {
            X *= scale;
            Y *= scale;
            Z *= scale;
            W *= scale;
        }
#if DEBUG
        public override string ToString () {
            return string.Format (System.Globalization.CultureInfo.InvariantCulture, "({0:F5}, {1:F5}, {2:F5}, {3:F5})", X, Y, Z, W);
        }
#endif
        /// <summary>
        /// Returns square magnitude of vector.
        /// </summary>
        /// <param name="lhs">Vector.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static float SqrMagnitude (ref Float4 lhs) {
            return lhs.X * lhs.X + lhs.Y * lhs.Y + lhs.Z * lhs.Z + lhs.W * lhs.W;
        }

        /// <summary>
        /// Returns magnitude of vector.
        /// </summary>
        /// <param name="lhs">Vector.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static float Magnitude (ref Float4 lhs) {
            return (float) Math.Sqrt (lhs.X * lhs.X + lhs.Y * lhs.Y + lhs.Z * lhs.Z + lhs.W * lhs.W);
        }

        /// <summary>
        /// Returns dot product of vectors.
        /// </summary>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static float Dot (ref Float4 lhs, ref Float4 rhs) {
            return lhs.X * rhs.X + lhs.Y * rhs.Y + lhs.Z * rhs.Z + lhs.W * rhs.W;
        }

        /// <summary>
        /// Returns vector with reversed direction.
        /// </summary>
        /// <param name="lhs">Vector.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float4 Neg (ref Float4 lhs) {
            Float4 res;
            res.X = -lhs.X;
            res.Y = -lhs.Y;
            res.Z = -lhs.Z;
            res.W = -lhs.W;
            return res;
        }

        /// <summary>
        /// Returns sum of 2 vectors.
        /// </summary>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float4 Add (ref Float4 lhs, ref Float4 rhs) {
            Float4 res;
            res.X = lhs.X + rhs.X;
            res.Y = lhs.Y + rhs.Y;
            res.Z = lhs.Z + rhs.Z;
            res.W = lhs.W + rhs.W;
            return res;
        }

        /// <summary>
        /// Returns sum of vector and offsets.
        /// </summary>
        /// <param name="lhs">Vector.</param>
        /// <param name="x">X offset.</param>
        /// <param name="y">Y offset.</param>
        /// <param name="z">Z offset.</param>
        /// <param name="w">W offset.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float4 Add (ref Float4 lhs, float x, float y, float z, float w) {
            Float4 res;
            res.X = lhs.X + x;
            res.Y = lhs.Y + y;
            res.Z = lhs.Z + z;
            res.W = lhs.W + w;
            return res;
        }

        /// <summary>
        /// Returns substract of 2 vectors.
        /// </summary>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float4 Sub (ref Float4 lhs, ref Float4 rhs) {
            Float4 res;
            res.X = lhs.X - rhs.X;
            res.Y = lhs.Y - rhs.Y;
            res.Z = lhs.Z - rhs.Z;
            res.W = lhs.W - rhs.W;
            return res;
        }

        /// <summary>
        /// Returns scaled (multipled) vector with scalar factor.
        /// </summary>
        /// <param name="lhs">Vector.</param>
        /// <param name="scale">Scale factor.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float4 Scale (ref Float4 lhs, float scale) {
            Float4 res;
            res.X = lhs.X * scale;
            res.Y = lhs.Y * scale;
            res.Z = lhs.Z * scale;
            res.W = lhs.W * scale;
            return res;
        }

        /// <summary>
        /// Returns normalized version of vector.
        /// </summary>
        /// <param name="rhs">Vector.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float4 Normalize (ref Float4 rhs) {
            Float4 res;
            var invMagnitude = 1f / (float) Math.Sqrt (rhs.X * rhs.X + rhs.Y * rhs.Y + rhs.Z * rhs.Z + rhs.W * rhs.W);
            res.X = rhs.X * invMagnitude;
            res.Y = rhs.Y * invMagnitude;
            res.Z = rhs.Z * invMagnitude;
            res.W = rhs.W * invMagnitude;
            return res;
        }

        /// <summary>
        /// Returns equality of vectors.
        /// </summary>
        /// <param name="lhs">First vector.</param>
        /// <param name="rhs">Second vector.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static bool Equals (ref Float4 lhs, ref Float4 rhs) {
            return (lhs.X - rhs.X) * (lhs.X - rhs.X) + (lhs.Y - rhs.Y) * (lhs.Y - rhs.Y) + (lhs.Z - rhs.Z) * (lhs.Z - rhs.Z) + (lhs.W - rhs.W) * (lhs.W - rhs.W) < MathFast.Epsilon * MathFast.Epsilon;
        }

        /// <summary>
        /// Returns linear interpolated vector value between start and end vectors.
        /// </summary>
        /// <param name="lhs">Start vector.</param>
        /// <param name="rhs">End vector.</param>
        /// <param name="t">Factor in range [0f,1f].</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float4 Lerp (ref Float4 lhs, ref Float4 rhs, float t) {
            if (t > 1f) {
                return rhs;
            } else {
                if (t < 0f) {
                    return lhs;
                }
            }
            Float4 res;
            res.X = (rhs.X - lhs.X) * t + lhs.X;
            res.Y = (rhs.Y - lhs.Y) * t + lhs.Y;
            res.Z = (rhs.Z - lhs.Z) * t + lhs.Z;
            res.W = (rhs.W - lhs.W) * t + lhs.W;
            return res;
        }

#if UNITY_5_6_OR_NEWER
        public static implicit operator UnityEngine.Vector4 (Float4 v) {
            UnityEngine.Vector4 res;
            res.x = v.X;
            res.y = v.Y;
            res.z = v.Z;
            res.w = v.W;
            return res;
        }

        public static implicit operator Float4 (UnityEngine.Vector4 v) {
            Float4 res;
            res.X = v.x;
            res.Y = v.y;
            res.Z = v.z;
            res.W = v.w;
            return res;
        }
#endif
    }
}