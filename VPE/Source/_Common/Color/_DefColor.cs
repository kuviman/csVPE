using System;

namespace VitPro {

	public partial struct Color {

		public readonly double R, G, B, A;

		public Color(double r, double g, double b) : this(r, g, b, 1) { }
		public Color(double r, double g, double b, double a) {
			R = r; G = g; B = b; A = a;
		}

	}

}