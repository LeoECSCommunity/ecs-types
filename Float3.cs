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
    public struct Float3 {
        public float x;

        public float y;

        public float z;

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public float SqrMagnitude () {
            return x * x + y * y + z * z;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public float Magnitude () {
            return (float) Math.Sqrt (x * x + y * y + z * z);
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Normalize () {
            var invMagnitude = 1f / (float) Math.Sqrt (x * x + y * y + z * z);
            x *= invMagnitude;
            y *= invMagnitude;
            z *= invMagnitude;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Neg () {
            x = -x;
            y = -y;
            z = -z;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Add (ref Float3 rhs) {
            x += rhs.x;
            y += rhs.y;
            z += rhs.z;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Add (float addX, float addY, float addZ) {
            x += addX;
            y += addY;
            z += addZ;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Sub (ref Float3 rhs) {
            x -= rhs.x;
            y -= rhs.y;
            z -= rhs.z;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Scale (float addX, float addY, float addZ) {
            x *= addX;
            y *= addY;
            z *= addZ;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float3 Add (ref Float3 lhs, ref Float3 rhs) {
            Float3 res;
            res.x = lhs.x + rhs.x;
            res.y = lhs.y + rhs.y;
            res.z = lhs.z + rhs.z;
            return res;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static void Add (ref Float3 lhs, float addX, float addY, float addZ) {
            Float3 res;
            res.x = lhs.x + addX;
            res.y = lhs.y + addY;
            res.z = lhs.z + addZ;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float3 Sub (ref Float3 lhs, ref Float3 rhs) {
            Float3 res;
            res.x = lhs.x - rhs.x;
            res.y = lhs.y - rhs.y;
            res.z = lhs.z - rhs.z;
            return res;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float3 Scale (ref Float3 lhs, float scaleX, float scaleY, float scaleZ) {
            Float3 res;
            res.x = lhs.x * scaleX;
            res.y = lhs.y * scaleY;
            res.z = lhs.z * scaleZ;
            return res;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float3 Normalize (ref Float3 rhs) {
            Float3 res;
            var invMagnitude = 1f / (float) Math.Sqrt (rhs.x * rhs.x + rhs.y * rhs.y + rhs.z * rhs.z);
            res.x = rhs.x * invMagnitude;
            res.y = rhs.y * invMagnitude;
            res.z = rhs.z * invMagnitude;
            return res;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static bool Equals (ref Float3 lhs, ref Float3 rhs) {
            return (lhs.x - rhs.x) * (lhs.x - rhs.x) + (lhs.y - rhs.y) * (lhs.y - rhs.y) + (lhs.z - rhs.z) * (lhs.z - rhs.z) < float.Epsilon * float.Epsilon;
        }
    }
}