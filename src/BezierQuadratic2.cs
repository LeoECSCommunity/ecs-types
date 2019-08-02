namespace Leopotam.Ecs.Types {
    /// <summary>
    /// Bezier curve with N = 2 based on <see cref="Float2"/>
    /// </summary>
    public struct BezierQuadratic2 {
        readonly Float2 _p0;
        readonly Float2 _p1;
        readonly Float2 _p2;

        /// <summary>
        /// Create new instance of curve.
        /// </summary>
        /// <param name="p0">Point 0.</param>
        /// <param name="p1">Point 1.</param>
        /// <param name="p2">Point 2.</param>
        public BezierQuadratic2 (Float2 p0, Float2 p1, Float2 p2) {
            _p0 = p0;
            _p1 = p1;
            _p2 = p2;
        }
        
        /// <summary>
        /// Evaluates curve at position.
        /// </summary>
        /// <param name="t">Position on curve, should be between 0 and 1.</param>
        /// <returns>Point on curve.</returns>
        public Float2 At (float t) {
            if (t <= 0) {
                return _p0;
            }
            if (t >= 1f) {
                return _p2;
            }
            
            float t1 = 1f - t;
            float sqrT1 = t1 * t1;
            float sqrT = t * t;
            return _p0 * sqrT1 + _p1 * 2f * t * t1 + _p2 * sqrT;
        }
    }
}