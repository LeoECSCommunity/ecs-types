// ----------------------------------------------------------------------------
// The MIT License
// Types for Entity Component System framework https://github.com/Leopotam/ecs
// Copyright (c) 2017-2019 Leopotam <leopotam@gmail.com>
// With help from Farley Drunk <https://github.com/SH42913>
// ----------------------------------------------------------------------------

namespace Leopotam.Ecs.Types {
    /// <summary>
    /// Bezier curve with N = 3 based on <see cref="Float3"/>
    /// </summary>
    public struct CurveBezierCube3 {
        public readonly Float3 Point0;
        public readonly Float3 Point1;
        public readonly Float3 Point2;
        public readonly Float3 Point3;

        readonly Float3 _velocityAt0;
        readonly Float3 _velocityAt1;

        readonly Float3 _accelerationAt0;
        readonly Float3 _accelerationAt1;

        /// <summary>
        /// Create new instance of curve.
        /// </summary>
        /// <param name="point0">Point 0.</param>
        /// <param name="point1">Point 1.</param>
        /// <param name="point2">Point 2.</param>
        /// <param name="point3">Point 3.</param>
        public CurveBezierCube3 (Float3 point0, Float3 point1, Float3 point2, Float3 point3) {
            Point0 = point0;
            Point1 = point1;
            Point2 = point2;
            Point3 = point3;

            _velocityAt0 = GetVelocityAt (point0, point1, point2, point3, 0f);
            _velocityAt1 = GetVelocityAt (point0, point1, point2, point3, 1f);

            _accelerationAt0 = GetAccelerationAt (point0, point1, point2, point3, 0f);
            _accelerationAt1 = GetAccelerationAt (point0, point1, point2, point3, 1f);
        }

        /// <summary>
        /// Evaluates first derivative(velocity) at position t.
        /// </summary>
        /// <param name="t">Position on curve, should be between 0 and 1.</param>
        public Float3 GetVelocityAt (float t) {
            if (t <= 0f) {
                return _velocityAt0;
            }
            if (t >= 1f) {
                return _velocityAt1;
            }

            return GetVelocityAt (Point0, Point1, Point2, Point3, t);
        }

        /// <summary>
        /// Calculate first derivative(velocity) of curve at position t.
        /// </summary>
        /// <param name="point0">Curve Point 0.</param>
        /// <param name="point1">Curve Point 1.</param>
        /// <param name="point2">Curve Point 2.</param>
        /// <param name="point3">Curve Point 3.</param>
        /// <param name="t">Position on curve, should be between 0 and 1.</param>
        public static Float3 GetVelocityAt (in Float3 point0, in Float3 point1, in Float3 point2, in Float3 point3, float t) {
            t = MathFast.Clamp01 (t);
            var t1 = 1f - t;
            var sqrT1 = t1 * t1;
            return (point1 - point0) * 3f * sqrT1 + (point2 - point1) * 6f * t1 * t + (point3 - point2) * 3f * t * t;
        }

        /// <summary>
        /// Evaluates second derivative(acceleration) at position t.
        /// </summary>
        /// <param name="t">Position on curve, should be between 0 and 1.</param>
        public Float3 GetAccelerationAt (float t) {
            if (t <= 0f) {
                return _accelerationAt0;
            }
            if (t >= 1f) {
                return _accelerationAt1;
            }

            return GetAccelerationAt (Point0, Point1, Point2, Point3, t);
        }

        /// <summary>
        /// Calculate second derivative(acceleration) of curve.
        /// </summary>
        /// <param name="point0">Curve Point 0.</param>
        /// <param name="point1">Curve Point 1.</param>
        /// <param name="point2">Curve Point 2.</param>
        /// <param name="point3">Curve Point 3.</param>
        /// <param name="t">Position on curve, should be between 0 and 1.</param>
        public static Float3 GetAccelerationAt (in Float3 point0, in Float3 point1, in Float3 point2, in Float3 point3, float t) {
            t = MathFast.Clamp01 (t);
            return (point2 - point1 * 2f + point0) * 6f * (1f - t) + (point3 - point2 * 2f + point1) * 6f * t;
        }

        /// <summary>
        /// Evaluates curve at position t.
        /// </summary>
        /// <param name="t">Position on curve, should be between 0 and 1.</param>
        public Float3 GetPointAt (float t) {
            if (t <= 0f) {
                return Point0;
            }
            if (t >= 1f) {
                return Point3;
            }

            var t1 = 1f - t;
            var sqrT1 = t1 * t1;
            var sqrT = t * t;
            return Point0 * sqrT1 * t1 + Point1 * 3f * t * sqrT1 + Point2 * 3f * sqrT * t1 + Point3 * sqrT * t;
        }
    }
}