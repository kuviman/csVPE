using System;

namespace VitPro.Engine {

	partial class App {

		static void InitEvents() {
			Window.UpdateFrame += (o, args) => Update(args.Time);
			Window.RenderFrame += (o, args) => Render();
		}

		static void Update(double dt) {
			if (CurrentState != null)
				CurrentState.Update(dt);
		}

		static void Render() {
			if (CurrentState != null)
				CurrentState.Render();
			Window.SwapBuffers();
		}

	}

}