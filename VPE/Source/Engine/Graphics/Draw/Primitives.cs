using System;

namespace VitPro.Engine {

	partial class Draw {

		static Shader ColorShader = new Shader(Shaders.Color);

		public static void Quad() {
			ColorShader.Render();
		}

		public static void Dot(double x, double y, double size, Color? color = null) {
			Dot(new Vec2(x, y), size, color);
		}

		public static void Dot(Vec2 pos, double size, Color? color = null) {
			Draw.Save();
			if (color.HasValue)
				Draw.Color(color.Value);
			Draw.Translate(pos);
			Draw.Scale(size);
			Draw.Align(0.5, 0.5);
			Draw.Quad();
			Draw.Load();
		}

	}

}