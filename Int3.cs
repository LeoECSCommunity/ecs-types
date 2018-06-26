// ----------------------------------------------------------------------------
// The MIT License
// Types for Entity Component System framework https://github.com/Leopotam/ecs
// Copyright (c) 2017-2018 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;

#if NET_4_6
using System.Runtime.CompilerServices;
#endif

namespace Leopotam.Ecs.Types {
    [Serializable]
    [StructLayout (LayoutKind.Sequential)]
    public struct Int3 {
        public int X;

        public int Y;

        public int Z;

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Neg () {
            X = -X;
            Y = -Y;
            Z = -Z;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Add (ref Int3 rhs) {
            X += rhs.X;
            Y += rhs.Y;
            Z += rhs.Z;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Add (int addX, int addY, int addZ) {
            X += addX;
            Y += addY;
            Z += addZ;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Sub (ref Int3 rhs) {
            X -= rhs.X;
            Y -= rhs.Y;
            Z -= rhs.Z;
        }
#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Int3 Add (ref Int3 lhs, ref Int3 rhs) {
            Int3 res;
            res.X = lhs.X + rhs.X;
            res.Y = lhs.Y + rhs.Y;
            res.Z = lhs.Z + rhs.Z;
            return res;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Int3 Sub (ref Int3 lhs, ref Int3 rhs) {
            Int3 res;
            res.X = lhs.X - rhs.X;
            res.Y = lhs.Y - rhs.Y;
            res.Z = lhs.Z - rhs.Z;
            return res;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Int3 Neg (ref Int3 lhs) {
            Int3 res;
            res.X = -lhs.X;
            res.Y = -lhs.Y;
            res.Z = -lhs.Z;
            return res;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static bool Equals (ref Int3 lhs, ref Int3 rhs) {
            return lhs.X == rhs.X && lhs.Y == rhs.Y && lhs.Z == rhs.Z;
        }
    }
}