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
    /// Quaternion.
    /// </summary>
    [Serializable]
    [StructLayout (LayoutKind.Sequential)]
    public struct Quat {
        public float X;
        public float Y;
        public float Z;
        public float W;

        public static readonly Quat Identity = new Quat (0f, 0f, 0f, 1f);

        /// <summary>
        /// Creates new instance of vector.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public Quat (float x, float y, float z, float w) {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>
        /// Normalizes vector inplace.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public void Normalize () {
            var invMagnitude = 1f / (float) Math.Sqrt (X * X + Y * Y + Z * Z + W * W);
            X *= invMagnitude;
            Y *= invMagnitude;
            Z *= invMagnitude;
            W *= invMagnitude;
        }

#if DEBUG
        public override string ToString () {
            return string.Format (System.Globalization.CultureInfo.InvariantCulture, "({0:F5}, {1:F5}, {2:F5}, {3:F5})", X, Y, Z, W);
        }
#endif

        /// <summary>
        /// Returns conjugate version of quaternion.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public Quat GetConjugated () {
            Quat res;
            res.X = -X;
            res.Y = -Y;
            res.Z = -Z;
            res.W = -W;
            return res;
        }

        /// <summary>
        /// Creates new instance of quaternion from euler angles.
        /// </summary>
        /// <param name="x">Rotation around x-axis in degrees.</param>
        /// <param name="y">Rotation around y-axis in degrees.</param>
        /// <param name="z">Rotation around z-axis in degrees.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Quat FromEuler (float x, float y, float z) {
            x *= MathFast.Deg2Rad;
            y *= MathFast.Deg2Rad;
            z *= MathFast.Deg2Rad;
            var yawHalf = x * 0.5f;
            var cosYawHalf = (float) Math.Cos (yawHalf);
            var sinYawHalf = (float) Math.Sin (yawHalf);
            var pitchHalf = y * 0.5f;
            var cosPitchHalf = (float) Math.Cos (pitchHalf);
            var sinPitchHalf = (float) Math.Sin (pitchHalf);
            var rollHalf = z * 0.5f;
            var cosRollHalf = (float) Math.Cos (rollHalf);
            var sinRollHalf = (float) Math.Sin (rollHalf);
            Quat result;
            result.X = sinYawHalf * cosPitchHalf * cosRollHalf + cosYawHalf * sinPitchHalf * sinRollHalf;
            result.Y = cosYawHalf * sinPitchHalf * cosRollHalf - sinYawHalf * cosPitchHalf * sinRollHalf;
            result.Z = cosYawHalf * cosPitchHalf * sinRollHalf - sinYawHalf * sinPitchHalf * cosRollHalf;
            result.W = cosYawHalf * cosPitchHalf * cosRollHalf + sinYawHalf * sinPitchHalf * sinRollHalf;
            return result;
        }

        /// <summary>
        /// Returns linear interpolated quaternion between start and end quaternions.
        /// </summary>
        /// <param name="lhs">Start quaternion.</param>
        /// <param name="rhs">End quaternion.</param>
        /// <param name="t">Factor in range [0f,1f].</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Quat Lerp (in Quat lhs, in Quat rhs, float t) {
            if (t > 1f) {
                return rhs;
            } else {
                if (t < 0f) {
                    return lhs;
                }
            }
            Quat res;
            res.X = (rhs.X - lhs.X) * t + lhs.X;
            res.Y = (rhs.Y - lhs.Y) * t + lhs.Y;
            res.Z = (rhs.Z - lhs.Z) * t + lhs.Z;
            res.W = (rhs.W - lhs.W) * t + lhs.W;
            res.Normalize ();
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        [System.Runtime.TargetedPatchingOptOut ("")]
        public static Quat operator * (in Quat lhs, in Quat rhs) {
            Quat q;
            q.W = lhs.W * rhs.W - lhs.X * rhs.X - lhs.Y * rhs.Y - lhs.Z * rhs.Z;
            q.X = lhs.W * rhs.X + lhs.X * rhs.W + lhs.Y * rhs.Z - lhs.Z * rhs.Y;
            q.Y = lhs.W * rhs.Y + lhs.Y * rhs.W + lhs.Z * rhs.X - lhs.X * rhs.Z;
            q.Z = lhs.W * rhs.Z + lhs.Z * rhs.W + lhs.X * rhs.Y - lhs.Y * rhs.X;
            return q;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Float3 operator * (in Quat lhs, in Float3 rhs) {
            var x2 = lhs.X + lhs.X;
            var y2 = lhs.Y + lhs.Y;
            var z2 = lhs.Z + lhs.Z;
            var wx2 = lhs.W * x2;
            var wy2 = lhs.W * y2;
            var wz2 = lhs.W * z2;
            var xx2 = lhs.X * x2;
            var xy2 = lhs.X * y2;
            var xz2 = lhs.X * z2;
            var yy2 = lhs.Y * y2;
            var yz2 = lhs.Y * z2;
            var zz2 = lhs.Z * z2;
            Float3 res;
            res.X = ((rhs.X * ((1f - yy2) - zz2)) + (rhs.Y * (xy2 - wz2))) + (rhs.Z * (xz2 + wy2));
            res.Y = ((rhs.X * (xy2 + wz2)) + (rhs.Y * ((1f - xx2) - zz2))) + (rhs.Z * (yz2 - wx2));
            res.Z = ((rhs.X * (xz2 - wy2)) + (rhs.Y * (yz2 + wx2))) + (rhs.Z * ((1f - xx2) - yy2));
            return res;
        }

#if UNITY_2018_3_OR_NEWER
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static implicit operator UnityEngine.Quaternion (in Quat v) {
            UnityEngine.Quaternion res;
            res.x = v.X;
            res.y = v.Y;
            res.z = v.Z;
            res.w = v.W;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static implicit operator Quat (in UnityEngine.Quaternion v) {
            Quat res;
            res.X = v.x;
            res.Y = v.y;
            res.Z = v.z;
            res.W = v.w;
            return res;
        }
#endif
    }
}