using System;

namespace VitPro {

	partial struct Color {
		/// <summary>
		/// Mix two colors
		/// </summary>
		public static Color Mix(Color c1, Color c2) {
			return new Color((c1.R + c2.R) / 2, (c1.G + c2.G) / 2, (c1.B + c2.B) / 2, (c1.A + c2.A) / 2);
		}

		/// <summary>
		/// Mix two colors with the given coefficients.
		/// </summary>
		public static Color Mix(Color c1, Color c2, double k1, double k2) {
			double sum = k1 + k2;
			return new Color((c1.R * k1 + c2.R * k2) / sum, (c1.G * k1 + c2.G * k2) / sum,
				(c1.B * k1 + c2.B * k2) / sum, (c1.A * k1 + c2.A * k2) / sum);
		}

		/// <summary>
		/// Blend two colors using standard blending.
		/// </summary>
		public static Color Blend(Color under, Color over) {
			return Mix(under, over, 1 - over.A, over.A);
		}

		public static Color operator *(Color c1, Color c2) {
			return new Color(c1.R * c2.R, c1.G * c2.G, c1.B * c2.B, c1.A * c2.A);
		}

		/// <summary>
		/// Multiply color's alpha value.
		/// </summary>
		public static Color MultAlpha(Color c, double k) {
			return new Color(c.R, c.G, c.B, c.A * k);
		}

		public static Color operator +(Color c1, Color c2) {
			return new Color(c1.R + c2.R, c1.G + c2.G, c1.B + c2.B, c1.A + c2.A);
		}

		public static Color operator *(Color c, double a) {
			return new Color(c.R * a, c.G * a, c.B * a, c.A * a);
		}

		public static Color operator /(Color c, double a) {
			return new Color(c.R / a, c.G / a, c.B / a, c.A / a);
		}
	}

}