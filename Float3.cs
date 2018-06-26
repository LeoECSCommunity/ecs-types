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
    public struct Float3 {
        public float X;

        public float Y;

        public float Z;

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public float SqrMagnitude () {
            return X * X + Y * Y + Z * Z;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public float Magnitude () {
            return (float) Math.Sqrt (X * X + Y * Y + Z * Z);
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Normalize () {
            var invMagnitude = 1f / (float) Math.Sqrt (X * X + Y * Y + Z * Z);
            X *= invMagnitude;
            Y *= invMagnitude;
            Z *= invMagnitude;
        }

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
        public void Add (ref Float3 rhs) {
            X += rhs.X;
            Y += rhs.Y;
            Z += rhs.Z;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Add (float addX, float addY, float addZ) {
            X += addX;
            Y += addY;
            Z += addZ;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Sub (ref Float3 rhs) {
            X -= rhs.X;
            Y -= rhs.Y;
            Z -= rhs.Z;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Scale (float addX, float addY, float addZ) {
            X *= addX;
            Y *= addY;
            Z *= addZ;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float3 Add (ref Float3 lhs, ref Float3 rhs) {
            Float3 res;
            res.X = lhs.X + rhs.X;
            res.Y = lhs.Y + rhs.Y;
            res.Z = lhs.Z + rhs.Z;
            return res;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static void Add (ref Float3 lhs, float addX, float addY, float addZ) {
            Float3 res;
            res.X = lhs.X + addX;
            res.Y = lhs.Y + addY;
            res.Z = lhs.Z + addZ;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float3 Sub (ref Float3 lhs, ref Float3 rhs) {
            Float3 res;
            res.X = lhs.X - rhs.X;
            res.Y = lhs.Y - rhs.Y;
            res.Z = lhs.Z - rhs.Z;
            return res;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float3 Scale (ref Float3 lhs, float scaleX, float scaleY, float scaleZ) {
            Float3 res;
            res.X = lhs.X * scaleX;
            res.Y = lhs.Y * scaleY;
            res.Z = lhs.Z * scaleZ;
            return res;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float3 Normalize (ref Float3 rhs) {
            Float3 res;
            var invMagnitude = 1f / (float) Math.Sqrt (rhs.X * rhs.X + rhs.Y * rhs.Y + rhs.Z * rhs.Z);
            res.X = rhs.X * invMagnitude;
            res.Y = rhs.Y * invMagnitude;
            res.Z = rhs.Z * invMagnitude;
            return res;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static bool Equals (ref Float3 lhs, ref Float3 rhs) {
            return (lhs.X - rhs.X) * (lhs.X - rhs.X) + (lhs.Y - rhs.Y) * (lhs.Y - rhs.Y) + (lhs.Z - rhs.Z) * (lhs.Z - rhs.Z) < float.Epsilon * float.Epsilon;
        }
    }
}