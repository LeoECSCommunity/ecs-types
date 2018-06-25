// ----------------------------------------------------------------------------
// The MIT License
// Types for Entity Component System framework https://github.com/Leopotam/ecs
// Copyright (c) 2017-2018 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------
#if NET_4_6
using System.Runtime.CompilerServices;
#endif

namespace Leopotam.Ecs.Types {
    public struct Int3 {
        public int x;

        public int y;

        public int z;

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
        public void Add (ref Int3 rhs) {
            x += rhs.x;
            y += rhs.y;
            z += rhs.z;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Add (int addX, int addY, int addZ) {
            x += addX;
            y += addY;
            z += addZ;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Sub (ref Int3 rhs) {
            x -= rhs.x;
            y -= rhs.y;
            z -= rhs.z;
        }
#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Int3 Add (ref Int3 lhs, ref Int3 rhs) {
            Int3 res;
            res.x = lhs.x + rhs.x;
            res.y = lhs.y + rhs.y;
            res.z = lhs.z + rhs.z;
            return res;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Int3 Sub (ref Int3 lhs, ref Int3 rhs) {
            Int3 res;
            res.x = lhs.x - rhs.x;
            res.y = lhs.y - rhs.y;
            res.z = lhs.z - rhs.z;
            return res;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Int3 Neg (ref Int3 lhs) {
            Int3 res;
            res.x = -lhs.x;
            res.y = -lhs.y;
            res.z = -lhs.z;
            return res;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static bool Equals (ref Int3 lhs, ref Int3 rhs) {
            return lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z;
        }
    }
}