// ----------------------------------------------------------------------------
// The MIT License
// Types for Entity Component System framework https://github.com/Leopotam/ecs
// Copyright (c) 2017-2018 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;

#if NET_4_6 || NET_STANDARD_2_0
using System.Runtime.CompilerServices;
#endif

namespace Leopotam.Ecs.Types {
    /// <summary>
    /// Approximated math functions.
    /// </summary>
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public static class MathApprox {
        [StructLayout (LayoutKind.Explicit)]
        struct FloatInt {
            [FieldOffset (0)]
            public float Float;

            [FieldOffset (0)]
            public int Int;
        }

        [StructLayout (LayoutKind.Explicit)]
        struct DoubleInt64 {
            [FieldOffset (0)]
            public double Double;

            [FieldOffset (0)]
            public Int64 Int64;
        }

        const int SinCosIndexMask = ~(-1 << 12);

        static readonly float[] _sinCache;

        static readonly float[] _cosCache;

        const float SinCosIndexFactor = SinCosCacheSize / MathFast.Pi2;

        const int SinCosCacheSize = SinCosIndexMask + 1;

        static MathApprox () {
            _sinCache = new float[SinCosCacheSize];
            _cosCache = new float[SinCosCacheSize];
            int i;
            for (i = 0; i < SinCosCacheSize; i++) {
                _sinCache[i] = (float) System.Math.Sin ((i + 0.5f) / SinCosCacheSize * MathFast.Pi2);
                _cosCache[i] = (float) System.Math.Cos ((i + 0.5f) / SinCosCacheSize * MathFast.Pi2);
            }

            var factor = SinCosCacheSize / 360f;
            for (i = 0; i < 360; i += 90) {
                _sinCache[(int) (i * factor) & SinCosIndexMask] = (float) System.Math.Sin (i * MathFast.Deg2Rad);
                _cosCache[(int) (i * factor) & SinCosIndexMask] = (float) System.Math.Cos (i * MathFast.Deg2Rad);
            }
        }

        /// <summary>
        /// Gets E raised to specified power with 1% error.
        /// </summary>
        /// <param name="power">Target power.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static float Exp (float power) {
            var c = new DoubleInt64 ();
            c.Int64 = (Int64) (1512775 * power + 1072632447) << 32;
            return (float) c.Double;
        }

        /// <summary>
        /// Gets data raised to specified power with 3% error.
        /// </summary>
        /// <param name="data">Data to raise.</param>
        /// <param name="power">Target power.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static float Pow (float data, float power) {
            var c = new DoubleInt64 ();
            c.Double = data;
            c.Int64 = (Int64) (power * ((c.Int64 >> 32) - 1072632447) + 1072632447) << 32;
            return (float) c.Double;
        }

        /// <summary>
        /// Gets Sin with 0.0003 error.
        /// </summary>
        /// <param name="v">Angle in radians.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static float Sin (float v) {
            return _sinCache[(int) (v * SinCosIndexFactor) & SinCosIndexMask];
        }

        /// <summary>
        /// Gets Cos with 0.0003 error.
        /// </summary>
        /// <param name="v">Angle in radians.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static float Cos (float v) {
            return _cosCache[(int) (v * SinCosIndexFactor) & SinCosIndexMask];
        }

        /// <summary>
        /// Gets normalized Float2 vector with 0.001 error.
        /// </summary>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float2 Normalize (ref Float2 v) {
            var wrapper = new FloatInt ();
            wrapper.Float = v.X * v.X + v.Y * v.Y;
            wrapper.Int = 0x5f3759df - (wrapper.Int >> 1);
            Float2 res;
            res.X = v.X * wrapper.Float;
            res.Y = v.Y * wrapper.Float;
            return res;
        }

        /// <summary>
        /// Gets normalized Float3 vector with 0.001 error.
        /// </summary>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float3 Normalize (ref Float3 v) {
            var wrapper = new FloatInt ();
            wrapper.Float = v.X * v.X + v.Y * v.Y + v.Z * v.Z;
            wrapper.Int = 0x5f3759df - (wrapper.Int >> 1);
            Float3 res;
            res.X = v.X * wrapper.Float;
            res.Y = v.Y * wrapper.Float;
            res.Z = v.Z * wrapper.Float;
            return res;
        }
    }
}