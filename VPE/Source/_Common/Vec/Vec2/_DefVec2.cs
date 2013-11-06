using System;

namespace VitPro {

	/// <summary>
	/// Represents a 2d vector with double coordinates.
	/// </summary>
	[Serializable]
	public partial struct Vec2 {
		public readonly double X, Y;
		public Vec2(double x, double y) {
			X = x; Y = y;
		}

		public override string ToString() {
			return string.Format("({0}; {1})", X, Y);
		}
	}

}