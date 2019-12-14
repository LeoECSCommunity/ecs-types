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
        /// Returns vector with (-1,0,0) values.
        /// </summary>
        public static readonly Float3 Left = new Float3 (-1f, 0f, 0f);

        /// <summary>
        /// Returns vector with (0,1,0) values.
        /// </summary>
        public static readonly Float3 Up = new Float3 (0f, 1f, 0f);

        /// <summary>
        /// Returns vector with (0,-1,0) values.
        /// </summary>
        public static readonly Float3 Down = new Float3 (0f, -1f, 0f);

        /// <summary>
        /// Returns vector with (0,0,1) values.
        /// </summary>
        public static readonly Float3 Forward = new Float3 (0f, 0f, 1f);

        /// <summary>
        /// Returns vector with (0,0,-1) values.
        /// </summary>
        public static readonly Float3 Back = new Float3 (0f, 0f, -1f);

        /// <summary>
        /// Creates new instance of vector.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public Float3 (float x, float y, float z) {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Reverses vector direction in-place.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public void Neg () {
            X = -X;
            Y = -Y;
            Z = -Z;
        }

        /// <summary>
        /// Sets vector component values.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public void Set (float x, float y, float z) {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Normalizes vector in-place.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public void Normalize () {
            var v = X * X + Y * Y + Z * Z;
            if (v > MathFast.Epsilon) {
                v = 1f / (float) Math.Sqrt (v);
                X *= v;
                Y *= v;
                Z *= v;
            }
        }

#if DEBUG
        public override string ToString () {
            return string.Format (System.Globalization.CultureInfo.InvariantCulture, "({0:F5}, {1:F5}, {2:F5})", X, Y, Z);
        }
