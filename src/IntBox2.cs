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
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public IntBox2 (in Int2 min, in Int2 max) {
            Min = min;
            Max = max;
        }

        /// <summary>
        /// Validates box bounds.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public void Join (in IntBox2 rhs) {
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
        /// Joins box with (X,Y) point. Box should be valid before operation!
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public void Join (in Int2 rhs) {
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
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static IntBox2 GetValidated (in IntBox2 lhs) {
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
        /// Gets width of box. Box should be valid before operation!
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public int GetWidth () {
            return Max.X - Min.X;
        }

        /// <summary>
        /// Gets height of box. Box should be valid before operation!
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public int GetHeight () {
            return Max.Y - Min.Y;
        }

        /// <summary>
        /// Is box contains point X,Y. Box should be valid before operation!
        /// </summary>
        /// <param name="x">Point X-coord.</param>
        /// <param name="y">Point Y-coord.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public bool Contains (int x, int y) {
            return x >= Min.X && x <= Max.X && y >= Min.Y && y <= Max.Y;
        }

        /// <summary>
        /// Is box contains Int2 point. Box should be valid before operation!
        /// </summary>
        /// <param name="point">Point to check.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public bool Contains (in Int2 point) {
            return point.X >= Min.X && point.X <= Max.X && point.Y >= Min.Y && point.Y <= Max.Y;
        }

        /// <summary>
        /// Are boxes intersects. Both boxes should be valid before operation!
        /// </summary>
        /// <param name="box">Second box.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public bool Intersects (in IntBox2 box) {
            return box.Min.X <= Max.X && box.Max.X >= Min.X && box.Min.Y <= Max.Y && box.Max.Y >= Min.Y;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static IntBox2 operator + (in IntBox2 lhs, in IntBox2 rhs) {
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
        /// <param name="rhs">Point to include.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static IntBox2 operator + (in IntBox2 lhs, in Int2 rhs) {
            IntBox2 res;
            res.Min.X = lhs.Min.X < rhs.X ? lhs.Min.X : rhs.X;
            res.Min.Y = lhs.Min.Y < rhs.Y ? lhs.Min.Y : rhs.Y;
            res.Max.X = lhs.Max.X > rhs.X ? lhs.Max.X : rhs.X;
            res.Max.Y = lhs.Max.Y > rhs.Y ? lhs.Max.Y : rhs.Y;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static bool operator == (in IntBox2 lhs, in IntBox2 rhs) {
            return (
                lhs.Min.X == rhs.Min.X && lhs.Min.Y == rhs.Min.Y &&
                lhs.Max.X == rhs.Max.X && lhs.Max.Y == rhs.Max.Y);
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static bool operator != (in IntBox2 lhs, in IntBox2 rhs) {
            return (
                lhs.Min.X != rhs.Min.X || lhs.Min.Y != rhs.Min.Y &&
                lhs.Max.X != rhs.Max.X || lhs.Max.Y != rhs.Max.Y);
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode () {
            // ReSharper disable NonReadonlyMemberInGetHashCode
            return Min.GetHashCode () ^ (Max.GetHashCode () << 2);
            // ReSharper restore NonReadonlyMemberInGetHashCode
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public override bool Equals (object other) {
            if (!(other is IntBox2)) {
                return false;
            }
            var rhs = (IntBox2) other;
            return Min == rhs.Min && Max == rhs.Max;
        }

#if UNITY_2018_3_OR_NEWER
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static implicit operator UnityEngine.RectInt (in IntBox2 v) {
            return new UnityEngine.RectInt (v.Min.X, v.Min.Y, v.Max.X - v.Min.X, v.Max.Y - v.Min.Y);
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static implicit operator IntBox2 (in UnityEngine.RectInt v) {
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