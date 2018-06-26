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
    public struct Float4 {
        public float X;

        public float Y;

        public float Z;

        public float W;

        public Float4 (float x, float y, float z, float w) {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Neg () {
            X = -X;
            Y = -Y;
            Z = -Z;
            W = -W;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public float SqrMagnitude () {
            return X * X + Y * Y + Z * Z + W * W;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public float Magnitude () {
            return (float) Math.Sqrt (X * X + Y * Y + Z * Z + W * W);
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Normalize () {
            var invMagnitude = 1f / (float) Math.Sqrt (X * X + Y * Y + Z * Z + W * W);
            X *= invMagnitude;
            Y *= invMagnitude;
            Z *= invMagnitude;
            W *= invMagnitude;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Add (ref Float4 rhs) {
            X += rhs.X;
            Y += rhs.Y;
            Z += rhs.Z;
            W += rhs.W;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Add (float x, float y, float z, float w) {
            X += x;
            Y += y;
            Z += z;
            W += w;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Sub (ref Float4 rhs) {
            X -= rhs.X;
            Y -= rhs.Y;
            Z -= rhs.Z;
            W -= rhs.W;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Scale (float x, float y, float z, float w) {
            X *= x;
            Y *= y;
            Z *= z;
            W *= w;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float4 Add (ref Float4 lhs, ref Float4 rhs) {
            Float4 res;
            res.X = lhs.X + rhs.X;
            res.Y = lhs.Y + rhs.Y;
            res.Z = lhs.Z + rhs.Z;
            res.W = lhs.W + rhs.W;
            return res;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static void Add (ref Float4 lhs, float x, float y, float z, float w) {
            Float4 res;
            res.X = lhs.X + x;
            res.Y = lhs.Y + y;
            res.Z = lhs.Z + z;
            res.W = lhs.W + w;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float4 Sub (ref Float4 lhs, ref Float4 rhs) {
            Float4 res;
            res.X = lhs.X - rhs.X;
            res.Y = lhs.Y - rhs.Y;
            res.Z = lhs.Z - rhs.Z;
            res.W = lhs.W - rhs.W;
            return res;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float4 Scale (ref Float4 lhs, float x, float y, float z, float w) {
            Float4 res;
            res.X = lhs.X * x;
            res.Y = lhs.Y * y;
            res.Z = lhs.Z * z;
            res.W = lhs.W * w;
            return res;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float4 Normalize (ref Float4 rhs) {
            Float4 res;
            var invMagnitude = 1f / (float) Math.Sqrt (rhs.X * rhs.X + rhs.Y * rhs.Y + rhs.Z * rhs.Z + rhs.W * rhs.W);
            res.X = rhs.X * invMagnitude;
            res.Y = rhs.Y * invMagnitude;
            res.Z = rhs.Z * invMagnitude;
            res.W = rhs.W * invMagnitude;
            return res;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static bool Equals (ref Float4 lhs, ref Float4 rhs) {
            return (lhs.X - rhs.X) * (lhs.X - rhs.X) + (lhs.Y - rhs.Y) * (lhs.Y - rhs.Y) + (lhs.Z - rhs.Z) * (lhs.Z - rhs.Z) + (lhs.W - rhs.W) * (lhs.W - rhs.W) < float.Epsilon * float.Epsilon;
        }
    }
}