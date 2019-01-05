// ----------------------------------------------------------------------------
// The MIT License
// Types for Entity Component System framework https://github.com/Leopotam/ecs
// Copyright (c) 2017-2019 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;

#if NET_4_6 || NET_STANDARD_2_0
using System.Runtime.CompilerServices;
#endif

namespace Leopotam.Ecs.Types {
    /// <summary>
    /// Fixed point 16.16 float.
    /// </summary>
    [Serializable]
    [StructLayout (LayoutKind.Sequential)]
    public struct Fixed {
        const int FracBits = 16;
        const int FracRange = 1 << FracBits;
        const int FracMask = FracRange - 1;
        const float InvFracRange = 1f / FracRange;
        public Int32 Raw;

#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public override int GetHashCode () {
            return Raw.GetHashCode ();
        }

#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public override bool Equals (object rhs) {
            return rhs is Fixed && ((Fixed) rhs).Raw == Raw;
        }

#if DEBUG
        public override string ToString () {
            return string.Format (System.Globalization.CultureInfo.InvariantCulture, "{0}", (float) this);
        }
#endif

#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Fixed operator + (Fixed lhs, Fixed rhs) {
            Fixed res;
            res.Raw = lhs.Raw + rhs.Raw;
            return res;
        }

#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Fixed operator - (Fixed lhs, Fixed rhs) {
            Fixed res;
            res.Raw = lhs.Raw - rhs.Raw;
            return res;
        }

#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Fixed operator - (Fixed lhs) {
            Fixed res;
            res.Raw = -lhs.Raw;
            return res;
        }

#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Fixed operator * (Fixed lhs, Fixed rhs) {
            Fixed res;
            res.Raw = (int) (((long) lhs.Raw * (long) rhs.Raw) >> FracBits);
            return res;
        }

#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Fixed operator / (Fixed lhs, Fixed rhs) {
            Fixed res;
            res.Raw = (int) (((long) lhs.Raw << FracBits) / rhs.Raw);
            return res;
        }

#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static bool operator == (Fixed lhs, Fixed rhs) {
            return lhs.Raw == rhs.Raw;
        }

#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static bool operator != (Fixed lhs, Fixed rhs) {
            return lhs.Raw == rhs.Raw;
        }

#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static bool operator > (Fixed lhs, Fixed rhs) {
            return lhs.Raw > rhs.Raw;
        }

#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static bool operator >= (Fixed lhs, Fixed rhs) {
            return lhs.Raw >= rhs.Raw;
        }

#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static bool operator < (Fixed lhs, Fixed rhs) {
            return lhs.Raw < rhs.Raw;
        }

#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static bool operator <= (Fixed lhs, Fixed rhs) {
            return lhs.Raw <= rhs.Raw;
        }

#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static implicit operator Fixed (int v) {
            Fixed res;
            res.Raw = v << FracBits;
            return res;
        }

#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static implicit operator int (Fixed lhs) {
            return lhs.Raw >= 0 ? lhs.Raw >> FracBits : (lhs.Raw + FracMask) >> FracBits;
        }

#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static implicit operator float (Fixed lhs) {
            return (lhs.Raw >> FracBits) + (lhs.Raw & FracMask) * InvFracRange;
        }

#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static implicit operator HighFixed (Fixed lhs) {
            HighFixed res;
            res.Raw = lhs.Raw;
            return res;
        }

#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
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