﻿using System;

namespace UnrealEngine
{
    public struct Const
    {
        public const float PI = (3.1415926535897932f);
        public const float SMALL_NUMBER = (1.0e-8f);
        public const float KINDA_SMALL_NUMBER = (1.0e-4f);
        public const float BIG_NUMBER = (3.4e+38f);
        public const float EULERS_NUMBER = (2.71828182845904523536f);
        // Copied from float.h
        public const float MAX_FLT = 3.402823466e+38F;

        // Aux constants.
        public const float INV_PI = (0.31830988618f);
        public const float HALF_PI = (1.57079632679f);


        // Magic numbers for numerical precision.
        public const float DELTA = (0.00001f);

        /**
         * Lengths of normalized vectors (These are half their maximum values
         * to assure that dot products with normalized vectors don't overflow).
         */
        public const float FLOAT_NORMAL_THRESH = (0.0001f);

        //
        // Magic numbers for numerical precision.
        //
        public const float THRESH_POINT_ON_PLANE = (0.10f);		/* Thickness of plane for front/back/inside test */
        public const float THRESH_POINT_ON_SIDE = (0.20f);		/* Thickness of polygon side's side-plane for point-inside/outside/on side test */
        public const float THRESH_POINTS_ARE_SAME = (0.00002f);	/* Two points are same if within this distance */
        public const float THRESH_POINTS_ARE_NEAR = (0.015f);	/* Two points are near if within this distance and can be combined if imprecise math is ok */
        public const float THRESH_NORMALS_ARE_SAME = (0.00002f);    /* Two normal points are same if within this distance */
                                                                    /* Making this too large results in incorrect CSG classification and disaster */
        public const float THRESH_VECTORS_ARE_NEAR = (0.0004f); /* Two vectors are near if within this distance and can be combined if imprecise math is ok */
                                                                /* Making this too large results in lighting problems due to inaccurate texture coordinates */
        public const float THRESH_SPLIT_POLY_WITH_PLANE = (0.25f);		/* A plane splits a polygon in half */
        public const float THRESH_SPLIT_POLY_PRECISELY = (0.01f);		/* A plane exactly splits a polygon */
        public const float THRESH_ZERO_NORM_SQUARED = (0.0001f);	/* Size of a unit normal that is considered "zero", squared */
        public const float THRESH_NORMALS_ARE_PARALLEL = (0.999845f);	/* Two unit vectors are parallel if abs(A dot B) is greater than or equal to this. This is roughly cosine(1.0 degrees). */
        public const float THRESH_NORMALS_ARE_ORTHOGONAL = (0.017455f);	/* Two unit vectors are orthogonal (perpendicular) if abs(A dot B) is less than or equal this. This is roughly cosine(89.0 degrees). */

        /** Allowed error for a normalized vector (against squared magnitude) */
        public const float THRESH_VECTOR_NORMALIZED = (0.01f);
        /** Allowed error for a normalized quaternion (against squared magnitude) */
        public const float THRESH_QUAT_NORMALIZED = (0.01f);
    }
    public class Math
    {
        /**
            * Computes the sine and cosine of a scalar float.
            *
            * @param ScalarSin	Pointer to where the Sin result should be stored
            * @param ScalarCos	Pointer to where the Cos result should be stored
            * @param Value  input angles 
            */
        public static void SinCos(out float ScalarSin, out float ScalarCos, float Value)
        {
            // Map Value to y in [-pi,pi], x = 2*pi*quotient + remainder.
            float quotient = (Const.INV_PI * 0.5f) * Value;
            if (Value >= 0.0f)
            {
                quotient = (float)((int)(quotient + 0.5f));
            }
            else
            {
                quotient = (float)((int)(quotient - 0.5f));
            }
            float y = Value - (2.0f * Const.PI) * quotient;

            // Map y to [-pi/2,pi/2] with sin(y) = sin(Value).
            float sign;
            if (y > Const.HALF_PI)
            {
                y = Const.PI - y;
                sign = -1.0f;
            }
            else if (y < -Const.HALF_PI)
            {
                y = -Const.PI - y;
                sign = -1.0f;
            }
            else
            {
                sign = +1.0f;
            }

            float y2 = y * y;

            // 11-degree minimax approximation
            ScalarSin = (((((-2.3889859e-08f * y2 + 2.7525562e-06f) * y2 - 0.00019840874f) * y2 + 0.0083333310f) * y2 - 0.16666667f) * y2 + 1.0f) * y;

            // 10-degree minimax approximation
            float p = ((((-2.6051615e-07f * y2 + 2.4760495e-05f) * y2 - 0.0013888378f) * y2 + 0.041666638f) * y2 - 0.5f) * y2 + 1.0f;
            ScalarCos = sign * p;
        }

        public static float InvSqrt(float A)
        {
            return (float)(1.0f / System.Math.Sqrt(A));
        }

        public static Vector Lerp(Vector A, Vector B, float V)
        {
            return A + (B - A) * V;
        }

        public static float Lerp(float A, float B, float V)
        {
            return A + (B - A) * V;
        }

        public static float Clamp(float A, float min, float max)
        {
            return System.Math.Min(System.Math.Max(A, min), max);
        }
        public static int Clamp(int A, int min, int max)
        {
            return System.Math.Min(System.Math.Max(A, min), max);
        }

        public static float Max(float A, float B)
        {
            return System.Math.Max(A, B);
        }

        public static float Min(float A, float B)
        {
            return System.Math.Min(A, B);
        }

        public static int Sign(int A)
        {
            return System.Math.Sign(A);
        }

        public static float Sign(float A)
        {
            return System.Math.Sign(A);
        }

