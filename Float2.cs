// ----------------------------------------------------------------------------
// The MIT License
// Types for Entity Component System framework https://github.com/Leopotam/ecs
// Copyright (c) 2017-2018 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

using System;

#if NET_4_6
using System.Runtime.CompilerServices;
#endif

namespace Leopotam.Ecs.Types {
    public struct Float2 {
        public float x;

        public float y;

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public float SqrMagnitude () {
            return x * x + y * y;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public float Magnitude () {
            return (float) Math.Sqrt (x * x + y * y);
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Normalize () {
            var invMagnitude = 1f / (float) Math.Sqrt (x * x + y * y);
            x *= invMagnitude;
            y *= invMagnitude;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Neg () {
            x = -x;
            y = -y;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Add (ref Float2 rhs) {
            x += rhs.x;
            y += rhs.y;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Add (float addX, float addY) {
            x += addX;
            y += addY;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Sub (ref Float2 rhs) {
            x -= rhs.x;
            y -= rhs.y;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Scale (float addX, float addY) {
            x *= addX;
            y *= addY;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float2 Add (ref Float2 lhs, ref Float2 rhs) {
            Float2 res;
            res.x = lhs.x + rhs.x;
            res.y = lhs.y + rhs.y;
            return res;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static void Add (ref Float2 lhs, float addX, float addY, float addZ) {
            Float2 res;
            res.x = lhs.x + addX;
            res.y = lhs.y + addY;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float2 Sub (ref Float2 lhs, ref Float2 rhs) {
            Float2 res;
            res.x = lhs.x - rhs.x;
            res.y = lhs.y - rhs.y;
            return res;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float2 Scale (ref Float2 lhs, float scaleX, float scaleY, float scaleZ) {
            Float2 res;
            res.x = lhs.x * scaleX;
            res.y = lhs.y * scaleY;
            return res;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float2 Normalize (ref Float2 rhs) {
            Float2 res;
            var invMagnitude = 1f / (float) Math.Sqrt (rhs.x * rhs.x + rhs.y * rhs.y);
            res.x = rhs.x * invMagnitude;
            res.y = rhs.y * invMagnitude;
            return res;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static bool Equals (ref Float2 lhs, ref Float2 rhs) {
            return (lhs.x - rhs.x) * (lhs.x - rhs.x) + (lhs.y - rhs.y) * (lhs.y - rhs.y) < float.Epsilon * float.Epsilon;
        }
    }
}