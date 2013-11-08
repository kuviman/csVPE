using System;

namespace VitPro.Engine {

	partial class Draw {

		static Shader ColorShader = new Shader(Shaders.Color);
		static Shader CircleShader = new Shader(Shaders.Circle);

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
			ColorShader.Render();
			Draw.Load();
		}

		public static void Circle(double x, double y, double r, Color? color = null) {
			Circle(new Vec2(x, y), r, color);
		}
		public static void Circle(Vec2 pos, double r, Color? color = null) {
			Draw.Save();
			if (color.HasValue)
				Draw.Color(color.Value);
			Draw.Translate(pos);
			Draw.Scale(r * 2);
			Draw.Align(0.5, 0.5);
			CircleShader.Render();
			Draw.Load();
		}

	}

}