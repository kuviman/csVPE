using System;
using System.Linq;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;

namespace VitPro.Engine {

    /// <summary>
    /// GLSL fragment shader.
    /// </summary>
    public partial class Shader : IRenderable {

		static Shader() {
			App.Init();
		}

        static RawGL.Shader vertexShader = new RawGL.Shader(
            ShaderType.VertexShader, Shaders._Vertex);

        RawGL.Program program;

		/// <param name="program">Source code.</param>
		/// <param name="adds">Additional source files.</param>
		public Shader(string program, params string[] adds) {
			List<RawGL.Shader> all = new List<RawGL.Shader>();
			all.Add(vertexShader);
			all.Add(new RawGL.Shader(ShaderType.FragmentShader, program));
			all.AddRange(adds.Select(source => new RawGL.Shader(ShaderType.FragmentShader, source)));
			this.program = new RawGL.Program(all.ToArray());
		}

        /// <summary>
        /// Renders a quad using the shader.
        /// </summary>
        public virtual void Render() {
			GL.UseProgram(program);
			Draw.RawQuad();
        }
    }

}