        public static float Abs(float A)
        {
            if (A >= 0)
            {
                return A;
            }
            else
            {
                return A * (-1);
            }
        }

        public static float FInterpTo(float Current, float Target, float DeltaTime, float InterpSpeed)
        {
            if (InterpSpeed <= 0f)
            {
                return Target;
            }

            float Dist = Target - Current;

            if (System.Math.Sqrt(Dist) < Const.SMALL_NUMBER)
            {
                return Target;
            }

            float DeltaMove = Dist * Clamp(DeltaTime * InterpSpeed, 0f, 1f);

            return Current + DeltaMove;
        }

        public static Vector2D Vector2DInterpTo( Vector2D Current, Vector2D Target, float DeltaTime, float InterpSpeed )
        {
	        if( InterpSpeed <= 0f )
	        {
		        return Target;
	        }

            var Dist = Target - Current;
	        if( Dist.SizeSquared() < Const.KINDA_SMALL_NUMBER)
	        {
		        return Target;
	        }

            var DeltaMove = Dist * Clamp(DeltaTime * InterpSpeed, 0f, 1f);
	        return Current + DeltaMove;
        }

        public static Vector VInterpTo(Vector Current, Vector Target, float DeltaTime, float InterpSpeed)
        {
            if (InterpSpeed <= 0f)
            {
                return Target;
            }

            var Dist = Target - Current;

            if (Dist.SizeSquared() < Const.KINDA_SMALL_NUMBER)
            {
                return Target;
            }

            var DeltaMove = Dist * Clamp(DeltaTime * InterpSpeed, 0f, 1f);

            return Current + DeltaMove;
        }

        public static Rotator RInterpTo(Rotator Current,Rotator Target, float DeltaTime, float InterpSpeed)
        {
	        // if DeltaTime is 0, do not perform any interpolation (Location was already calculated for that frame)
	        if( DeltaTime == 0f || Current == Target )
	        {
		        return Current;
	        }

	        // If no interp speed, jump to target value
	        if( InterpSpeed <= 0f )
	        {
		        return Target;
	        }

            float DeltaInterpSpeed = InterpSpeed * DeltaTime;

            var Delta = (Target - Current).GetNormalized();
	
	        // If steps are too small, just return Target and assume we have reached our destination.
	        if (Delta.IsNearlyZero(Const.KINDA_SMALL_NUMBER))
	        {
		        return Target;
	        }
	        // Delta Move, Clamp so we do not over shoot.
	        var DeltaMove = Delta * Clamp(DeltaInterpSpeed, 0f, 1f);
	        return (Current + DeltaMove).GetNormalized();
        }

        public static LinearColor CInterpTo(LinearColor Current, LinearColor Target, float DeltaTime, float InterpSpeed)
        {
	        // If no interp speed, jump to target value
	        if (InterpSpeed <= 0f)
	        {
		        return Target;
	        }

            // Difference between colors
            float Dist = LinearColor.Dist(Target, Current);

	        // If distance is too small, just set the desired color
	        if (Dist < Const.KINDA_SMALL_NUMBER)
	        {
		        return Target;
	        }

            // Delta change, Clamp so we do not over shoot.
            var DeltaMove = (Target - Current) * Math.Clamp(DeltaTime * InterpSpeed, 0f, 1f);

	        return Current + DeltaMove;
        }

        public static Quat QInterpTo(Quat Current, Quat Target, float DeltaTime, float InterpSpeed)
        {
            // if DeltaTime is 0, do not perform any interpolation (Location was already calculated for that frame)
            if (DeltaTime == 0f || Current == Target)
            {
                return Current;
            }

            // If no interp speed, jump to target value
            if (InterpSpeed <= 0f)
            {
                return Target;
            }

            float DeltaInterpSpeed = InterpSpeed * DeltaTime;

            var Delta = (Target - Current).GetNormalized();


            // If steps are too small, just return Target and assume we have reached our destination.
            if (Delta.SizeSquared() < Const.KINDA_SMALL_NUMBER)
            {
                return Target;
            }
            // Delta Move, Clamp so we do not over shoot.
            var DeltaMove = Delta * Clamp(DeltaInterpSpeed, 0f, 1f);
            return (Current + DeltaMove).GetNormalized();
        }

        public static float RandomInRange(float MinValue, float MaxValue)
        {
            if (MinValue == MaxValue)
            {
                return MinValue;
            }

            float Dist = MaxValue - MinValue;

            if (System.Math.Sqrt(Dist) < Const.SMALL_NUMBER)
            {
                return MinValue;
            }

            int iSeed = 10;
            Random ra = new Random(iSeed);
            long tick = DateTime.Now.Ticks;
            Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
            var temp = ran.Next(0, 100);

            float DeltaMove = Dist * Clamp(((float)temp / 100), 0f, 1f);

            return MinValue + DeltaMove;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start">Target Vector</param>
        /// <param name="end">Self Vector</param>
        /// <returns></returns>
        public static Rotator GetLookAtRotator(Vector start, Vector end)
        {
            Vector NewX = (start - end).GetSafeNormal();

            float NewXZ = (NewX.Z > 0) ? NewX.Z : -NewX.Z;
            Vector UpVector = (NewXZ < (1.0f - Const.KINDA_SMALL_NUMBER)) ? new Vector(0, 0, 1.0f) : new Vector(1.0f, 0, 0);

            Vector NewY = (UpVector ^ NewX).GetSafeNormal();
            Vector NewZ = NewX ^ NewY;

            return new Matrix(NewX, NewY, NewZ, Vector.ZeroVector).Rotator();
        }
    }
}
