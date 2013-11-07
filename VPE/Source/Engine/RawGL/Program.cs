using System;
using OpenTK.Graphics.OpenGL;

namespace VitPro.Engine {

    partial class RawGL {

        public class Program : IDisposable {
            int program;

			public Program(params Shader[] shaders) {
				App.Init();
				program = GL.CreateProgram();
				foreach (var shader in shaders)
					GL.AttachShader(program, shader);
				GL.LinkProgram(program);
				int ok;
				GL.GetProgram(program, ProgramParameter.LinkStatus, out ok);
				if (ok == 0) {
					string info = GL.GetProgramInfoLog(program);
					Dispose();
					throw new EngineError(info);
				}
			}

            public static implicit operator int(Program program) {
                return program.program;
            }

            bool disposed = false;
            
            public void Dispose() {
                if (disposed)
                    return;
                Programs.Enqueue(program);
                disposed = true;
            }

            ~Program() {
                Dispose();
            }
        }

    }

}