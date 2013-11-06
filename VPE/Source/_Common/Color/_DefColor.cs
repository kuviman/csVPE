using System;
using System.Linq;

namespace VitPro {

	/// <summary>
	/// Represents an RGBA color.
	/// </summary>
	[Serializable]
	public partial struct Color {
		public readonly double R, G, B, A;

		public Color(double r, double g, double b, double a = 1) {
			R = r; G = g; G = g; B = b; A = a;
		}

		/// <summary>
		/// Create a color using byte color components.
		/// </summary>
		public static Color FromBytes(byte r, byte g, byte b, byte a = 0xff) {
			return new Color((double)r / 0xff, (double)g / 0xff, (double)b / 0xff, (double)a / 0xff);
		}

		public override string ToString() {
			return string.Format("RGBA({0}; {1}; {2}; {3})", R, G, B, A);
		}
	}

}