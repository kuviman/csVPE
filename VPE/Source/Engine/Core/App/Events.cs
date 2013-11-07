using System;

namespace VitPro.Engine {

	partial class App {

		static void InitEvents() {
			Window.UpdateFrame += (o, args) => Update(args.Time);
			Window.RenderFrame += (o, args) => Render();
			Window.Keyboard.KeyDown += (o, args) => KeyDown((Key)args.Key);
			Window.Keyboard.KeyUp += (o, args) => KeyUp((Key)args.Key);
			Window.Mouse.ButtonDown += (o, args) => MouseDown(
				(MouseButton)args.Button, Mouse.FromStandard(new Vec2(args.X, args.Y)));
			Window.Mouse.ButtonUp += (o, args) => MouseUp(
				(MouseButton)args.Button, Mouse.FromStandard(new Vec2(args.X, args.Y)));
			Window.Mouse.Move += (o, args) => MouseMove(Mouse.FromStandard(new Vec2(args.X, args.Y)));
		}

		static void Update(double dt) {
			UpdateStates();
			if (CurrentState == null)
				Window.Close();
			if (CurrentState != null)
				CurrentState.Update(dt);
		}

		static void Render() {
			if (CurrentState != null)
				CurrentState.Render();
			Window.SwapBuffers();
		}

		static void KeyDown(Key key) {
			if (CurrentState != null)
				CurrentState.KeyDown(key);
		}

		static void KeyUp(Key key) {
			if (CurrentState != null)
				CurrentState.KeyUp(key);
		}

		static void MouseDown(MouseButton button, Vec2 pos) {
			if (CurrentState != null)
				CurrentState.MouseDown(button, pos);
		}

		static void MouseUp(MouseButton button, Vec2 pos) {
			if (CurrentState != null)
				CurrentState.MouseUp(button, pos);
		}

		static void MouseMove(Vec2 pos) {
			if (CurrentState != null)
				CurrentState.MouseMove(pos);
		}

	}

}