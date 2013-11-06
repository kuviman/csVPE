using System;

namespace VitPro {

	partial struct Vec2 {
		public static Vec2 operator *(Vec2 a, double x) {
			return new Vec2(a.X * x, a.Y * x);
		}

		public static Vec2 operator *(double x, Vec2 a) {
			return new Vec2(x * a.X, x * a.Y);
		}

		public static Vec2 operator /(Vec2 a, double x) {
			return new Vec2(a.X / x, a.Y / x);
		}

		public static Vec2 operator -(Vec2 a) {
			return new Vec2(-a.X, -a.Y);
		}

		public static Vec2 operator +(Vec2 a) {
			return new Vec2(+a.X, +a.Y);
		}

		public static Vec2 operator +(Vec2 a, Vec2 b) {
			return new Vec2(a.X + b.X, a.Y + b.Y);
		}

		public static Vec2 operator -(Vec2 a, Vec2 b) {
			return new Vec2(a.X - b.X, a.Y - b.Y);
		}

		/// <summary>
		/// Get the dot product of two vectors.
		/// </summary>
		/// <param name="a">First vector.</param>
		/// <param name="b">Second vector.</param>
		public static double Dot(Vec2 a, Vec2 b) {
			return a.X * b.X + a.Y * b.Y;
		}
		public static double operator *(Vec2 a, Vec2 b) {
			return Dot(a, b);
		}

		/// <summary>
		/// Get the skew product of two vectors.
		/// </summary>
		/// <param name="a">First vector.</param>
		/// <param name="b">Second vector.</param>
		/// <returns></returns>
		public static double Skew(Vec2 a, Vec2 b) {
			return a.X * b.Y - a.Y * b.X;
		}
		public static double operator ^(Vec2 a, Vec2 b) {
			return Skew(a, b);
		}
	}

}