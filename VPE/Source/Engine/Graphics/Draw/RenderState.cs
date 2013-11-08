using System;
using System.Collections.Generic;
using OpenTK;
using Matrix4 = OpenTK.Matrix4;

namespace VitPro.Engine {

    partial class Draw {

        internal struct RenderState {
			public Matrix4 Matrix;
			public Matrix4 projMatrix;
			public Color color;

			public static RenderState Default;

            public RenderState Clone() {
                return (RenderState)MemberwiseClone();
            }
        }

		static void InitState() {
			RenderState.Default.Matrix = Matrix4.Identity;
			RenderState.Default.projMatrix = Matrix4.Identity;
			RenderState.Default.color = new Color(1, 1, 1, 1);
			StateStack.Push(RenderState.Default);
		}

		internal static Stack<RenderState> StateStack = new Stack<RenderState>();
		internal static RenderState CurrentState { get { return StateStack.Peek(); } }

    }

}