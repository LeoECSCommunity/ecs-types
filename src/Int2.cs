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
    /// Vector with 2 integer components.
    /// </summary>
    [Serializable]
    [StructLayout (LayoutKind.Sequential)]
    public struct Int2 {
        public int X;
        public int Y;

        /// <summary>
        /// Returns vector with (0,0) values.
        /// </summary>
        public static readonly Int2 Zero = new Int2 ();

        /// <summary>
        /// Creates new instance of vector.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public Int2 (int x, int y) {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Reverses vector direction in-place.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public void Neg () {
            X = -X;
            Y = -Y;
        }

        /// <summary>
        /// Sets vector component values.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public void Set (int x, int y) {
            X = x;
            Y = y;
        }

#if DEBUG
        public override string ToString () {
            return string.Format (System.Globalization.CultureInfo.InvariantCulture, "({0}, {1})", X, Y);
        }
#endif

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Int2 operator + (in Int2 lhs, in Int2 rhs) {
            Int2 res;
            res.X = lhs.X + rhs.X;
            res.Y = lhs.Y + rhs.Y;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Int2 operator - (in Int2 lhs, in Int2 rhs) {
            Int2 res;
            res.X = lhs.X - rhs.X;
            res.Y = lhs.Y - rhs.Y;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Int2 operator * (in Int2 lhs, in Int2 rhs) {
            Int2 res;
            res.X = lhs.X * rhs.X;
            res.Y = lhs.Y * rhs.Y;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Int2 operator * (in Int2 lhs, int rhs) {
            Int2 res;
            res.X = lhs.X * rhs;
            res.Y = lhs.Y * rhs;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Int2 operator / (in Int2 lhs, int rhs) {
            Int2 res;
            res.X = lhs.X / rhs;
            res.Y = lhs.Y / rhs;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Int2 operator - (in Int2 lhs) {
            Int2 res;
            res.X = -lhs.X;
            res.Y = -lhs.Y;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static bool operator == (in Int2 lhs, in Int2 rhs) {
            return lhs.X == rhs.X && lhs.Y == rhs.Y;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static bool operator != (in Int2 lhs, in Int2 rhs) {
            return lhs.X != rhs.X || lhs.Y != rhs.Y;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode () {
            // ReSharper disable NonReadonlyMemberInGetHashCode
            return X ^ (Y << 2);
            // ReSharper restore NonReadonlyMemberInGetHashCode
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public override bool Equals (object other) {
            if (!(other is Int2)) {
                return false;
            }
            var rhs = (Int2) other;
            return X == rhs.X && Y == rhs.Y;
        }

#if UNITY_2018_3_OR_NEWER
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static implicit operator UnityEngine.Vector2Int (in Int2 v) {
            return new UnityEngine.Vector2Int (v.X, v.Y);
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static implicit operator Int2 (in UnityEngine.Vector2Int v) {
            Int2 res;
            res.X = v.x;
            res.Y = v.y;
            return res;
        }
#endif
    }
}