namespace Leopotam.Ecs.Types {
    /// <summary>
    /// Bezier curve with N = 3 based on <see cref="Float2"/>
    /// </summary>
    public struct CurveBezierCube2 {
        readonly Float2 _p0;
        readonly Float2 _p1;
        readonly Float2 _p2;
        readonly Float2 _p3;

        /// <summary>
        /// Create new instance of curve.
        /// </summary>
        /// <param name="p0">Point 0.</param>
        /// <param name="p1">Point 1.</param>
        /// <param name="p2">Point 2.</param>
        /// <param name="p3">Point 3.</param>
        public CurveBezierCube2 (Float2 p0, Float2 p1, Float2 p2, Float2 p3) {
            _p0 = p0;
            _p1 = p1;
            _p2 = p2;
            _p3 = p3;
        }
        
        /// <summary>
        /// Evaluates first derivative(velocity) at position t.
        /// </summary>
        /// <param name="t">Position on curve, should be between 0 and 1.</param>
        /// <returns>Velocity Vector.</returns>
        public Float2 GetVelocityAt (float t) {
            if (t <= 0) {
                return GetVelocityAt(0);
            }
            if (t >= 1f) {
                return GetVelocityAt(1f);
            }
            
            float t1 = 1f - t;
            float sqrT1 = t1 * t1;
            return (_p1 - _p0) * 3f * sqrT1  + (_p2 - _p1) * 6f * t1 * t + (_p3 - _p2) * 3f * t * t;
        }
        
        /// <summary>
        /// Evaluates second derivative(acceleration) at position t.
        /// </summary>
        /// <param name="t">Position on curve, should be between 0 and 1.</param>
        /// <returns>Acceleration Vector.</returns>
        public Float2 GetAccelerationAt (float t) {
            if (t <= 0) {
                return GetAccelerationAt(0);
            }
            if (t >= 1f) {
                return GetAccelerationAt(1f);
            }
            
            return (_p2 - _p1 * 2f + _p0) * 6f * (1 - t) + (_p3 - _p2 * 2f + _p1) * 6f * t;
        }
        
        /// <summary>
        /// Evaluates curve at position t.
        /// </summary>
        /// <param name="t">Position on curve, should be between 0 and 1.</param>
        /// <returns>Point on curve.</returns>
        public Float2 GetPointAt (float t) {
            if (t <= 0) {
                return _p0;
            }
            if (t >= 1f) {
                return _p3;
            }
            
            float t1 = 1f - t;
            float sqrT1 = t1 * t1;
            float sqrT = t * t;
            return _p0 * sqrT1 * t1 + _p1 * 3f * t * sqrT1 + _p2 * 3f * sqrT * t1 + _p3 * sqrT * t;
        }
    }
}