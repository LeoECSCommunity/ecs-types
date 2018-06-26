// ----------------------------------------------------------------------------
// The MIT License
// Types for Entity Component System framework https://github.com/Leopotam/ecs
// Copyright (c) 2017-2018 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;

#if NET_4_6
using System.Runtime.CompilerServices;
#endif

namespace Leopotam.Ecs.Types {
    [Serializable]
    [StructLayout (LayoutKind.Sequential)]
    public struct Quat {
        public float X;

        public float Y;

        public float Z;

        public float W;

        public Quat (float x, float y, float z, float w) {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public Quat (float pitch, float yaw, float roll) {
            var sinPitch = (float) Math.Sin (pitch * 0.5f);
            var cosPitch = (float) Math.Cos (pitch * 0.5f);
            var sinYaw = (float) Math.Sin (yaw * 0.5f);
            var cosYaw = (float) Math.Cos (yaw * 0.5f);
            var sinRoll = (float) Math.Sin (roll * 0.5f);
            var cosRoll = (float) Math.Cos (roll * 0.5f);
            var cosPitchCosYaw = cosPitch * cosYaw;
            var sinPitchSinYaw = sinPitch * sinYaw;
            X = (sinRoll * cosPitchCosYaw) - (cosRoll * sinPitchSinYaw);
            Y = (cosRoll * sinPitch * cosYaw) + (sinRoll * cosPitch * sinYaw);
            Z = (cosRoll * cosPitch * sinYaw) - (sinRoll * sinPitch * cosYaw);
            W = (cosRoll * cosPitchCosYaw) + (sinRoll * sinPitchSinYaw);
        }

        public void Normalize () {
            var invMagnitude = 1f / (float) Math.Sqrt (X * X + Y * Y + Z * Z + W * W);
            X *= invMagnitude;
            Y *= invMagnitude;
            Z *= invMagnitude;
            W *= invMagnitude;
        }

        public Float4x4 ToMatrix () {
            var xx = X * X;
            var yy = Y * Y;
            var zz = Z * Z;
            var xy = X * Y;
            var zw = Z * W;
            var zx = Z * X;
            var yw = Y * W;
            var yz = Y * Z;
            var xw = X * W;
            Float4x4 mat;
            mat.M11 = 1f - 2f * (yy + zz);
            mat.M12 = 2f * (xy - zw);
            mat.M13 = 2f * (zx + yw);
            mat.M14 = 0f;
            mat.M21 = 2f * (xy + zw);
            mat.M22 = 1f - 2f * (zz + xx);
            mat.M23 = 2f * (yz - xw);
            mat.M24 = 0f;
            mat.M31 = 2f * (zx - yw);
            mat.M32 = 2f * (yz + xw);
            mat.M33 = 1f - 2f * (yy + xx);
            mat.M34 = 0f;
            mat.M41 = 0f;
            mat.M42 = 0f;
            mat.M43 = 0f;
            mat.M44 = 1f;
            return mat;
        }

#if NET_4_6
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

        public static Quat Slerp (ref Quat start, Quat end, float factor) {
            var cosTheta = start.X * end.X + start.Y * end.Y + start.Z * end.Z + start.W * end.W;
            if (cosTheta < 0f) {
                cosTheta = -cosTheta;
                end.X = -end.X;
                end.Y = -end.Y;
                end.Z = -end.Z;
                end.W = -end.W;
            }

            float a, b;
            if ((1f - cosTheta) > float.Epsilon) {
                var omega = (float) Math.Acos (cosTheta); //extract theta from the product's cos theta
                var sinom = (float) Math.Sin (omega);
                a = (float) Math.Sin ((1f - factor) * omega) / sinom;
                b = (float) Math.Sin (factor * omega) / sinom;
            } else {
                a = 1f - factor;
                b = factor;
            }

            Quat q;
            q.X = (a * start.X) + (b * end.X);
            q.Y = (a * start.Y) + (b * end.Y);
            q.Z = (a * start.Z) + (b * end.Z);
            q.W = (a * start.W) + (b * end.W);
            return q;
        }

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

        public static Quat Mul (ref Quat a, ref Quat b) {
            Quat q;
            q.W = a.W * b.W - a.X * b.X - a.Y * b.Y - a.Z * b.Z;
            q.X = a.W * b.X + a.X * b.W + a.Y * b.Z - a.Z * b.Y;
            q.Y = a.W * b.Y + a.Y * b.W + a.Z * b.X - a.X * b.Z;
            q.Z = a.W * b.Z + a.Z * b.W + a.X * b.Y - a.Y * b.X;
            return q;
        }

#if NET_4_6
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
#endif
        public static bool Equals (ref Quat lhs, ref Quat rhs) {
            return (lhs.X - rhs.X) * (lhs.X - rhs.X) + (lhs.Y - rhs.Y) * (lhs.Y - rhs.Y) + (lhs.Z - rhs.Z) * (lhs.Z - rhs.Z) + (lhs.W - rhs.W) * (lhs.W - rhs.W) < float.Epsilon * float.Epsilon;
        }
    }
}