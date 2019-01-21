// ----------------------------------------------------------------------------
// The MIT License
// Types for Entity Component System framework https://github.com/Leopotam/ecs
// Copyright (c) 2017-2019 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;

#if NET_4_6 || NET_STANDARD_2_0
using System.Runtime.CompilerServices;
#endif

namespace Leopotam.Ecs.Types {
    /// <summary>
    /// 3D box with float components.
    /// </summary>
    [Serializable]
    [StructLayout (LayoutKind.Sequential)]
    public struct FloatBox3 {
        public enum ContainmentType {
            Disjoint,
            Contains,
            Intersects
        }

        /// <summary>
        /// The minimum point of the box.
        /// </summary>
        public Float3 Min;

        /// <summary>
        /// The maximum point of the box.
        /// </summary>
        public Float3 Max;

        /// <summary>
        /// Returns the smallest box possible.
        /// </summary>
        public static readonly FloatBox3 SmallBox = new FloatBox3 () {
            Min = new Float3 (float.MaxValue, float.MaxValue, float.MaxValue),
            Max = new Float3 (float.MinValue, float.MinValue, float.MinValue)
        };

        /// <summary>
        /// Returns the largest box possible.
        /// </summary>
        public static readonly FloatBox3 LargeBox = new FloatBox3 () {
            Min = new Float3 (float.MinValue, float.MinValue, float.MinValue),
            Max = new Float3 (float.MaxValue, float.MaxValue, float.MaxValue)
        };

        /// <summary>
        /// Constructor
        /// </summary>
        public FloatBox3 (Float3 min, Float3 max) {
            this.Min = min;
            this.Max = max;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public FloatBox3 (ref Float3 min, ref Float3 max) {
            this.Min = min;
            this.Max = max;
        }

        /// <summary>
        /// Transforms the bounding box into the space given by orientation and position.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="orientation"></param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void InverseTransform (ref Float3 position, ref Float3x3 orientation) {
            Max = Float3.Sub (ref Max, ref position);
            Min = Float3.Sub (ref Min, ref position);

            Float3 center;
            center.X = (Min.X + Max.X) * 0.5f;
            center.Y = (Min.Y + Max.Y) * 0.5f;
            center.Z = (Min.Z + Max.Z) * 0.5f;

            Float3 halfExtents;
            halfExtents.X = (Max.X - Min.X) * 0.5f;
            halfExtents.Y = (Max.Y - Min.Y) * 0.5f;
            halfExtents.Z = (Max.Z - Min.Z) * 0.5f;

            center = Float3x3.TransposedTransform (ref orientation, ref center);

            var abs = Float3x3.Abs (ref orientation);
            halfExtents = Float3x3.TransposedTransform (ref abs, ref halfExtents);

            Min = Float3.Sub (ref center, ref halfExtents);
            Max = Float3.Add (ref center, ref halfExtents);
        }

#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void Transform (ref Float3x3 orientation) {
            Float3 center;
            center.X = (Min.X + Max.X) * 0.5f;
            center.Y = (Min.Y + Max.Y) * 0.5f;
            center.Z = (Min.Z + Max.Z) * 0.5f;

            Float3 halfExtents;
            halfExtents.X = (Max.X - Min.X) * 0.5f;
            halfExtents.Y = (Max.Y - Min.Y) * 0.5f;
            halfExtents.Z = (Max.Z - Min.Z) * 0.5f;

            center = Float3x3.Transform (ref orientation, ref center);

            var abs = Float3x3.Abs (ref orientation);
            halfExtents = Float3x3.Transform (ref abs, ref halfExtents);

            Min = Float3.Sub (ref center, ref halfExtents);
            Max = Float3.Add (ref center, ref halfExtents);
        }

        /// <summary>
        /// Checks whether a point is inside, outside or intersecting
        /// a point.
        /// </summary>
        /// <returns>The ContainmentType of the point.</returns>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        static bool Intersect1D (float start, float dir, float min, float max, ref float enter, ref float exit) {
            if (dir * dir < MathFast.Epsilon * MathFast.Epsilon) {
                return start >= min && start <= max;
            }
            var t0 = (min - start) / dir;
            var t1 = (max - start) / dir;
            if (t0 > t1) {
                var tmp = t0;
                t0 = t1;
                t1 = tmp;
            }
            if (t0 > exit || t1 < enter) {
                return false;
            }
            if (t0 > enter) {
                enter = t0;
            }
            if (t1 < exit) {
                exit = t1;
            }
            return true;
        }

