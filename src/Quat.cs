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
    /// Quaternion.
    /// </summary>
    [Serializable]
    [StructLayout (LayoutKind.Sequential)]
    public struct Quat {
        public float X;

        public float Y;

        public float Z;

        public float W;

        static readonly Quat _identity = new Quat (0f, 0f, 0f, 1f);

        /// <summary>
        /// Creates new instance of vector.
        /// </summary>
        public Quat (float x, float y, float z, float w) {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>
        /// Normalizes vector inplace.
        /// </summary>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
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
        /// Returns identity quaternion.
        /// </summary>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Quat Identity () {
            return _identity;
        }

        /// <summary>
        /// Creates new instance of quaternion from euler angles.
        /// </summary>
        /// <param name="x">Rotation around x-axis in degrees.</param>
        /// <param name="y">Rotation around y-axis in degrees.</param>
        /// <param name="z">Rotation around z-axis in degrees.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Quat Euler (float x, float y, float z) {
            x *= MathFast.Deg2Rad;
            y *= MathFast.Deg2Rad;
            z *= MathFast.Deg2Rad;
            var yawHalf = x * 0.5f;
            var cosYawHalf = (float) System.Math.Cos (yawHalf);
            var sinYawHalf = (float) System.Math.Sin (yawHalf);
            var pitchHalf = y * 0.5f;
            var cosPitchHalf = (float) System.Math.Cos (pitchHalf);
            var sinPitchHalf = (float) System.Math.Sin (pitchHalf);
            var rollHalf = z * 0.5f;
            var cosRollHalf = (float) System.Math.Cos (rollHalf);
            var sinRollHalf = (float) System.Math.Sin (rollHalf);
            Quat result;
            result.X = sinYawHalf * cosPitchHalf * cosRollHalf + cosYawHalf * sinPitchHalf * sinRollHalf;
            result.Y = cosYawHalf * sinPitchHalf * cosRollHalf - sinYawHalf * cosPitchHalf * sinRollHalf;
            result.Z = cosYawHalf * cosPitchHalf * sinRollHalf - sinYawHalf * sinPitchHalf * cosRollHalf;
            result.W = cosYawHalf * cosPitchHalf * cosRollHalf + sinYawHalf * sinPitchHalf * sinRollHalf;
            return result;
        }

        /// <summary>
        /// Returns conjugate version of quaternion.
        /// </summary>
        /// <param name="lhs">Quaternion.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Quat Conjugate (ref Quat lhs) {
            Quat res;
            res.X = -lhs.X;
            res.Y = -lhs.Y;
            res.Z = -lhs.Z;
            res.W = -lhs.W;
            return res;
        }

        /// <summary>
        /// Returns linear interpolated quaternion between start and end quaternions.
        /// </summary>
        /// <param name="lhs">Start quaternion.</param>
        /// <param name="rhs">End quaternion.</param>
        /// <param name="t">Factor in range [0f,1f].</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Quat Lerp (ref Quat lhs, Quat rhs, float t) {
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

        /// <summary>
        /// Returns result of multiplied quaternions.
        /// </summary>
        /// <param name="lhs">First quaternion.</param>
        /// <param name="rhs">Second quaternion.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Quat Mul (ref Quat lhs, ref Quat rhs) {
            Quat q;
            q.W = lhs.W * rhs.W - lhs.X * rhs.X - lhs.Y * rhs.Y - lhs.Z * rhs.Z;
            q.X = lhs.W * rhs.X + lhs.X * rhs.W + lhs.Y * rhs.Z - lhs.Z * rhs.Y;
            q.Y = lhs.W * rhs.Y + lhs.Y * rhs.W + lhs.Z * rhs.X - lhs.X * rhs.Z;
            q.Z = lhs.W * rhs.Z + lhs.Z * rhs.W + lhs.X * rhs.Y - lhs.Y * rhs.X;
            return q;
        }

        /// <summary>
        /// Returns equality of quaternions.
        /// </summary>
        /// <param name="lhs">First quaternion.</param>
        /// <param name="rhs">Second quaternion.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static bool Equals (ref Quat lhs, ref Quat rhs) {
            return (lhs.X - rhs.X) * (lhs.X - rhs.X) + (lhs.Y - rhs.Y) * (lhs.Y - rhs.Y) + (lhs.Z - rhs.Z) * (lhs.Z - rhs.Z) + (lhs.W - rhs.W) * (lhs.W - rhs.W) < MathFast.Epsilon * MathFast.Epsilon;
        }

        /// <summary>
        /// Transforms point with quaternion.
        /// </summary>
        /// <param name="quat">Quaternion.</param>
        /// <param name="point">Point.</param>
#if NET_4_6 || NET_STANDARD_2_0
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static Float3 Transform (ref Quat quat, ref Float3 point) {
            var x2 = quat.X + quat.X;
            var y2 = quat.Y + quat.Y;
            var z2 = quat.Z + quat.Z;
            var wx2 = quat.W * x2;
            var wy2 = quat.W * y2;
            var wz2 = quat.W * z2;
            var xx2 = quat.X * x2;
            var xy2 = quat.X * y2;
            var xz2 = quat.X * z2;
            var yy2 = quat.Y * y2;
            var yz2 = quat.Y * z2;
            var zz2 = quat.Z * z2;
            var x = ((point.X * ((1f - yy2) - zz2)) + (point.Y * (xy2 - wz2))) + (point.Z * (xz2 + wy2));
            var y = ((point.X * (xy2 + wz2)) + (point.Y * ((1f - xx2) - zz2))) + (point.Z * (yz2 - wx2));
            var z = ((point.X * (xz2 - wy2)) + (point.Y * (yz2 + wx2))) + (point.Z * ((1f - xx2) - yy2));
            Float3 v;
            v.X = x;
            v.Y = y;
            v.Z = z;
            return v;
        }

#if UNITY_5_6_OR_NEWER
        public static implicit operator UnityEngine.Quaternion (Quat v) {
            UnityEngine.Quaternion res;
            res.x = v.X;
            res.y = v.Y;
            res.z = v.Z;
            res.w = v.W;
            return res;
        }

        public static implicit operator Quat (UnityEngine.Quaternion v) {
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