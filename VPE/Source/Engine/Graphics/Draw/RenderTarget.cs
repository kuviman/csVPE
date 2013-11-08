using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;

namespace VitPro.Engine
{

    partial class Draw
    {
        static Stack<Texture> targetStack = new Stack<Texture>();
		static Stack<Stack<RenderState>> stackStack = new Stack<Stack<RenderState>>();

        /// <summary>
        /// Begin rendering to the texture.
        /// </summary>
        public static void BeginTexture(Texture tex)
        {
            EndUse();
			NewStack();
            targetStack.Push(tex);
            Use();
        }

        /// <summary>
        /// Finish rendering to the texture.
        /// </summary>
        public static void EndTexture() {
            EndUse();
			targetStack.Pop();
			stackStack.Pop();
            Use();
        }

        static int fb;
        internal static void Use()
        {
            if (targetStack.Count == 0) {
                UseScreen();
                return;
            }
            var tex = targetStack.Peek();
            GL.GenFramebuffers(1, out fb);
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, fb);
            GL.FramebufferTexture2D(FramebufferTarget.Framebuffer, FramebufferAttachment.ColorAttachment0,
                TextureTarget.Texture2D, tex.tex, 0);
            if (GL.CheckFramebufferStatus(FramebufferTarget.Framebuffer) != FramebufferErrorCode.FramebufferComplete)
                throw new EngineError("Framebuffer is wrong");
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, fb);
            GL.Viewport(0, 0, tex.Width, tex.Height);
        }

        internal static void EndUse()
        {
            if (targetStack.Count == 0)
                return;
            GL.DeleteFramebuffers(1, ref fb);
        }

        internal static void UseScreen()
        {
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
            GL.Viewport(0, 0, App.Width, App.Height);
        }

		internal static Texture CurrentTarget {
			get {
				if (targetStack.Count == 0)
					return null;
				else
					return targetStack.Peek();
			}
		}

		public static int Width {
			get {
				if (CurrentTarget == null)
					return App.Width;
				return CurrentTarget.Width;
			}
		}

		public static int Height {
			get {
				if (CurrentTarget == null)
					return App.Height;
				return CurrentTarget.Height;
			}
		}

		public static double Aspect {
			get { return (double)Width / (double)Height; }
		}

    }

}