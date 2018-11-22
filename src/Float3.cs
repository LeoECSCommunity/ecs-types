// ----------------------------------------------------------------------------
// The MIT License
// Types for Entity Component System framework https://github.com/Leopotam/ecs
// Copyright (c) 2017-2018 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;

#if NET_4_6 || NET_STANDARD_2_0
using System.Runtime.CompilerServices;
#endif

namespace Leopotam.Ecs.Types {
    /// <summary>
    /// Vector with 3 float components.
    /// </summary>
    [Serializable]
    [StructLayout (LayoutKind.Sequential)]
    public struct Float3 {
        public float X;
        public float Y;
        public float Z;

        /// <summary>
        /// Returns vector with (0,0,0) values.
        /// </summary>
        public static readonly Float3 Zero = new Float3 ();

        /// <summary>
        /// Returns vector with (1,1,1) values.
        /// </summary>
        public static readonly Float3 One = new Float3 (1f, 1f, 1f);

        /// <summary>
        /// Returns vector with (1,0,0) values.
        /// </summary>
        public static readonly Float3 Right = new Float3 (1f, 0f, 0f);

        /// <summary>
        /// Returns vector with (0,1,0) values.
        /// </summary>
        public static readonly Float3 Up = new Float3 (0f, 1f, 0f);

        /// <summary>
        /// Returns vector with (0,0,1) values.
        /// </summary>
        public static readonly Float3 Forward = new Float3 (0f, 0f, 1f);

        /// <summary>
        /// Creates new instance of vector.
        /// </summary>
        public Float3 (float x, float y, float z) {
            X = x;
            Y = y;
            Z = z;
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
        }

        /// <summary>
        /// Sets components to min values from current and another one vectors.
        /// </summary>
        /// <param name="lhs">Another vector.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Min (ref Float3 lhs) {
            X = X <= lhs.X ? X : lhs.X;
            Y = Y <= lhs.Y ? Y : lhs.Y;
            Z = Z <= lhs.Z ? Z : lhs.Z;
        }

        /// <summary>
        /// Sets components to max values from current and another one vectors.
        /// </summary>
        /// <param name="lhs">Another vector.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Max (ref Float3 lhs) {
            X = X >= lhs.X ? X : lhs.X;
            Y = Y >= lhs.Y ? Y : lhs.Y;
            Z = Z >= lhs.Z ? Z : lhs.Z;
        }

        /// <summary>
        /// Sets vector component values.
        /// </summary>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Set (float x, float y, float z) {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Normalizes vector inplace.
        /// </summary>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Normalize () {
            var invMagnitude = 1f / (float) Math.Sqrt (X * X + Y * Y + Z * Z);
            X *= invMagnitude;
            Y *= invMagnitude;
            Z *= invMagnitude;
        }

        /// <summary>
        /// Adds new vector inplace.
        /// </summary>
        /// <param name="rhs">New vector.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Add (ref Float3 rhs) {
            X += rhs.X;
            Y += rhs.Y;
            Z += rhs.Z;
        }

        /// <summary>
        /// Adds offsets inplace.
        /// </summary>
        /// <param name="x">X offset.</param>
        /// <param name="y">Y offset.</param>
        /// <param name="z">Z offset.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Add (float x, float y, float z) {
            X += x;
            Y += y;
            Z += z;
        }

        /// <summary>
        /// Substracts new vector inplace.
        /// </summary>
        /// <param name="rhs">New vector.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Sub (ref Float3 rhs) {
            X -= rhs.X;
            Y -= rhs.Y;
            Z -= rhs.Z;
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
        }
#if DEBUG
        public override string ToString () {
            return string.Format (System.Globalization.CultureInfo.InvariantCulture, "({0:F5}, {1:F5}, {2:F5})", X, Y, Z);
        }
