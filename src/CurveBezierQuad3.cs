namespace Leopotam.Ecs.Types {
    /// <summary>
    /// Bezier curve with N = 2 based on <see cref="Float3"/>
    /// </summary>
    public struct CurveBezierQuad3 {
        readonly Float3 _p0;
        readonly Float3 _p1;
        readonly Float3 _p2;

        /// <summary>
        /// Create new instance of curve.
        /// </summary>
        /// <param name="p0">Point 0.</param>
        /// <param name="p1">Point 1.</param>
        /// <param name="p2">Point 2.</param>
        public CurveBezierQuad3 (Float3 p0, Float3 p1, Float3 p2) {
            _p0 = p0;
            _p1 = p1;
            _p2 = p2;
        }
        
        /// <summary>
        /// Evaluates first derivative(velocity) at position t.
        /// </summary>
        /// <param name="t">Position on curve, should be between 0 and 1.</param>
        /// <returns>Velocity Vector.</returns>
        public Float3 GetVelocityAt (float t) {
            if (t <= 0) {
                return GetVelocityAt(0);
            }
            if (t >= 1f) {
                return GetVelocityAt(1f);
            }
            
            return (_p1 - _p0) * 2f * (1f - t)  + (_p2 - _p1) * 2f * t;
        }
        
        /// <summary>
        /// Evaluates second derivative(acceleration) at position t.
        /// </summary>
        /// <param name="t">Position on curve, should be between 0 and 1.</param>
        /// <returns>Acceleration Vector.</returns>
        public Float3 GetAccelerationAt (float t) {
            if (t <= 0) {
                return GetAccelerationAt(0);
            }
            if (t >= 1f) {
                return GetAccelerationAt(1f);
            }
            
            return (_p2 - _p1 * 2f + _p0) * 2f;
        }
        
        /// <summary>
        /// Evaluates curve at position t.
        /// </summary>
        /// <param name="t">Position on curve, should be between 0 and 1.</param>
        /// <returns>Point on curve.</returns>
        public Float3 GetPointAt (float t) {
            if (t <= 0) {
                return _p0;
            }
            if (t >= 1f) {
                return _p2;
            }
            
            float t1 = 1f - t;
            return _p0 * t1 * t1 + _p1 * 2f * t * t1 + _p2 * t * t;
        }
    }
}