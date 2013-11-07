using System;
using System.Collections.Concurrent;
using OpenTK.Graphics.OpenGL;

namespace VitPro.Engine {

	internal static partial class RawGL {

		public static ConcurrentQueue<int> Shaders = new ConcurrentQueue<int>();
		public static ConcurrentQueue<int> Textures = new ConcurrentQueue<int>();
		public static ConcurrentQueue<int> Programs = new ConcurrentQueue<int>();
		public static ConcurrentQueue<int> Lists = new ConcurrentQueue<int>();

		static RawGL() {
			App.Init();
		}

		public static void Collect() {
			if (App.Closed)
				return;
			int obj;
			while (Programs.TryDequeue(out obj))
				GL.DeleteProgram(obj);
			while (Shaders.TryDequeue(out obj))
				GL.DeleteShader(obj);
			while (Textures.TryDequeue(out obj))
				GL.DeleteTexture(obj);
			while (Lists.TryDequeue(out obj))
				GL.DeleteLists(obj, 1);
		}

	}

}