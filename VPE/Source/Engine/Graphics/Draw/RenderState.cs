using System;
using System.Collections.Generic;
using OpenTK;
using Matrix4 = OpenTK.Matrix4;

namespace VitPro.Engine {

    partial class Draw {

        internal class RenderState {
			public Matrix4 Matrix = Matrix4.Identity;
			public Matrix4 projMatrix = Matrix4.Identity;
			public Color color = new Color(1, 1, 1, 1);

            public RenderState Clone() {
                return (RenderState)MemberwiseClone();
            }
        }

		static void NewStack() {
			stackStack.Push(new Stack<RenderState>());
			StateStack.Push(new RenderState());
		}

		internal static Stack<RenderState> StateStack { get { return stackStack.Peek(); } }
		internal static RenderState CurrentState { get { return StateStack.Peek(); } }

		public static void Save() {
			StateStack.Push(CurrentState.Clone());
		}

		public static void Load() {
			StateStack.Pop();
		}

    }

}