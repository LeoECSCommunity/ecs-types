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
    /// Vector with 2 float components.
    /// </summary>
    [Serializable]
    [StructLayout (LayoutKind.Sequential)]
    public struct Float2 {
        public float X;

        public float Y;

        /// <summary>
        /// Creates new instance of vector.
        /// </summary>
        public Float2 (float x, float y) {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Reverses vector direction inplace.
        /// </summary>
#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Neg () {
            X = -X;
            Y = -Y;
        }

        /// <summary>
        /// Normalizes vector inplace.
        /// </summary>
#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Normalize () {
            var invMagnitude = 1f / (float) Math.Sqrt (X * X + Y * Y);
            X *= invMagnitude;
            Y *= invMagnitude;
        }

        /// <summary>
        /// Adds new vector inplace.
        /// </summary>
        /// <param name="rhs">New vector.</param>
#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Add (ref Float2 rhs) {
            X += rhs.X;
            Y += rhs.Y;
        }

        /// <summary>
        /// Adds offsets inplace.
        /// </summary>
        /// <param name="x">X offset.</param>
        /// <param name="y">Y offset.</param>
#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Add (float x, float y) {
            X += x;
            Y += y;
        }

        /// <summary>
        /// Substracts new vector inplace.
        /// </summary>
        /// <param name="rhs">New vector.</param>
#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Sub (ref Float2 rhs) {
            X -= rhs.X;
            Y -= rhs.Y;
        }

        /// <summary>
        /// Scales (multipies) vector with factors inplace.
        /// </summary>
        /// <param name="x">X factor.</param>
        /// <param name="y">Y factor.</param>
#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Scale (float x, float y) {
            X *= x;
            Y *= y;
        }

        /// <summary>
        /// Returns square magnitude of vector.
        /// </summary>
        /// <param name="lhs">Vector.</param>
#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static float SqrMagnitude (ref Float2 lhs) {
            return lhs.X * lhs.X + lhs.Y * lhs.Y;
        }

        /// <summary>
        /// Returns magnitude of vector.
        /// </summary>
        /// <param name="lhs">Vector.</param>
#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static float Magnitude (ref Float2 lhs) {
            return (float) Math.Sqrt (lhs.X * lhs.X + lhs.Y * lhs.Y);
        }

        /// <summary>
        /// Returns vector with reversed direction.
        /// </summary>
        /// <param name="lhs">Vector.</param>
#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float2 Neg (ref Float2 lhs) {
            Float2 res;
            res.X = -lhs.X;
            res.Y = -lhs.Y;
            return res;
        }

        /// <summary>
        /// Returns sum of 2 vectors.
        /// </summary>
#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float2 Add (ref Float2 lhs, ref Float2 rhs) {
            Float2 res;
            res.X = lhs.X + rhs.X;
            res.Y = lhs.Y + rhs.Y;
            return res;
        }

        /// <summary>
        /// Returns sum of vector and offsets.
        /// </summary>
        /// <param name="lhs">Vector.</param>
        /// <param name="x">X offset.</param>
        /// <param name="y">Y offset.</param>
#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float2 Add (ref Float2 lhs, float x, float y) {
            Float2 res;
            res.X = lhs.X + x;
            res.Y = lhs.Y + y;
            return res;
        }

        /// <summary>
        /// Returns substract of 2 vectors.
        /// </summary>
#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float2 Sub (ref Float2 lhs, ref Float2 rhs) {
            Float2 res;
            res.X = lhs.X - rhs.X;
            res.Y = lhs.Y - rhs.Y;
            return res;
        }

        /// <summary>
        /// Returns scaled (multipled) vector with factors.
        /// </summary>
        /// <param name="lhs">Vector.</param>
        /// <param name="x">X factor.</param>
        /// <param name="y">Y factor.</param>
#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float2 Scale (ref Float2 lhs, float x, float y) {
            Float2 res;
            res.X = lhs.X * x;
            res.Y = lhs.Y * y;
            return res;
        }

        /// <summary>
        /// Returns normalized version of vector.
        /// </summary>
        /// <param name="rhs">Vector.</param>
#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float2 Normalize (ref Float2 rhs) {
            Float2 res;
            var invMagnitude = 1f / (float) Math.Sqrt (rhs.X * rhs.X + rhs.Y * rhs.Y);
            res.X = rhs.X * invMagnitude;
            res.Y = rhs.Y * invMagnitude;
            return res;
        }

        /// <summary>
        /// Returns equality of vectors.
        /// </summary>
        /// <param name="lhs">First vector.</param>
        /// <param name="rhs">Second vector.</param>
#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static bool Equals (ref Float2 lhs, ref Float2 rhs) {
            return (lhs.X - rhs.X) * (lhs.X - rhs.X) + (lhs.Y - rhs.Y) * (lhs.Y - rhs.Y) < float.Epsilon * float.Epsilon;
        }

        /// <summary>
        /// Returns linear interpolated vector value between start and end vectors.
        /// </summary>
        /// <param name="lhs">Start vector.</param>
        /// <param name="rhs">End vector.</param>
        /// <param name="t">Factor in range [0f,1f].</param>
#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float2 Lerp (ref Float2 lhs, ref Float2 rhs, float t) {
            if (t > 1f) {
                return rhs;
            } else {
                if (t < 0f) {
                    return lhs;
                }
            }
            Float2 res;
            res.X = (rhs.X - lhs.X) * t + lhs.X;
            res.Y = (rhs.Y - lhs.Y) * t + lhs.Y;
            return res;
        }
    }
}