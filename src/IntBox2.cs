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
    /// 2D box with integer components.
    /// </summary>
    [Serializable]
    [StructLayout (LayoutKind.Sequential)]
    public struct IntBox2 {
        public Int2 Min;
        public Int2 Max;

        /// <summary>
        /// Creates new instance of vector.
        /// </summary>
        public IntBox2 (Int2 min, Int2 max) {
            Min = min;
            Max = max;
        }

        /// <summary>
        /// Creates new instance of vector.
        /// </summary>
        public IntBox2 (ref Int2 min, ref Int2 max) {
            Min = min;
            Max = max;
        }

        /// <summary>
        /// Validates box bounds.
        /// </summary>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Validate () {
            if (Min.X > Max.X) {
                var t = Min.X;
                Min.X = Max.X;
                Max.X = t;
            }
            if (Min.Y > Max.Y) {
                var t = Min.Y;
                Min.Y = Max.Y;
                Max.Y = t;
            }
        }

        /// <summary>
        /// Joins another box to current one. Both boxes should be valid before operation!
        /// </summary>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Join (ref IntBox2 rhs) {
            if (rhs.Min.X < Min.X) {
                Min.X = rhs.Min.X;
            }
            if (rhs.Min.Y < Min.Y) {
                Min.Y = rhs.Min.Y;
            }
            if (rhs.Max.X > Max.X) {
                Max.X = rhs.Max.X;
            }
            if (rhs.Max.Y > Max.Y) {
                Max.Y = rhs.Max.Y;
            }
        }

        /// <summary>
        /// Extends box to include X,Y point. Box should be valid before operation!
        /// </summary>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Join (int x, int y) {
            if (x < Min.X) {
                Min.X = x;
            }
            if (y < Min.Y) {
                Min.Y = y;
            }
            if (x > Max.X) {
                Max.X = x;
            }
            if (y > Max.Y) {
                Max.Y = y;
            }
        }

        /// <summary>
        /// Extends box to include point. Box should be valid before operation!
        /// </summary>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Join (ref Int2 rhs) {
            if (rhs.X < Min.X) {
                Min.X = rhs.X;
            }
            if (rhs.Y < Min.Y) {
                Min.Y = rhs.Y;
            }
            if (rhs.X > Max.X) {
                Max.X = rhs.X;
            }
            if (rhs.Y > Max.Y) {
                Max.Y = rhs.Y;
            }
        }

#if DEBUG
        public override string ToString () {
            return string.Format (System.Globalization.CultureInfo.InvariantCulture, "[Min: ({0}, {1}), Max: ({2}, {3})]", Min.X, Min.Y, Max.X, Max.Y);
        }
