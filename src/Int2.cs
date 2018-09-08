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
        public Int2 (int x, int y) {
            X = x;
            Y = y;
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
        }

        /// <summary>
        /// Adds new vector inplace.
        /// </summary>
        /// <param name="rhs">New vector.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Add (ref Int2 rhs) {
            X += rhs.X;
            Y += rhs.Y;
        }

        /// <summary>
        /// Adds offsets inplace.
        /// </summary>
        /// <param name="x">X offset.</param>
        /// <param name="y">Y offset.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Add (int x, int y) {
            X += x;
            Y += y;
        }

        /// <summary>
        /// Substracts new vector inplace.
        /// </summary>
        /// <param name="rhs">New vector.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Sub (ref Int2 rhs) {
            X -= rhs.X;
            Y -= rhs.Y;
        }
#if DEBUG
        public override string ToString () {
            return string.Format (System.Globalization.CultureInfo.InvariantCulture, "({0}, {1})", X, Y);
        }
#endif
        /// <summary>
        /// Returns vector with reversed direction.
        /// </summary>
        /// <param name="lhs">Vector.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Int2 Neg (ref Int2 lhs) {
            Int2 res;
            res.X = -lhs.X;
            res.Y = -lhs.Y;
            return res;
        }

        /// <summary>
        /// Returns sum of 2 vectors.
        /// </summary>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Int2 Add (ref Int2 lhs, ref Int2 rhs) {
            Int2 res;
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
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Int2 Add (ref Int2 lhs, int x, int y) {
            Int2 res;
            res.X = lhs.X + x;
            res.Y = lhs.Y + y;
            return res;
        }

        /// <summary>
        /// Returns substract of 2 vectors.
        /// </summary>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Int2 Sub (ref Int2 lhs, ref Int2 rhs) {
            Int2 res;
            res.X = lhs.X - rhs.X;
            res.Y = lhs.Y - rhs.Y;
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
        public static bool Equals (ref Int2 lhs, ref Int2 rhs) {
            return lhs.X == rhs.X && lhs.Y == rhs.Y;
        }

#if UNITY_5_6_OR_NEWER
        public static implicit operator UnityEngine.Vector2Int (Int2 v) {
            return new UnityEngine.Vector2Int (v.X, v.Y);
        }

        public static implicit operator Int2 (UnityEngine.Vector2Int v) {
            Int2 res;
            res.X = v.x;
            res.Y = v.y;
            return res;
        }
#endif
    }
}