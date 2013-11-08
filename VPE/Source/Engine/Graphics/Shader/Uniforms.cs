using System;
using System.Collections.Generic;

using OpenTK.Graphics.OpenGL;

namespace VitPro.Engine {

    partial class Shader {

        interface IUniform {
            void Set(int loc, ref int textures);
        }

		Dictionary<string, int> locations = new Dictionary<string, int>();
		int Loc(string name) {
			if (!locations.ContainsKey(name))
				locations[name] = GL.GetUniformLocation(program, name);
			return locations[name];
		}

		Dictionary<int, IUniform> uniforms = new Dictionary<int, IUniform>();

		int locModelMatrix, locProjMatrix, locColor;

		void PrepareUniforms() {
			locModelMatrix = Loc("modelMatrix");
			locProjMatrix = Loc("projectionMatrix");
			locColor = Loc("color");
		}

    }

}