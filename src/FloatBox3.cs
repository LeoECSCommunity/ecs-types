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
    /// 3D box with float components.
    /// </summary>
    [Serializable]
    [StructLayout (LayoutKind.Sequential)]
    public struct FloatBox3 {
        public Float3 Min;
        public Float3 Max;

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public FloatBox3 (in Float3 min, in Float3 max) {
            Min = min;
            Max = max;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public Float3 GetCenter () {
            Float3 center;
            center.X = (Min.X + Max.X) * 0.5f;
            center.Y = (Min.Y + Max.Y) * 0.5f;
            center.Z = (Min.Z + Max.Z) * 0.5f;
            return center;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public bool Contains (in Float3 point) {
            return (
                (Min.X <= point.X) && (Max.X >= point.X) &&
                (Min.Y <= point.Y) && (Max.Y >= point.Y) &&
                (Min.Z <= point.Z) && (Max.Z >= point.Z));
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public void Join (in Float3 point) {
            Min = Float3.Min (Min, point);
            Max = Float3.Max (Max, point);
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public void Join (in FloatBox3 box) {
            Min = Float3.Min (Min, box.Min);
            Max = Float3.Max (Max, box.Max);
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static FloatBox3 operator + (in FloatBox3 lhs, in Float3 rhs) {
            FloatBox3 res;
            res.Min = Float3.Min (lhs.Min, rhs);
            res.Max = Float3.Max (lhs.Max, rhs);
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static FloatBox3 operator + (in FloatBox3 lhs, in FloatBox3 rhs) {
            FloatBox3 res;
            res.Min = Float3.Min (lhs.Min, rhs.Min);
            res.Max = Float3.Max (lhs.Max, rhs.Max);
            return res;
        }
    }
}