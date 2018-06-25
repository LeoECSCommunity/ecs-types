// ----------------------------------------------------------------------------
// The MIT License
// Types for Entity Component System framework https://github.com/Leopotam/ecs
// Copyright (c) 2017-2018 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------
#if NET_4_6
using System.Runtime.CompilerServices;
#endif

namespace Leopotam.Ecs.Types {
    public struct Int2 {
        public int x;

        public int y;

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
        public void Add (ref Int2 rhs) {
            x += rhs.x;
            y += rhs.y;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Add (int addX, int addY) {
            x += addX;
            y += addY;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Sub (ref Int2 rhs) {
            x -= rhs.x;
            y -= rhs.y;
        }
#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Int2 Add (ref Int2 lhs, ref Int2 rhs) {
            Int2 res;
            res.x = lhs.x + rhs.x;
            res.y = lhs.y + rhs.y;
            return res;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Int2 Sub (ref Int2 lhs, ref Int2 rhs) {
            Int2 res;
            res.x = lhs.x - rhs.x;
            res.y = lhs.y - rhs.y;
            return res;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Int2 Neg (ref Int2 lhs) {
            Int2 res;
            res.x = -lhs.x;
            res.y = -lhs.y;
            return res;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static bool Equals (ref Int2 lhs, ref Int2 rhs) {
            return lhs.x == rhs.x && lhs.y == rhs.y;
        }
    }
}