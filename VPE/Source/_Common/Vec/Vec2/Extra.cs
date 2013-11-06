using System;

namespace VitPro {

	partial struct Vec2 {
		/// <summary>
		/// Vec2(1, 0).
		/// </summary>
		public static readonly Vec2 OrtX = new Vec2(1, 0);

		/// <summary>
		/// Vec2(0, 1).
		/// </summary>
		public static readonly Vec2 OrtY = new Vec2(0, 1);

		/// <summary>
		/// Vec2(0, 0).
		/// </summary>
		public static readonly Vec2 Zero = new Vec2(0, 0);

		/// <summary>
		/// Get the square length of the vector.
		/// </summary>
		public double SqrLength {
			get { return X * X + Y * Y; }
		}

		/// <summary>
		/// Get the argument of the vector.
		/// </summary>
		public double Arg {
			get { return Math.Atan2(Y, X); }
		}

		/// <summary>
		/// Get the length of the vector.
		/// </summary>
		public double Length {
			get { return Math.Sqrt(X * X + Y * Y); }
		}

		/// <summary>
		/// Get the unit vector.
		/// </summary>
		public Vec2 Unit {
			get {
				if (Length < double.Epsilon) // Check
					return Zero;
				return this / Length;
			}
		}

		/// <summary>
		/// Rotate a vector.
		/// </summary>
		/// <param name="a">Vector to rotate.</param>
		/// <param name="angle">Ratation angle.</param>
		/// <returns>Rotated vector.</returns>
		public static Vec2 Rotate(Vec2 a, double angle) {
			double s = Math.Sin(angle);
			double c = Math.Cos(angle);
			return new Vec2(a.X * c - a.Y * s, a.X * s + a.Y * c);
		}

		/// <summary>
		/// Rotate a vector 90 degrees counter-clockwise.
		/// </summary>
		/// <param name="a">Vector to rotate.</param>
		public static Vec2 Rotate90(Vec2 a) {
			return new Vec2(-a.Y, a.X);
		}

		/// <summary>
		/// Clamp the length of a vector.
		/// </summary>
		/// <param name="a">Vector to clamp.</param>
		/// <param name="maxlen">Maximal length.</param>
		/// <returns>Clamped vector.</returns>
		public static Vec2 Clamp(Vec2 a, double maxlen) {
			if (a.Length <= maxlen)
				return a;
			else
				return a.Unit * maxlen;
		}

		/// <summary>
		/// Multiply two vectors componentwise.
		/// </summary>
		/// <param name="a">First vector.</param>
		/// <param name="b">Second vector.</param>
		public static Vec2 CompMult(Vec2 a, Vec2 b) {
			return new Vec2(a.X * b.X, a.Y * b.Y);
		}

		/// <summary>
		/// Divide one vector by another componentwise.
		/// </summary>
		/// <param name="a">First vector.</param>
		/// <param name="b">Second vector.</param>
		public static Vec2 CompDiv(Vec2 a, Vec2 b) {
			return new Vec2(a.X / b.X, a.Y / b.Y);
		}
	}

}