using System;

namespace VitPro.Engine {

	partial class Draw {

		static Shader ColorShader = new Shader(Shaders.Color);

		public static void Quad() {
			ColorShader.Render();
		}

	}

}