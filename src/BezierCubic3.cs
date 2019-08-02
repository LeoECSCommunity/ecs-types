namespace Leopotam.Ecs.Types {
    /// <summary>
    /// Bezier curve with N = 3 based on <see cref="Float3"/>
    /// </summary>
    public struct BezierCubic3 {
        readonly Float3 _p0;
        readonly Float3 _p1;
        readonly Float3 _p2;
        readonly Float3 _p3;

        /// <summary>
        /// Create new instance of curve.
        /// </summary>
        /// <param name="p0">Point 0.</param>
        /// <param name="p1">Point 1.</param>
        /// <param name="p2">Point 2.</param>
        /// <param name="p3">Point 3.</param>
        public BezierCubic3 (Float3 p0, Float3 p1, Float3 p2, Float3 p3) {
            _p0 = p0;
            _p1 = p1;
            _p2 = p2;
            _p3 = p3;
        }
        
        /// <summary>
        /// Evaluates curve at position.
        /// </summary>
        /// <param name="t">Position on curve, should be between 0 and 1.</param>
        /// <returns>Point on curve.</returns>
        public Float3 At (float t) {
            if (t <= 0) {
                return _p0;
            }
            if (t >= 1f) {
                return _p3;
            }
            
            float t1 = 1f - t;
            float sqrT1 = t1 * t1;
            float cubT1 = sqrT1 * t1;
                
            float sqrT = t * t;
            float cubT = sqrT * t;
                
            return _p0 * cubT1 + _p1 * 3f * t * sqrT1 + _p2 * 3f * sqrT * t1 + _p3 * cubT;
        }
    }
}