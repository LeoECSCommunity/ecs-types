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
        public Int3 (int x, int y, int z) {
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
        /// Adds new vector inplace.
        /// </summary>
        /// <param name="rhs">New vector.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Add (ref Int3 rhs) {
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
        public void Add (int x, int y, int z) {
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
        public void Sub (ref Int3 rhs) {
            X -= rhs.X;
            Y -= rhs.Y;
            Z -= rhs.Z;
        }
#if DEBUG
        public override string ToString () {
            return string.Format (System.Globalization.CultureInfo.InvariantCulture, "({0}, {1}, {2})", X, Y, Z);
        }
#endif
        /// <summary>
        /// Returns vector with reversed direction.
        /// </summary>
        /// <param name="lhs">Vector.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Int3 Neg (ref Int3 lhs) {
            Int3 res;
            res.X = -lhs.X;
            res.Y = -lhs.Y;
            res.Z = -lhs.Z;
            return res;
        }

        /// <summary>
        /// Returns sum of 2 vectors.
        /// </summary>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Int3 Add (ref Int3 lhs, ref Int3 rhs) {
            Int3 res;
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
        public static Int3 Add (ref Int3 lhs, int x, int y, int z) {
            Int3 res;
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
        public static Int3 Sub (ref Int3 lhs, ref Int3 rhs) {
            Int3 res;
            res.X = lhs.X - rhs.X;
            res.Y = lhs.Y - rhs.Y;
            res.Z = lhs.Z - rhs.Z;
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
        public static bool Equals (ref Int3 lhs, ref Int3 rhs) {
            return lhs.X == rhs.X && lhs.Y == rhs.Y && lhs.Z == rhs.Z;
        }

#if UNITY_5_6_OR_NEWER
        public static implicit operator UnityEngine.Vector3Int (Int3 v) {
            return new UnityEngine.Vector3Int (v.X, v.Y, v.Z);
        }

        public static implicit operator Int3 (UnityEngine.Vector3Int v) {
            Int3 res;
            res.X = v.x;
            res.Y = v.y;
            res.Z = v.y;
            return res;
        }
#endif
    }
}