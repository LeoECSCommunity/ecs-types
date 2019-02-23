// ----------------------------------------------------------------------------
// The MIT License
// Types for Entity Component System framework https://github.com/Leopotam/ecs
// Copyright (c) 2017-2019 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

using System.Runtime.CompilerServices;

namespace Leopotam.Ecs.Types {
    /// <summary>
    /// Rng generator, XorShift based.
    /// </summary>
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public sealed class RngXorShift {
        const double InvMaxIntExOne = 1.0 / (int.MaxValue + 1.0);
        const double InvIntMax = 1.0 / int.MaxValue;

        uint _x;
        uint _y;
        uint _z;
        uint _w;

        /// <summary>
        /// Default initialization.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public RngXorShift () : this (System.Environment.TickCount) { }

        /// <summary>
        /// Initialization with custom seed.
        /// </summary>
        /// <param name="seed">Seed.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public RngXorShift (int seed) {
            SetSeed (seed);
        }

        /// <summary>
        /// Sets new seed.
        /// </summary>
        /// <param name="seed">Seed.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public void SetSeed (int seed) {
            _x = (uint) (seed * 1431655781 + seed * 1183186591 + seed * 622729787 + seed * 338294347);
            _y = 842502087;
            _z = 3579807591;
            _w = 273326509;
        }

        /// <summary>
        /// Gets current internal state. Use on your risk!
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public Int4 GetInternalState () {
            Int4 res;
            res.X = (int) _x;
            res.Y = (int) _y;
            res.Z = (int) _z;
            res.W = (int) _w;
            return res;
        }

        /// <summary>
        /// Sets current internal state. Use on your risk!
        /// </summary>
        /// <param name="state">Raw data.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public void SetInternalState (Int4 state) {
            _x = (uint) state.X;
            _y = (uint) state.Y;
            _z = (uint) state.Z;
            _w = (uint) state.W;
        }

        /// <summary>
        /// Gets int32 random number from range [0, max).
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public int GetInt (int max) {
            var t = _x ^ (_x << 11);
            _x = _y;
            _y = _z;
            _z = _w;
            return (int) ((InvMaxIntExOne * (int) (0x7fffffff & (_w = (_w ^ (_w >> 19)) ^ (t ^ (t >> 8))))) * max);
        }

        /// <summary>
        /// Gets int32 random number from range [min, max).
        /// </summary>
        /// <param name="min">Min value.</param>
        /// <param name="max">Max value (excluded).</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public int GetInt (int min, int max) {
            if (min >= max) {
                return min;
            }
            var t = _x ^ (_x << 11);
            _x = _y;
            _y = _z;
            _z = _w;
            return min + (int) ((InvMaxIntExOne *
                (int) (0x7fffffff & (_w = (_w ^ (_w >> 19)) ^ (t ^ (t >> 8))))) * (max - min));
        }

        /// <summary>
        /// Gets float random number from range [0, 1) or [0, 1] for includeOne=true.
        /// </summary>
        /// <param name="includeOne">Include 1 value for searching.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public float GetFloat (bool includeOne = true) {
            var t = _x ^ (_x << 11);
            _x = _y;
            _y = _z;
            _z = _w;
            return (float) ((includeOne ? InvIntMax : InvMaxIntExOne) *
                (int) (0x7fffffff & (_w = (_w ^ (_w >> 19)) ^ (t ^ (t >> 8)))));
        }

        /// <summary>
        /// Gets float random number from range [min, max) or [min, max] for includeMax=true.
        /// </summary>
        /// <param name="min">Min value.</param>
        /// <param name="max">Max value.</param>
        /// <param name="includeMax">Include max value for searching.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public float GetFloat (float min, float max, bool includeMax = true) {
            if (min >= max) {
                return min;
            }
            var t = _x ^ (_x << 11);
            _x = _y;
            _y = _z;
            _z = _w;
            return min + (float) ((includeMax ? InvIntMax : InvMaxIntExOne) *
                (int) (0x7fffffff & (_w = (_w ^ (_w >> 19)) ^ (t ^ (t >> 8)))) * (max - min));
        }
    }

    /// <summary>
    /// Rng generator, mersenne twister based.
    /// </summary>
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public sealed class RngTwister {
        const int N = 624;
        const int M = 397;
        const ulong MatrixA = 0x9908b0dfUL;
        const ulong UpperMask = 0x80000000UL;
        const ulong LowerMask = 0x7fffffffUL;
        readonly ulong[] _mt = new ulong[N];
        readonly ulong[] _mag01 = { 0x0UL, MatrixA };

        int _mti = N + 1;

        /// <summary>
        /// Default initialization.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public RngTwister () : this (System.Environment.TickCount) { }

        /// <summary>
        /// Initialization with custom seed.
        /// </summary>
        /// <param name="seed">Seed.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public RngTwister (long seed) {
            SetSeed (seed);
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        ulong GetRandomUInt32 () {
            ulong y;
            if (_mti >= N) {
                int kk;
                if (_mti == N + 1) {
                    SetSeed (5489L);
                }
                for (kk = 0; kk < N - M; kk++) {
                    y = (_mt[kk] & UpperMask) | (_mt[kk + 1] & LowerMask);
                    _mt[kk] = _mt[kk + M] ^ (y >> 1) ^ _mag01[y & 0x1UL];
                }
                for (; kk < N - 1; kk++) {
                    y = (_mt[kk] & UpperMask) | (_mt[kk + 1] & LowerMask);
                    _mt[kk] = _mt[kk + (M - N)] ^ (y >> 1) ^ _mag01[y & 0x1UL];
                }
                y = (_mt[N - 1] & UpperMask) | (_mt[0] & LowerMask);
                _mt[N - 1] = _mt[M - 1] ^ (y >> 1) ^ _mag01[y & 0x1UL];
                _mti = 0;
            }
            y = _mt[_mti++];
            y ^= (y >> 11);
            y ^= (y << 7) & 0x9d2c5680UL;
            y ^= (y << 15) & 0xefc60000UL;
            y ^= (y >> 18);
            return y;
        }

        /// <summary>
        /// Sets new seed.
        /// </summary>
        /// <param name="seed">Seed.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public void SetSeed (long seed) {
            _mt[0] = (ulong) seed & 0xffffffffUL;
            for (_mti = 1; _mti < N; _mti++) {
                _mt[_mti] = (1812433253UL * (_mt[_mti - 1] ^ (_mt[_mti - 1] >> 30)) + (ulong) _mti) & 0xffffffffUL;
            }
        }

        /// <summary>
        /// Gets int32 random number from range [0, max).
        /// </summary>
        /// <param name="max">Max value (excluded).</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public int GetInt (int max) {
            return (int) (GetRandomUInt32 () * (max / 4294967296.0));
        }

        /// <summary>
        /// Gets int32 random number from range [min, max).
        /// </summary>
        /// <param name="min">Min value.</param>
        /// <param name="max">Max value (excluded).</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public int GetInt (int min, int max) {
            return min + GetInt (max - min);
        }

        /// <summary>
        /// Gets float random number from range [0, 1) or [0, 1] for includeOne=true.
        /// </summary>
        /// <param name="includeOne">Include 1 value for searching.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public float GetFloat (bool includeOne = true) {
            return (float) (GetRandomUInt32 () * (1.0 / (includeOne ? 4294967295.0 : 4294967296.0)));
        }

        /// <summary>
        /// Gets float random number from range [min, max) or [min, max] for includeMax=true.
        /// </summary>
        /// <param name="min">Min value.</param>
        /// <param name="max">Max value.</param>
        /// <param name="includeMax">Include max value for searching.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public float GetFloat (float min, float max, bool includeMax = true) {
            return min + GetFloat (includeMax) * (max - min);
        }
    }
}