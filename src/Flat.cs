// ----------------------------------------------------------------------------
// The MIT License
// Types for Entity Component System framework https://github.com/Leopotam/ecs
// Copyright (c) 2017-2019 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Leopotam.Ecs.Types {
    /// <summary>
    /// Representation of plane in 3d space. Uses the formula Ax + By + Cz + D = 0.
    /// </summary>
    [Serializable]
    [StructLayout (LayoutKind.Sequential)]
    public struct Flat {
        public Float3 Normal;
        public float Distance;

        /// <summary>
        /// Creates a plane.
        /// </summary>
        /// <param name="inNormal">Normal vector, must be normalized.</param>
        /// <param name="inPoint">Point on plane.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public Flat (in Float3 inNormal, in Float3 inPoint) {
            Normal = inNormal;
            Distance = -Float3.Dot (Normal, inPoint);
        }

        /// <summary>
        /// Creates a plane.
        /// </summary>
        /// <param name="inNormal">Normal vector, must be normalized.</param>
        /// <param name="d">Distance.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public Flat (in Float3 inNormal, float d) {
            Normal = inNormal;
            Distance = d;
        }

        /// <summary>
        /// Creates a plane by 3 points.
        /// </summary>
        /// <param name="a">First point on plane.</param>
        /// <param name="b">Second point on plane.</param>
        /// <param name="c">Third point on plane.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public Flat (in Float3 a, in Float3 b, in Float3 c) {
            Normal = Float3.Cross (b - a, c - a);
            Normal.Normalize ();
            Distance = -Float3.Dot (Normal, a);
        }

        /// <summary>
        /// Makes plane face in opposite direction.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public void Flip () {
            Normal.X = -Normal.X;
            Normal.Y = -Normal.Y;
            Normal.Z = -Normal.Z;
            Distance = -Distance;
        }

        /// <summary>
        /// Returns flipped version of the plane (faced in opposite direction).
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public Flat GetFlipped () {
            Flat res;
            res.Normal.X = -Normal.X;
            res.Normal.Y = -Normal.Y;
            res.Normal.Z = -Normal.Z;
            res.Distance = -Distance;
            return res;
        }

        /// <summary>
        /// Translates plane to offset.
        /// </summary>
        /// <param name="offset">Offset.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public void Translate (in Float3 offset) {
            Distance += Float3.Dot (Normal, offset);
        }

        /// <summary>
        /// Calculates closest point on plane.
        /// </summary>
        /// <param name="point">Point to sample.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public Float3 GetProjectionOf (in Float3 point) {
            return point - (Normal * (Float3.Dot (Normal, point) + Distance));
        }

        /// <summary>
        /// Returns a signed distance from point to plane.
        /// </summary>
        /// <param name="point">Point to sample.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public float GetDistanceToPoint (in Float3 point) {
            return Float3.Dot (Normal, point) + Distance;
        }

        // Is a point on the positive side of the plane?
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public bool IsPointOnPositiveSide (in Float3 point) {
            return (Float3.Dot (Normal, point) + Distance) > 0f;
        }

        /// <summary>
        /// Are two points on the same side of the plane?
        /// </summary>
        /// <param name="a">First point.</param>
        /// <param name="b">Second point.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public bool ArePointsOnSameSide (in Float3 a, in Float3 b) {
            var d0 = Float3.Dot (Normal, a) + Distance;
            var d1 = Float3.Dot (Normal, b) + Distance;
            return (d0 > 0f && d1 > 0f) || (d0 <= 0f && d1 <= 0f);
        }

        /// <summary>
        /// Intersects a ray with the plane.
        /// </summary>
        /// <param name="beam">Ray to cast.</param>
        /// <param name="enter">Result distance to plane.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public bool Raycast (in Beam3 beam, out float enter) {
            var dot = Float3.Dot (beam.Direction, Normal);
            if (dot * dot < MathFast.Epsilon) {
                enter = 0f;
                return false;
            }
            enter = (-Float3.Dot (beam.Origin, Normal) - Distance) / dot;
            return enter > 0f;
        }

#if UNITY_2018_3_OR_NEWER
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static implicit operator UnityEngine.Plane (in Flat v) {
            return new UnityEngine.Plane (v.Normal, v.Distance);
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static implicit operator Flat (in UnityEngine.Plane v) {
            Flat res;
            res.Normal = v.normal;
            res.Distance = v.distance;
            return res;
        }
#endif
    }
}