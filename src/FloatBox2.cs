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
    /// 2D box with float components.
    /// </summary>
    [Serializable]
    [StructLayout (LayoutKind.Sequential)]
    public struct FloatBox2 {
        public Float2 Min;
        public Float2 Max;

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public FloatBox2 (in Float2 min, in Float2 max) {
            Min = min;
            Max = max;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public Float2 GetCenter () {
            Float2 center;
            center.X = (Min.X + Max.X) * 0.5f;
            center.Y = (Min.Y + Max.Y) * 0.5f;
            return center;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public bool Contains (in Float2 point) {
            return (
                (Min.X <= point.X) && (Max.X >= point.X) &&
                (Min.Y <= point.Y) && (Max.Y >= point.Y));
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public bool Intersects (in FloatBox2 box) {
            return !(
                box.Min.X > Max.X ||
                box.Min.Y > Max.Y ||
                box.Max.X < Min.X ||
                box.Max.Y < Min.Y);
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public void Join (in Float2 point) {
            Min = Float2.Min (Min, point);
            Max = Float2.Max (Max, point);
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public void Join (in FloatBox2 box) {
            Min = Float2.Min (Min, box.Min);
            Max = Float2.Max (Max, box.Max);
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static FloatBox2 operator + (in FloatBox2 lhs, in Float2 rhs) {
            FloatBox2 res;
            res.Min = Float2.Min (lhs.Min, rhs);
            res.Max = Float2.Max (lhs.Max, rhs);
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static FloatBox2 operator + (in FloatBox2 lhs, in FloatBox2 rhs) {
            FloatBox2 res;
            res.Min = Float2.Min (lhs.Min, rhs.Min);
            res.Max = Float2.Max (lhs.Max, rhs.Max);
            return res;
        }
    }
}