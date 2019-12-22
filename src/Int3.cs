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
    /// Vector with 3 integer components.
    /// </summary>
    [Serializable]
    [StructLayout (LayoutKind.Sequential)]
    public struct Int3 {
        public int X;
        public int Y;
        public int Z;

        /// <summary>
        /// Returns vector with (0,0,0) values.
        /// </summary>
        public static readonly Int3 Zero = new Int3 ();

        /// <summary>
        /// Creates new instance of vector.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public Int3 (int x, int y, int z) {
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
        public void Set (int x, int y, int z) {
            X = x;
            Y = y;
            Z = z;
        }

#if DEBUG
        public override string ToString () {
            return string.Format (System.Globalization.CultureInfo.InvariantCulture, "({0}, {1}, {2})", X, Y, Z);
        }
#endif

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Int3 operator + (in Int3 lhs, in Int3 rhs) {
            Int3 res;
            res.X = lhs.X + rhs.X;
            res.Y = lhs.Y + rhs.Y;
            res.Z = lhs.Z + rhs.Z;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Int3 operator - (in Int3 lhs, in Int3 rhs) {
            Int3 res;
            res.X = lhs.X - rhs.X;
            res.Y = lhs.Y - rhs.Y;
            res.Z = lhs.Z - rhs.Z;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Int3 operator * (in Int3 lhs, in Int3 rhs) {
            Int3 res;
            res.X = lhs.X * rhs.X;
            res.Y = lhs.Y * rhs.Y;
            res.Z = lhs.Z * rhs.Z;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Int3 operator * (in Int3 lhs, int rhs) {
            Int3 res;
            res.X = lhs.X * rhs;
            res.Y = lhs.Y * rhs;
            res.Z = lhs.Z * rhs;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Int3 operator / (in Int3 lhs, int rhs) {
            Int3 res;
            res.X = lhs.X / rhs;
            res.Y = lhs.Y / rhs;
            res.Z = lhs.Z / rhs;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Int3 operator - (in Int3 lhs) {
            Int3 res;
            res.X = -lhs.X;
            res.Y = -lhs.Y;
            res.Z = -lhs.Z;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static bool operator == (in Int3 lhs, in Int3 rhs) {
            return lhs.X == rhs.X && lhs.Y == rhs.Y && lhs.Z == rhs.Z;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static bool operator != (in Int3 lhs, in Int3 rhs) {
            return lhs.X != rhs.X || lhs.Y != rhs.Y || lhs.Z != rhs.Z;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode () {
            // ReSharper disable NonReadonlyMemberInGetHashCode
            return X ^ (Y << 2) ^ (Z >> 2);
            // ReSharper restore NonReadonlyMemberInGetHashCode
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public override bool Equals (object other) {
            if (!(other is Int3)) {
                return false;
            }
            var rhs = (Int3) other;
            return X == rhs.X && Y == rhs.Y && Z == rhs.Z;
        }

#if UNITY_2018_3_OR_NEWER
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static implicit operator UnityEngine.Vector3Int (in Int3 v) {
            return new UnityEngine.Vector3Int (v.X, v.Y, v.Z);
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static implicit operator Int3 (in UnityEngine.Vector3Int v) {
            Int3 res;
            res.X = v.x;
            res.Y = v.y;
            res.Z = v.z;
            return res;
        }
#endif
    }
}