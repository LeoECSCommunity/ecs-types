// ----------------------------------------------------------------------------
// The MIT License
// Types for Entity Component System framework https://github.com/Leopotam/ecs
// Copyright (c) 2017-2019 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

using System;

namespace Leopotam.Ecs.Types {
    /// <summary>
    /// Fixed-step values based 2d curve.
    /// </summary>
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public sealed class CurveFixed {
        readonly float[] _data;
        readonly float _minKey;
        readonly float _maxKey;
        readonly float _minValue;
        readonly float _maxValue;
        readonly float _invStepKey;

        /// <summary>
        /// Creates new instance of curve. Keys amount will be detected from values data.
        /// </summary>
        /// <param name="keyMin">Min value of keys sequence (left bound).</param>
        /// <param name="keyMax">Max value of keys sequence (right bound).</param>
        /// <param name="values">Evaluated data.</param>
        public CurveFixed (float keyMin, float keyMax, float[] values) {
#if DEBUG
            if (values == null || values.Length < 2) { throw new Exception ("data should contains 2 or more values."); }
            if (keyMax < keyMin) { throw new Exception ("max key should be greater than min key."); }
#endif
            _data = new float[values.Length];
            Array.Copy (values, 0, _data, 0, values.Length);
            _minKey = keyMin;
            _maxKey = keyMax;
            _minValue = _data[0];
            _maxValue = _data[_data.Length - 1];
            _invStepKey = (values.Length - 1) / (_maxKey - _minKey);
        }

        /// <summary>
        /// Creates new instance of curve.
        /// </summary>
        /// <param name="keyMin">Min value of keys sequence (left bound).</param>
        /// <param name="keyMax">Max value of keys sequence (right bound).</param>
        /// <param name="keysCount">Amount of keys.</param>
        /// <param name="cb">Function callback to evaluate.</param>
        public CurveFixed (float keyMin, float keyMax, int keysCount, Func<float, float> cb) {
#if DEBUG
            if (cb == null) { throw new ArgumentNullException (nameof (cb)); }
            if (keysCount <= 1) { throw new Exception ("keys amount should be greater or equal 2."); }
            if (keyMax < keyMin) { throw new Exception ("max should be greater than min."); }
#endif
            _data = new float[keysCount];
            _minKey = keyMin;
            _maxKey = keyMax;
            _minValue = _data[0];
            _maxValue = _data[_data.Length - 1];
            _invStepKey = (keysCount - 1) / (_maxKey - _minKey);

            var stepKey = 1f / _invStepKey;
            for (var i = 0; i <= keysCount; i++) {
                _data[i] = cb (_minKey + i * stepKey);
            }
        }

        /// <summary>
        /// Evaluates curve at position.
        /// </summary>
        /// <param name="v">Position.</param>
        [Obsolete ("Use At method instead")]
        public float Evaluate (float v) {
            return At (v);
        }

        /// <summary>
        /// Evaluates curve at position.
        /// </summary>
        /// <param name="v">Position.</param>
        public float At (float v) {
            if (v <= _minKey) {
                return _minValue;
            }
            if (v >= _maxKey) {
                return _maxValue;
            }
            var diff = (v - _minKey) * _invStepKey;
            var i = (int) diff;
            var a = _data[i];
            return a + (_data[i + 1] - a) * (diff - i);
        }
    }
}