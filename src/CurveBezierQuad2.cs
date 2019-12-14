// ----------------------------------------------------------------------------
// The MIT License
// Types for Entity Component System framework https://github.com/Leopotam/ecs
// Copyright (c) 2017-2019 Leopotam <leopotam@gmail.com>
// With help from Farley Drunk <https://github.com/SH42913>
// ----------------------------------------------------------------------------

namespace Leopotam.Ecs.Types {
    /// <summary>
    /// Bezier curve with N = 2 based on <see cref="Float2"/>
    /// </summary>
    public struct CurveBezierQuad2 {
        public readonly Float2 Point0;
        public readonly Float2 Point1;
        public readonly Float2 Point2;

        /// <summary>
        /// Second derivative(acceleration) of curve.
        /// </summary>
        public readonly Float2 Acceleration;

        readonly Float2 _velocityAt0;
        readonly Float2 _velocityAt1;

        /// <summary>
        /// Create new instance of curve.
        /// </summary>
        /// <param name="point0">Point 0.</param>
        /// <param name="point1">Point 1.</param>
        /// <param name="point2">Point 2.</param>
        public CurveBezierQuad2 (Float2 point0, Float2 point1, Float2 point2) {
            Point0 = point0;
            Point1 = point1;
            Point2 = point2;

            _velocityAt0 = GetVelocityAt (point0, point1, point2, 0f);
            _velocityAt1 = GetVelocityAt (point0, point1, point2, 1f);

            Acceleration = GetAcceleration (point0, point1, point2);
        }

        /// <summary>
        /// Evaluates first derivative(velocity) at position t.
        /// </summary>
        /// <param name="t">Position on curve, should be between 0 and 1.</param>
        public Float2 GetVelocityAt (float t) {
            if (t <= 0f) {
                return _velocityAt0;
            }
            if (t >= 1f) {
                return _velocityAt1;
            }

            return GetVelocityAt (Point0, Point1, Point2, t);
        }

        /// <summary>
        /// Calculate first derivative(velocity) of curve at position t.
        /// </summary>
        /// <param name="point0">Curve Point 0.</param>
        /// <param name="point1">Curve Point 1.</param>
        /// <param name="point2">Curve Point 2.</param>
        /// <param name="t">Position on curve, should be between 0 and 1.</param>
        public static Float2 GetVelocityAt (in Float2 point0, in Float2 point1, in Float2 point2, float t) {
            t = MathFast.Clamp01 (t);
            return (point1 - point0) * 2f * (1f - t) + (point2 - point1) * 2f * t;
        }

        /// <summary>
        /// Calculate second derivative(acceleration) of curve.
        /// </summary>
        /// <param name="point0">Curve Point 0.</param>
        /// <param name="point1">Curve Point 1.</param>
        /// <param name="point2">Curve Point 2.</param>
        public static Float2 GetAcceleration (in Float2 point0, in Float2 point1, in Float2 point2) {
            return (point2 - point1 * 2f + point0) * 2f;
        }

        /// <summary>
        /// Evaluates curve at position t.
        /// </summary>
        /// <param name="t">Position on curve, should be between 0 and 1.</param>
        public Float2 GetPointAt (float t) {
            if (t <= 0f) {
                return Point0;
            }
            if (t >= 1f) {
                return Point2;
            }

            var t1 = 1f - t;
            return Point0 * t1 * t1 + Point1 * 2f * t * t1 + Point2 * t * t;
        }
    }
}