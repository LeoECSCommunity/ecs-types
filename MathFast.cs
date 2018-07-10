﻿// ----------------------------------------------------------------------------
// The MIT License
// Types for Entity Component System framework https://github.com/Leopotam/ecs
// Copyright (c) 2017-2018 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

#if NET_4_6 || NET_STANDARD_2_0
using System.Runtime.CompilerServices;
#endif

namespace Leopotam.Ecs.Types {
    /// <summary>
    /// Optimized math functions.
    /// </summary>
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public static class MathFast {
        /// <summary>
        /// PI constant.
        /// </summary>
        /// <returns></returns>
        public const float Pi = (float) System.Math.PI;

        /// <summary>
        /// PI*2 constant.
        /// </summary>
        public const float Pi2 = Pi * 2f;

        /// <summary>
        /// PI/2 constant.
        /// </summary>
        public const float PiDiv2 = Pi * 0.5f;

        /// <summary>
        /// Degrees to radians conversion multiplier.
        /// </summary>
        public const float Deg2Rad = Pi / 180f;

        /// <summary>
        /// Radians to degrees conversion multiplier.
        /// </summary>
        public const float Rad2Deg = 1f / Deg2Rad;

        /// <summary>
        /// Gets min value.
        /// </summary>
        /// <param name="a">First value.</param>
        /// <param name="b">Second value.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static float Min (float a, float b) {
            return a >= b ? b : a;
        }

        /// <summary>
        /// Gets min value.
        /// </summary>
        /// <param name="a">First value.</param>
        /// <param name="b">Second value.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static int Min (int a, int b) {
            return a >= b ? b : a;
        }

        /// <summary>
        /// Gets max value.
        /// </summary>
        /// <param name="a">First value.</param>
        /// <param name="b">Second value.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static float Max (float a, float b) {
            return a >= b ? a : b;
        }

        /// <summary>
        /// Gets max value.
        /// </summary>
        /// <param name="a">First value.</param>
        /// <param name="b">Second value.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static int Max (int a, int b) {
            return a >= b ? a : b;
        }

        /// <summary>
        /// Absolute value of provided data.
        /// </summary>
        /// <param name="v">Raw data.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static float Abs (float v) {
            return v >= 0f ? v : -v;
        }

        /// <summary>
        /// Absolute value of provided data.
        /// </summary>
        /// <param name="v">Raw data.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static int Abs (int v) {
            return v >= 0 ? v : -v;
        }

        /// <summary>
        /// Clamp data value to [min;max] range (inclusive).
        /// </summary>
        /// <param name="data">Data to clamp.</param>
        /// <param name="min">Min range border.</param>
        /// <param name="max">Max range border.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static float Clamp (float data, float min, float max) {
            if (data < min) {
                return min;
            } else {
                if (data > max) {
                    return max;
                }
                return data;
            }
        }

        /// <summary>
        /// Clamp data value to [min;max] range (inclusive).
        /// </summary>
        /// <param name="data">Data to clamp.</param>
        /// <param name="min">Min range border.</param>
        /// <param name="max">Max range border.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static int Clamp (int data, int min, int max) {
            if (data < min) {
                return min;
            } else {
                if (data > max) {
                    return max;
                }
                return data;
            }
        }

        /// <summary>
        /// Clamp data value to [0;1] range (inclusive).
        /// </summary>
        /// <param name="data">Data to clamp.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static float Clamp01 (float data) {
            if (data < 0f) {
                return 0f;
            } else {
                if (data > 1f) {
                    return 1f;
                }
                return data;
            }
        }

        /// <summary>
        /// Linear interpolation between "a"-"b" in factor "t". Factor will be automatically clipped to [0;1] range.
        /// </summary>
        /// <param name="a">Interpolate From.</param>
        /// <param name="b">Interpolate To.</param>
        /// <param name="t">Factor of interpolation.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static float Lerp (float a, float b, float t) {
            if (t <= 0f) {
                return a;
            } else {
                if (t >= 1f) {
                    return b;
                }
                return a + (b - a) * t;
            }
        }

        /// <summary>
        /// Linear interpolation between "a"-"b" in factor "t". Factor will not be automatically clipped to [0;1] range.
        /// Not faster than Mathf.LerpUnclamped, but performance very close.
        /// </summary>
        /// <param name="a">Interpolate From.</param>
        /// <param name="b">Interpolate To.</param>
        /// <param name="t">Factor of interpolation.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static float LerpUnclamped (float a, float b, float t) {
            return a + (b - a) * t;
        }

        /// <summary>
        /// Return largest integer smaller to or equal to data.
        /// </summary>
        /// <param name="data">Data to floor.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static int Floor (float data) {
            return data >= 0f ? (int) data : (int) data - 1;
        }
    }
}