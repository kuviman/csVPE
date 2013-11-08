using System;
using OpenTK.Graphics.OpenGL;

namespace VitPro.Engine {

	public static partial class Draw {

		public static void Clear(Color color) {
			Clear(color.R, color.G, color.B, color.A);
		}

		public static void Clear(double r, double g, double b, double a = 1) {
			GL.ClearColor((float)r, (float)g, (float)b, (float)a);
			GL.Clear(ClearBufferMask.ColorBufferBit);
		}

		internal static void RawQuad() {
			GL.Rect(0, 0, 1, 1);
		}
	}

}