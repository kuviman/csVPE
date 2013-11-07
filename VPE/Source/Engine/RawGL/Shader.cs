using System;
using OpenTK.Graphics.OpenGL;

namespace VitPro.Engine {

    partial class RawGL {

        public class Shader : IDisposable {
            int shader;

            public Shader(ShaderType type, string text) {
                App.Init();

                shader = GL.CreateShader(type);
                GL.ShaderSource(shader, text);
                GL.CompileShader(shader);
                int ok;
                GL.GetShader(shader, ShaderParameter.CompileStatus, out ok);
                if (ok == 0) {
                    string info = GL.GetShaderInfoLog(shader);
                    Dispose();
                    throw new EngineError(info);
                }
            }

            public static implicit operator int(Shader shader) {
                return shader.shader;
            }

            bool disposed = false;
            
            public void Dispose() {
                if (disposed)
                    return;
                Shaders.Enqueue(shader);
                disposed = true;
            }

            ~Shader() {
                Dispose();
            }
        }

    }

}