#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static bool SegmentIntersect (ref FloatBox3 box, ref Float3 origin, ref Float3 direction) {
            var enter = 0f;
            var exit = 1f;
            return Intersect1D (origin.X, direction.X, box.Min.X, box.Max.X, ref enter, ref exit) &&
                Intersect1D (origin.Y, direction.Y, box.Min.Y, box.Max.Y, ref enter, ref exit) &&
                Intersect1D (origin.Z, direction.Z, box.Min.Z, box.Max.Z, ref enter, ref exit);
        }

#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static bool RayIntersect (ref FloatBox3 box, ref Float3 origin, ref Float3 direction) {
            var enter = 0f;
            var exit = float.MaxValue;
            return Intersect1D (origin.X, direction.X, box.Min.X, box.Max.X, ref enter, ref exit) &&
                Intersect1D (origin.Y, direction.Y, box.Min.Y, box.Max.Y, ref enter, ref exit) &&
                Intersect1D (origin.Z, direction.Z, box.Min.Z, box.Max.Z, ref enter, ref exit);
        }

#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static bool Contains (ref FloatBox3 box, ref Float3 point) {
            return (box.Min.X <= point.X) && (point.X <= box.Max.X) &&
                (box.Min.Y <= point.Y) && (point.Y <= box.Max.Y) &&
                (box.Min.Z <= point.Z) && (point.Z <= box.Max.Z);
        }

        /// <summary>
        /// Retrieves the 8 corners of the box.
        /// </summary>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void GetCorners (Float3[] corners) {
            corners[0].Set (this.Min.X, this.Max.Y, this.Max.Z);
            corners[1].Set (this.Max.X, this.Max.Y, this.Max.Z);
            corners[2].Set (this.Max.X, this.Min.Y, this.Max.Z);
            corners[3].Set (this.Min.X, this.Min.Y, this.Max.Z);
            corners[4].Set (this.Min.X, this.Max.Y, this.Min.Z);
            corners[5].Set (this.Max.X, this.Max.Y, this.Min.Z);
            corners[6].Set (this.Max.X, this.Min.Y, this.Min.Z);
            corners[7].Set (this.Min.X, this.Min.Y, this.Min.Z);
        }

#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public void AddPoint (ref Float3 point) {
            Min = Float3.Min (ref this.Min, ref point);
            Max = Float3.Max (ref this.Max, ref point);
        }

#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static FloatBox3 CreateFromPoints (Float3[] points) {
            var min = new Float3 (float.MaxValue, float.MaxValue, float.MaxValue);
            var max = new Float3 (float.MinValue, float.MinValue, float.MinValue);
            for (var i = 0; i < points.Length; i++) {
                min = Float3.Min (ref min, ref points[i]);
                max = Float3.Max (ref max, ref points[i]);
            }
            FloatBox3 box;
            box.Min = min;
            box.Max = max;
            return box;
        }

#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static ContainmentType Contains (ref FloatBox3 lhs, ref FloatBox3 rhs) {
            if ((lhs.Max.X >= rhs.Min.X) && (lhs.Min.X <= rhs.Max.X) &&
                (lhs.Max.Y >= rhs.Min.Y) && (lhs.Min.Y <= rhs.Max.Y) &&
                (lhs.Max.Z >= rhs.Min.Z) && (lhs.Min.Z <= rhs.Max.Z)) {
                return (lhs.Min.X <= rhs.Min.X) && (rhs.Max.X <= lhs.Max.X) &&
                    (lhs.Min.Y <= rhs.Min.Y) && (rhs.Max.Y <= lhs.Max.Y) &&
                    (lhs.Min.Z <= rhs.Min.Z) && (rhs.Max.Z <= lhs.Max.Z) ? ContainmentType.Contains : ContainmentType.Intersects;
            }
            return ContainmentType.Disjoint;
        }

#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static FloatBox3 Join (ref FloatBox3 lhs, ref FloatBox3 rhs) {
            FloatBox3 res;
            res.Min = Float3.Min (ref lhs.Min, ref rhs.Min);
            res.Max = Float3.Max (ref lhs.Max, ref rhs.Max);
            return res;
        }

#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float3 Center (ref FloatBox3 box) {
            Float3 center;
            center.X = (box.Min.X + box.Max.X) * 0.5f;
            center.Y = (box.Min.Y + box.Max.Y) * 0.5f;
            center.Z = (box.Min.Z + box.Max.Z) * 0.5f;
            return center;
        }

#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static float Perimeter (ref FloatBox3 box) {
            return ((box.Max.X - box.Min.X) * (box.Max.Y - box.Min.Y) + (box.Max.X - box.Min.X) * (box.Max.Z - box.Min.Z) + (box.Max.Z - box.Min.Z) * (box.Max.Y - box.Min.Y)) * 2f;
        }
    }
}