#endif

        /// <summary>
        /// Validates box bounds.
        /// </summary>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static IntBox2 Validate (ref IntBox2 lhs) {
            IntBox2 res;
            if (lhs.Min.X > lhs.Max.X) {
                res.Min.X = lhs.Max.X;
                res.Max.X = lhs.Min.X;
            } else {
                res.Min.X = lhs.Min.X;
                res.Max.X = lhs.Max.X;
            }
            if (lhs.Min.Y > lhs.Max.Y) {
                res.Min.Y = lhs.Max.Y;
                res.Max.Y = lhs.Min.Y;
            } else {
                res.Min.Y = lhs.Min.Y;
                res.Max.Y = lhs.Max.Y;
            }
            return res;
        }

        /// <summary>
        /// Joins boxes. Both boxes should be valid before operation!
        /// </summary>
        /// <param name="lhs">First box.</param>
        /// <param name="rhs">Second box.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static IntBox2 Join (ref IntBox2 lhs, ref IntBox2 rhs) {
            IntBox2 res;
            res.Min.X = lhs.Min.X < rhs.Min.X ? lhs.Min.X : rhs.Min.X;
            res.Min.Y = lhs.Min.Y < rhs.Min.Y ? lhs.Min.Y : rhs.Min.Y;
            res.Max.X = lhs.Max.X > rhs.Max.X ? lhs.Max.X : rhs.Max.X;
            res.Max.Y = lhs.Max.Y > rhs.Max.Y ? lhs.Max.Y : rhs.Max.Y;
            return res;
        }

        /// <summary>
        /// Returns box that contains point X,Y. Box should be valid before operation!
        /// </summary>
        /// <param name="lhs">Box.</param>
        /// <param name="x">X coord.</param>
        /// <param name="y">Y coord.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static IntBox2 Join (ref IntBox2 lhs, int x, int y) {
            IntBox2 res;
            res.Min.X = lhs.Min.X < x ? lhs.Min.X : x;
            res.Min.Y = lhs.Min.Y < y ? lhs.Min.Y : y;
            res.Max.X = lhs.Max.X > x ? lhs.Max.X : x;
            res.Max.Y = lhs.Max.Y > y ? lhs.Max.Y : y;
            return res;
        }

        /// <summary>
        /// Returns box that contains point X,Y. Box should be valid before operation!
        /// </summary>
        /// <param name="lhs">Box.</param>
        /// <param name="rhs">Point to include.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static IntBox2 Join (ref IntBox2 lhs, ref Int2 rhs) {
            IntBox2 res;
            res.Min.X = lhs.Min.X < rhs.X ? lhs.Min.X : rhs.X;
            res.Min.Y = lhs.Min.Y < rhs.Y ? lhs.Min.Y : rhs.Y;
            res.Max.X = lhs.Max.X > rhs.X ? lhs.Max.X : rhs.X;
            res.Max.Y = lhs.Max.Y > rhs.Y ? lhs.Max.Y : rhs.Y;
            return res;
        }

        /// <summary>
        /// Gets width of box. Box should be valid before operation!
        /// </summary>
        /// <param name="lhs">Box.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static int GetWidth (ref IntBox2 lhs) {
            return lhs.Max.X - lhs.Min.X;
        }

        /// <summary>
        /// Gets height of box. Box should be valid before operation!
        /// </summary>
        /// <param name="lhs">Box.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static int GetHeight (ref IntBox2 lhs) {
            return lhs.Max.Y - lhs.Min.Y;
        }

        /// <summary>
        /// Is box contains point X,Y. Box should be valid before operation!
        /// </summary>
        /// <param name="lhs">Box.</param>
        /// <param name="rhs">Point to check.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static bool Contains (ref IntBox2 lhs, int x, int y) {
            return x >= lhs.Min.X && x <= lhs.Max.X && y >= lhs.Min.Y && y <= lhs.Max.Y;
        }

        /// <summary>
        /// Is box contains Int2 point. Box should be valid before operation!
        /// </summary>
        /// <param name="lhs">Box.</param>
        /// <param name="rhs">Point to check.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static bool Contains (ref IntBox2 lhs, ref Int2 rhs) {
            return rhs.X >= lhs.Min.X && rhs.X <= lhs.Max.X && rhs.Y >= lhs.Min.Y && rhs.Y <= lhs.Max.Y;
        }

        /// <summary>
        /// Are boxes intersects. Both boxes should be valid before operation!
        /// </summary>
        /// <param name="lhs">First box.</param>
        /// <param name="rhs">Second box.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static bool Intersects (ref IntBox2 lhs, ref IntBox2 rhs) {
            return rhs.Min.X <= lhs.Max.X && rhs.Max.X >= lhs.Min.X && rhs.Min.Y <= lhs.Max.Y && rhs.Max.Y >= lhs.Min.Y;
        }

        /// <summary>
        /// Returns equality of vectors.
        /// </summary>
        /// <param name="lhs">First vector.</param>
        /// <param name="rhs">Second vector.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static bool Equals (ref IntBox2 lhs, ref IntBox2 rhs) {
            return lhs.Min.X == rhs.Min.X && lhs.Min.Y == rhs.Min.Y && lhs.Max.X == rhs.Max.X && lhs.Max.Y == rhs.Max.Y;
        }

#if UNITY_5_6_OR_NEWER
        public static implicit operator UnityEngine.RectInt (IntBox2 v) {
            return new UnityEngine.RectInt (v.Min.X, v.Min.Y, v.Max.X - v.Min.X, v.Max.Y - v.Min.Y);
        }

        public static implicit operator IntBox2 (UnityEngine.RectInt v) {
            IntBox2 res;
            res.Min.X = v.xMin;
            res.Min.Y = v.yMin;
            res.Max.X = v.xMax;
            res.Max.Y = v.yMax;
            return res;
        }
#endif
    }
}