#endif
        /// <summary>
        /// Returns dot product of vectors.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static float Dot (in Float3 lhs, in Float3 rhs) {
            return lhs.X * rhs.X + lhs.Y * rhs.Y + lhs.Z * rhs.Z;
        }

        /// <summary>
        /// Returns cross product of vectors.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Float3 Cross (in Float3 lhs, in Float3 rhs) {
            Float3 res;
            res.X = lhs.Y * rhs.Z - lhs.Z * rhs.Y;
            res.Y = lhs.Z * rhs.X - lhs.X * rhs.Z;
            res.Z = lhs.X * rhs.Y - lhs.Y * rhs.X;
            return res;
        }

        /// <summary>
        /// Returns vector with min values from 2 vectors.
        /// </summary>
        /// <param name="lhs">First vector.</param>
        /// <param name="rhs">Second vector.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Float3 Min (in Float3 lhs, in Float3 rhs) {
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
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Float3 Max (in Float3 lhs, in Float3 rhs) {
            Float3 result;
            result.X = lhs.X >= rhs.X ? lhs.X : rhs.X;
            result.Y = lhs.Y >= rhs.Y ? lhs.Y : rhs.Y;
            result.Z = lhs.Z >= rhs.Z ? lhs.Z : rhs.Z;
            return result;
        }

        /// <summary>
        /// Returns linear interpolated vector value between start and end vectors.
        /// </summary>
        /// <param name="lhs">Start vector.</param>
        /// <param name="rhs">End vector.</param>
        /// <param name="t">Factor in range [0f,1f].</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Float3 Lerp (in Float3 lhs, in Float3 rhs, float t) {
            if (t > 1f) {
                return rhs;
            }
            if (t < 0f) {
                return lhs;
            }
            Float3 res;
            res.X = (rhs.X - lhs.X) * t + lhs.X;
            res.Y = (rhs.Y - lhs.Y) * t + lhs.Y;
            res.Z = (rhs.Z - lhs.Z) * t + lhs.Z;
            return res;
        }

        /// <summary>
        /// Returns square magnitude of vector.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public float GetSqrMagnitude () {
            return X * X + Y * Y + Z * Z;
        }

        /// <summary>
        /// Returns magnitude of vector.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public float GetMagnitude () {
            return (float) Math.Sqrt (X * X + Y * Y + Z * Z);
        }

        /// <summary>
        /// Returns normalized version of vector.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public Float3 GetNormalized () {
            Float3 res;
            var v = X * X + Y * Y + Z * Z;
            v = v > MathFast.Epsilon ? 1f / (float) Math.Sqrt (v) : 0f;
            res.X = X * v;
            res.Y = Y * v;
            res.Z = Z * v;
            return res;
        }

        /// <summary>
        /// Reflects normalized vector from plane with normal.
        /// </summary>
        /// <param name="direction">Direction.</param>
        /// <param name="normal">Normal of plane.</param>
        public static Float3 Reflect (in Float3 direction, in Float3 normal) {
            var dist = -2f * (normal.X * direction.X + normal.Y * direction.Y);
            Float3 res;
            res.X = normal.X * dist + direction.X;
            res.Y = normal.Y * dist + direction.Y;
            res.Z = normal.Z * dist + direction.Z;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Float3 operator + (in Float3 lhs, in Float3 rhs) {
            Float3 res;
            res.X = lhs.X + rhs.X;
            res.Y = lhs.Y + rhs.Y;
            res.Z = lhs.Z + rhs.Z;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Float3 operator - (in Float3 lhs, in Float3 rhs) {
            Float3 res;
            res.X = lhs.X - rhs.X;
            res.Y = lhs.Y - rhs.Y;
            res.Z = lhs.Z - rhs.Z;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Float3 operator * (in Float3 lhs, in Float3 rhs) {
            Float3 res;
            res.X = lhs.X * rhs.X;
            res.Y = lhs.Y * rhs.Y;
            res.Z = lhs.Z * rhs.Z;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Float3 operator * (in Float3 lhs, float rhs) {
            Float3 res;
            res.X = lhs.X * rhs;
            res.Y = lhs.Y * rhs;
            res.Z = lhs.Z * rhs;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Float3 operator / (in Float3 lhs, float rhs) {
            Float3 res;
            rhs = 1f / rhs;
            res.X = lhs.X * rhs;
            res.Y = lhs.Y * rhs;
            res.Z = lhs.Z * rhs;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Float3 operator - (in Float3 lhs) {
            Float3 res;
            res.X = -lhs.X;
            res.Y = -lhs.Y;
            res.Z = -lhs.Z;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static bool operator == (in Float3 lhs, in Float3 rhs) {
            return (
                       (lhs.X - rhs.X) * (lhs.X - rhs.X) +
                       (lhs.Y - rhs.Y) * (lhs.Y - rhs.Y) +
                       (lhs.Z - rhs.Z) * (lhs.Z - rhs.Z)) < MathFast.Epsilon;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static bool operator != (in Float3 lhs, in Float3 rhs) {
            return (
                       (lhs.X - rhs.X) * (lhs.X - rhs.X) +
                       (lhs.Y - rhs.Y) * (lhs.Y - rhs.Y) +
                       (lhs.Z - rhs.Z) * (lhs.Z - rhs.Z)) >= MathFast.Epsilon;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode () {
            // ReSharper disable NonReadonlyMemberInGetHashCode
            return X.GetHashCode () ^ (Y.GetHashCode () << 2) ^ (Z.GetHashCode () >> 2);
            // ReSharper restore NonReadonlyMemberInGetHashCode
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public override bool Equals (object other) {
            if (!(other is Float3)) {
                return false;
            }
            var rhs = (Float3) other;
            return (
                       (X - rhs.X) * (X - rhs.X) +
                       (Y - rhs.Y) * (Y - rhs.Y) +
                       (Z - rhs.Z) * (Z - rhs.Z)) < MathFast.Epsilon;
        }

#if UNITY_2018_3_OR_NEWER
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static implicit operator UnityEngine.Vector3 (in Float3 lhs) {
            UnityEngine.Vector3 res;
            res.x = lhs.X;
            res.y = lhs.Y;
            res.z = lhs.Z;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static implicit operator Float3 (in UnityEngine.Vector3 lhs) {
            Float3 res;
            res.X = lhs.x;
            res.Y = lhs.y;
            res.Z = lhs.z;
            return res;
        }
#endif
    }
}