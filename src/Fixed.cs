// ----------------------------------------------------------------------------
// The MIT License
// Types for Entity Component System framework https://github.com/Leopotam/ecs
// Copyright (c) 2017-2019 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Leopotam.Ecs.Types {
    /// <summary>
    /// Fixed point 16.16 float.
    /// </summary>
    [Serializable]
    [StructLayout (LayoutKind.Sequential)]
    public struct Fixed {
        public int Raw;

        const int FracBits = 16;
        const int FracRange = 1 << FracBits;
        const int FracMask = FracRange - 1;
        const float InvFracRange = 1f / FracRange;

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode () {
            // ReSharper disable once NonReadonlyMemberInGetHashCode
            return Raw;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public override bool Equals (object rhs) {
            return rhs is Fixed && ((Fixed) rhs).Raw == Raw;
        }

#if DEBUG
        public override string ToString () {
            return string.Format (System.Globalization.CultureInfo.InvariantCulture, "{0}", (float) this);
        }
#endif

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Fixed operator + (in Fixed lhs, in Fixed rhs) {
            Fixed res;
            res.Raw = lhs.Raw + rhs.Raw;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Fixed operator - (in Fixed lhs, in Fixed rhs) {
            Fixed res;
            res.Raw = lhs.Raw - rhs.Raw;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Fixed operator - (in Fixed lhs) {
            Fixed res;
            res.Raw = -lhs.Raw;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Fixed operator * (in Fixed lhs, in Fixed rhs) {
            Fixed res;
            res.Raw = (int) ((lhs.Raw * (long) rhs.Raw) >> FracBits);
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Fixed operator / (in Fixed lhs, in Fixed rhs) {
            Fixed res;
            res.Raw = (int) (((long) lhs.Raw << FracBits) / rhs.Raw);
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static bool operator == (in Fixed lhs, in Fixed rhs) {
            return lhs.Raw == rhs.Raw;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static bool operator != (in Fixed lhs, in Fixed rhs) {
            return lhs.Raw != rhs.Raw;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static bool operator > (in Fixed lhs, in Fixed rhs) {
            return lhs.Raw > rhs.Raw;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (in Fixed lhs, in Fixed rhs) {
            return lhs.Raw >= rhs.Raw;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static bool operator < (in Fixed lhs, in Fixed rhs) {
            return lhs.Raw < rhs.Raw;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (in Fixed lhs, in Fixed rhs) {
            return lhs.Raw <= rhs.Raw;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static implicit operator Fixed (int v) {
            Fixed res;
            res.Raw = v << FracBits;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static implicit operator int (in Fixed lhs) {
            return lhs.Raw >= 0 ? lhs.Raw >> FracBits : (lhs.Raw + FracMask) >> FracBits;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static implicit operator float (in Fixed lhs) {
            return (lhs.Raw >> FracBits) + (lhs.Raw & FracMask) * InvFracRange;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static implicit operator HighFixed (in Fixed lhs) {
            HighFixed res;
            res.Raw = lhs.Raw;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static implicit operator Fixed (float v) {
            Fixed res;
            var trunc = (int) v;
            var dec = (int) ((v - trunc) * FracRange);
            if (v < 0f) {
                trunc = -trunc;
                dec = -dec;
            }
            res.Raw = (trunc << FracBits) | dec;
            if (v < 0f) {
                res.Raw = -res.Raw;
            }
            return res;
        }
    }
}