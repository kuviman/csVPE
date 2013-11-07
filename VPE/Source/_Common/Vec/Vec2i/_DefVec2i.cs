using System;

namespace VitPro {

	/// <summary>
	/// Represents a 2d vector with integer coordinates.
	/// </summary>
	[Serializable]
	public struct Vec2i {
		public readonly int X, Y;
		public Vec2i(int x, int y) {
			X = x;
			Y = y;
		}

		public override string ToString() {
			return string.Format("({0}; {1})", X, Y);
		}

		public static explicit operator Vec2i(Vec2 v) {
			return new Vec2i((int)v.X, (int)v.Y);
		}
		public static implicit operator Vec2(Vec2i v) {
			return new Vec2(v.X, v.Y);
		}
	}

}