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
    /// Directional beam (ray) from point in 2d space.
    /// </summary>
    [Serializable]
    [StructLayout (LayoutKind.Sequential)]
    public struct Beam2 {
        public Float2 Origin;
        public Float2 Direction;

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public Beam2 (in Float2 origin, in Float2 direction) {
            Origin = origin;
            Direction = direction;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public Float2 GetPoint (float distance) {
            Float2 v;
            v.X = Origin.X + Direction.X * distance;
            v.Y = Origin.Y + Direction.Y * distance;
            return v;
        }
    }
}