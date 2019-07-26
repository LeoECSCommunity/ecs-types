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
    /// Directional beam (ray) from point in 3d space.
    /// </summary>
    [Serializable]
    [StructLayout (LayoutKind.Sequential)]
    public struct Beam3 {
        public Float3 Origin;
        public Float3 Direction;

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public Beam3 (in Float3 origin, in Float3 direction) {
            Origin = origin;
            Direction = direction;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public Float3 GetPoint (float distance) {
            Float3 v;
            v.X = Origin.X + Direction.X * distance;
            v.Y = Origin.Y + Direction.Y * distance;
            v.Z = Origin.Z + Direction.Z * distance;
            return v;
        }

#if UNITY_2018_3_OR_NEWER
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static implicit operator UnityEngine.Ray (in Beam3 v) {
            return new UnityEngine.Ray (v.Origin, v.Direction);
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static implicit operator Beam3 (in UnityEngine.Ray v) {
            Beam3 res;
            res.Origin = v.origin;
            res.Direction = v.direction;
            return res;
        }
#endif
    }
}