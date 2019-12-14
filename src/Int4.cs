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
    /// Vector with 4 integer components.
    /// </summary>
    [Serializable]
    [StructLayout (LayoutKind.Sequential)]
    public struct Int4 {
        public int X;
        public int Y;
        public int Z;
        public int W;

        /// <summary>
        /// Returns vector with (0,0,0,0) values.
        /// </summary>
        public static readonly Int4 Zero = new Int4 ();

        /// <summary>
        /// Creates new instance of vector.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public Int4 (int x, int y, int z, int w) {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>
        /// Reverses vector direction in-place.
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
        public void Set (int x, int y, int z, int w) {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

#if DEBUG
        public override string ToString () {
            return string.Format (System.Globalization.CultureInfo.InvariantCulture, "({0}, {1}, {2}, {3})", X, Y, Z, W);
        }
#endif

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Int4 operator + (in Int4 lhs, in Int4 rhs) {
            Int4 res;
            res.X = lhs.X + rhs.X;
            res.Y = lhs.Y + rhs.Y;
            res.Z = lhs.Z + rhs.Z;
            res.W = lhs.W + rhs.W;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Int4 operator - (in Int4 lhs, in Int4 rhs) {
            Int4 res;
            res.X = lhs.X - rhs.X;
            res.Y = lhs.Y - rhs.Y;
            res.Z = lhs.Z - rhs.Z;
            res.W = lhs.W - rhs.W;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Int4 operator * (in Int4 lhs, in Int4 rhs) {
            Int4 res;
            res.X = lhs.X * rhs.X;
            res.Y = lhs.Y * rhs.Y;
            res.Z = lhs.Z * rhs.Z;
            res.W = lhs.W * rhs.W;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Int4 operator * (in Int4 lhs, int rhs) {
            Int4 res;
            res.X = lhs.X * rhs;
            res.Y = lhs.Y * rhs;
            res.Z = lhs.Z * rhs;
            res.W = lhs.W * rhs;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Int4 operator / (in Int4 lhs, int rhs) {
            Int4 res;
            res.X = lhs.X / rhs;
            res.Y = lhs.Y / rhs;
            res.Z = lhs.Z / rhs;
            res.W = lhs.W / rhs;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Int4 operator - (in Int4 lhs) {
            Int4 res;
            res.X = -lhs.X;
            res.Y = -lhs.Y;
            res.Z = -lhs.Z;
            res.W = -lhs.W;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static bool operator == (in Int4 lhs, in Int4 rhs) {
            return lhs.X == rhs.X && lhs.Y == rhs.Y && lhs.Z == rhs.Z && lhs.W == rhs.W;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static bool operator != (in Int4 lhs, in Int4 rhs) {
            return lhs.X != rhs.X || lhs.Y != rhs.Y || lhs.Z != rhs.Z || lhs.W != rhs.W;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode () {
            // ReSharper disable NonReadonlyMemberInGetHashCode
            return X ^ (Y << 2) ^ (Z >> 2) ^ (W >> 1);
            // ReSharper restore NonReadonlyMemberInGetHashCode
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public override bool Equals (object other) {
            if (!(other is Int4)) {
                return false;
            }
            var rhs = (Int4) other;
            return X == rhs.X && Y == rhs.Y && Z == rhs.Z && W == rhs.W;
        }
    }
}