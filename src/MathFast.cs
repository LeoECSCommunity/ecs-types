// ----------------------------------------------------------------------------
// The MIT License
// Types for Entity Component System framework https://github.com/Leopotam/ecs
// Copyright (c) 2017-2019 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

using System.Runtime.CompilerServices;

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
        /// Small float value, replacement for float.Epsilon due it can be zero for some reasons.
        /// </summary>
        public const float Epsilon = 1e-10f;

        /// <summary>
        /// PI constant.
        /// </summary>
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
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static float Min (float a, float b) {
            return a >= b ? b : a;
        }

        /// <summary>
        /// Gets min value.
        /// </summary>
        /// <param name="a">First value.</param>
        /// <param name="b">Second value.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static int Min (int a, int b) {
            return a >= b ? b : a;
        }

        /// <summary>
        /// Gets max value.
        /// </summary>
        /// <param name="a">First value.</param>
        /// <param name="b">Second value.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static float Max (float a, float b) {
            return a >= b ? a : b;
        }

        /// <summary>
        /// Gets max value.
        /// </summary>
        /// <param name="a">First value.</param>
        /// <param name="b">Second value.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static int Max (int a, int b) {
            return a >= b ? a : b;
        }

        /// <summary>
        /// Absolute value of provided data.
        /// </summary>
        /// <param name="v">Raw data.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static float Abs (float v) {
            return v >= 0f ? v : -v;
        }

        /// <summary>
        /// Absolute value of provided data.
        /// </summary>
        /// <param name="v">Raw data.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static int Abs (int v) {
            return v >= 0 ? v : -v;
        }

        /// <summary>
        /// Sign of provided data.
        /// </summary>
        /// <param name="v">Raw data.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static int Sign (float v) {
            return v > 0f ? 1 : (v < 0f ? -1 : 0);
        }

        /// <summary>
        /// Sign of provided data.
        /// </summary>
        /// <param name="v">Raw data.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static int Sign (int v) {
            return v > 0 ? 1 : (v < 0 ? -1 : 0);
        }

        /// <summary>
        /// Clamp data value to [min;max] range (inclusive).
        /// </summary>
        /// <param name="data">Data to clamp.</param>
        /// <param name="min">Min range border.</param>
        /// <param name="max">Max range border.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static float Lerp (float a, float b, float t) {
            if (t <= 0f) {
                return a;
            }
            if (t >= 1f) {
                return b;
            }
            return a + (b - a) * t;
        }

        /// <summary>
        /// Linear interpolation between "a"-"b" in factor "t". Factor will not be automatically clipped to [0;1] range.
        /// Not faster than Mathf.LerpUnclamped, but performance very close.
        /// </summary>
        /// <param name="a">Interpolate From.</param>
        /// <param name="b">Interpolate To.</param>
        /// <param name="t">Factor of interpolation.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static float LerpUnclamped (float a, float b, float t) {
            return a + (b - a) * t;
        }

        /// <summary>
        /// Calculates linear parameter t that produces the interpolated value within the range [a, b].
        /// </summary>
        /// <param name="a">Start value.</param>
        /// <param name="b">End value.</param>
        /// <param name="value">Value between start and end.</param>
        public static float LerpInveresed (float a, float b, float value) {
            var data = (value - a) / (b - a);
            if (data < 0f) {
                return 0f;
            }
            if (data > 1f) {
                return 1f;
            }
            return data;
        }

        /// <summary>
        /// Returns largest integer smaller to or equal to data.
        /// </summary>
        /// <param name="data">Data to floor.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static int Floor (float data) {
            return data >= 0f ? (int) data : (int) data - 1;
        }

        /// <summary>
        /// Returns rounded integer.
        /// </summary>
        /// <param name="data">Data to round.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static int Round (float data) {
            return data >= 0f ? (int) (data + 0.5f) : (int) (data - 0.5f);
        }

        /// <summary>
        /// Returns sin of angle.
        /// </summary>
        /// <param name="v">Angle in radians.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static float Sin (float v) {
            return (float) System.Math.Sin (v);
        }

        /// <summary>
        /// Returns cos of angle.
        /// </summary>
        /// <param name="v">Angle in radians.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static float Cos (float v) {
            return (float) System.Math.Cos (v);
        }

        /// <summary>
        /// Returns tan of angle.
        /// </summary>
        /// <param name="v">Angle in radians.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static float Tan (float v) {
            return (float) System.Math.Tan (v);
        }

        /// <summary>
        /// Returns exp of angle.
        /// </summary>
        /// <param name="v">Angle in radians.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static float Exp (float v) {
            return (float) System.Math.Exp (v);
        }
    }
}