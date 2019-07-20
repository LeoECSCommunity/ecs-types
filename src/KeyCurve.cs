using System;

namespace Leopotam.Ecs.Types {
    /// <summary>
    /// Key-value based 2d curve.
    /// </summary>
    public sealed class KeyCurve {
        readonly Float4[] _data;
        readonly int _maxIndex;
        readonly float _minKey;
        readonly float _maxKey;
        readonly float _minValue;
        readonly float _maxValue;

        /// <summary>
        /// Creates new instance of curve.
        /// </summary>
        /// <param name="keyframes">Key-value pairs.</param>
        public KeyCurve (params Float2[] keyframes) {
#if DEBUG
            if (keyframes == null || keyframes.Length < 2) { throw new Exception ("data should contains 2 keys or more"); }
#endif
            _data = new Float4[keyframes.Length];
            for (int i = 0; i < keyframes.Length; i++) {
                ref var d = ref _data[i];
                ref var s = ref keyframes[i];
                d.X = s.X;
                d.Y = s.Y;
            }
            Array.Sort (_data, (a, b) => { var diff = a.X - b.X; return diff > 0f ? 1 : (diff < 0f ? -1 : 0); });
            // precalculate math.
            for (int i = 0, iMax = _data.Length - 1; i < iMax; i++) {
                ref var a = ref _data[i];
                ref var b = ref _data[i + 1];
                // inv-key-diff * val-diff.
                a.Z = 1f / (b.X - a.X) * (b.Y - a.Y);
                // val - key * inv-key-diff * val-diff.
                a.W = a.Y - a.X * a.Z;
            }
            _maxIndex = _data.Length - 1;
            _minKey = _data[0].X;
            _minValue = _data[0].Y;
            _maxKey = _data[_maxIndex].X;
            _maxValue = _data[_maxIndex].Y;
        }

        /// <summary>
        /// Evaluates curve at position.
        /// </summary>
        /// <param name="v">Position.</param>
        public float Evaluate (float v) {
            if (v <= _minKey) {
                return _minValue;
            } else {
                if (v >= _maxKey) {
                    return _maxValue;
                }
            }
            // binary search.
            var lo = 0;
            var hi = _maxIndex;
            while (lo <= hi) {
                var i = lo + ((hi - lo) >> 1);
                if ((_data[i].X - v) <= 0f) {
                    lo = i + 1;
                } else {
                    hi = i - 1;
                }
            }
            //
            ref var a = ref _data[lo - 1];
            return v * a.Z + a.W;
        }
    }
}