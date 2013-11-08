using System;
using System.Linq;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;
using Matrix4 = OpenTK.Matrix4;

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
			PrepareUniforms();
		}

        /// <summary>
        /// Renders a quad using the shader.
        /// </summary>
		public virtual void Render() {
			Color color = Color.White;
			Matrix4 modelMatrix = Matrix4.Identity;
			Matrix4 projMatrix = Matrix4.Identity;

			GL.UseProgram(program);

			GL.Uniform4(locColor, (float)color.R, (float)color.G, (float)color.B, (float)color.A);
			GL.UniformMatrix4(locModelMatrix, false, ref modelMatrix);
			GL.UniformMatrix4(locProjMatrix, false, ref projMatrix);

			int textures = 0;
			foreach (var u in uniforms)
				u.Value.Set(u.Key, ref textures);

			Draw.RawQuad();
        }
    }

}