#endif
        /// <summary>
        /// Returns square magnitude of vector.
        /// </summary>
        /// <param name="lhs">Vector.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static float SqrMagnitude (ref Float3 lhs) {
            return lhs.X * lhs.X + lhs.Y * lhs.Y + lhs.Z * lhs.Z;
        }

        /// <summary>
        /// Returns magnitude of vector.
        /// </summary>
        /// <param name="lhs">Vector.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static float Magnitude (ref Float3 lhs) {
            return (float) Math.Sqrt (lhs.X * lhs.X + lhs.Y * lhs.Y + lhs.Z * lhs.Z);
        }

        /// <summary>
        /// Returns dot product of vectors.
        /// </summary>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static float Dot (ref Float3 lhs, ref Float3 rhs) {
            return lhs.X * rhs.X + lhs.Y * rhs.Y + lhs.Z * rhs.Z;
        }

        /// <summary>
        /// Returns cross product of vectors.
        /// </summary>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float3 Cross (ref Float3 lhs, ref Float3 rhs) {
            Float3 res;
            res.X = lhs.Y * rhs.Z - lhs.Z * rhs.Y;
            res.Y = lhs.Z * rhs.X - lhs.X * rhs.Z;
            res.Z = lhs.X * rhs.Y - lhs.Y * rhs.X;
            return res;
        }

        /// <summary>
        /// Returns vector with reversed direction.
        /// </summary>
        /// <param name="lhs">Vector.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float3 Neg (ref Float3 lhs) {
            Float3 res;
            res.X = -lhs.X;
            res.Y = -lhs.Y;
            res.Z = -lhs.Z;
            return res;
        }

        /// <summary>
        /// Returns vector with min values from 2 vectors.
        /// </summary>
        /// <param name="lhs">First vector.</param>
        /// <param name="rhs">Second vector.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float3 Min (ref Float3 lhs, ref Float3 rhs) {
            Float3 result;
            result.X = lhs.X <= rhs.X ? lhs.X : rhs.X;
            result.Y = lhs.Y <= rhs.Y ? lhs.Y : rhs.Y;
            result.Z = lhs.Z <= rhs.Z ? lhs.Z : rhs.Z;
            return result;
        }

        /// <summary>
        /// Returns vector with max values from 2 vectors.
        /// </summary>
        /// <param name="lhs">First vector.</param>
        /// <param name="rhs">Second vector.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float3 Max (ref Float3 lhs, ref Float3 rhs) {
            Float3 result;
            result.X = lhs.X >= rhs.X ? lhs.X : rhs.X;
            result.Y = lhs.Y >= rhs.Y ? lhs.Y : rhs.Y;
            result.Z = lhs.Z >= rhs.Z ? lhs.Z : rhs.Z;
            return result;
        }

        /// <summary>
        /// Returns sum of 2 vectors.
        /// </summary>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float3 Add (ref Float3 lhs, ref Float3 rhs) {
            Float3 res;
            res.X = lhs.X + rhs.X;
            res.Y = lhs.Y + rhs.Y;
            res.Z = lhs.Z + rhs.Z;
            return res;
        }

        /// <summary>
        /// Returns sum of vector and offsets.
        /// </summary>
        /// <param name="lhs">Vector.</param>
        /// <param name="x">X offset.</param>
        /// <param name="y">Y offset.</param>
        /// <param name="z">Z offset.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float3 Add (ref Float3 lhs, float x, float y, float z) {
            Float3 res;
            res.X = lhs.X + x;
            res.Y = lhs.Y + y;
            res.Z = lhs.Z + z;
            return res;
        }

        /// <summary>
        /// Returns substract of 2 vectors.
        /// </summary>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float3 Sub (ref Float3 lhs, ref Float3 rhs) {
            Float3 res;
            res.X = lhs.X - rhs.X;
            res.Y = lhs.Y - rhs.Y;
            res.Z = lhs.Z - rhs.Z;
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
        public static Float3 Scale (ref Float3 lhs, float scale) {
            Float3 res;
            res.X = lhs.X * scale;
            res.Y = lhs.Y * scale;
            res.Z = lhs.Z * scale;
            return res;
        }

        /// <summary>
        /// Returns normalized version of vector.
        /// </summary>
        /// <param name="rhs">Vector.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float3 Normalize (ref Float3 rhs) {
            Float3 res;
            var invMagnitude = 1f / (float) Math.Sqrt (rhs.X * rhs.X + rhs.Y * rhs.Y + rhs.Z * rhs.Z);
            res.X = rhs.X * invMagnitude;
            res.Y = rhs.Y * invMagnitude;
            res.Z = rhs.Z * invMagnitude;
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
        public static bool Equals (ref Float3 lhs, ref Float3 rhs) {
            return (lhs.X - rhs.X) * (lhs.X - rhs.X) + (lhs.Y - rhs.Y) * (lhs.Y - rhs.Y) + (lhs.Z - rhs.Z) * (lhs.Z - rhs.Z) < MathFast.Epsilon * MathFast.Epsilon;
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
        public static Float3 Lerp (ref Float3 lhs, ref Float3 rhs, float t) {
            if (t > 1f) {
                return rhs;
            } else {
                if (t < 0f) {
                    return lhs;
                }
            }
            Float3 res;
            res.X = (rhs.X - lhs.X) * t + lhs.X;
            res.Y = (rhs.Y - lhs.Y) * t + lhs.Y;
            res.Z = (rhs.Z - lhs.Z) * t + lhs.Z;
            return res;
        }

#if UNITY_5_6_OR_NEWER
        public static implicit operator UnityEngine.Vector3 (Float3 v) {
            UnityEngine.Vector3 res;
            res.x = v.X;
            res.y = v.Y;
            res.z = v.Z;
            return res;
        }

        public static implicit operator Float3 (UnityEngine.Vector3 v) {
            Float3 res;
            res.X = v.x;
            res.Y = v.y;
            res.Z = v.z;
            return res;
        }
#endif
    }
}