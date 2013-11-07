using System;

namespace VitPro.Engine {

	partial class App {

		/// <summary>
		/// Gets or sets close event handler.
		/// </summary>
		public static Action OnClose { get; set; }

		static bool _autoQuit = true;

		/// <summary>
		/// Gets or sets whether application closes automatically when user closes the window.
		/// </summary>
		public static bool AutoQuit { get { return _autoQuit; } set { _autoQuit = value; } }

		static void InitEvents() {
			Window.Closing += (o, args) => {
				if (!Closed && OnClose != null)
					OnClose();
				args.Cancel = !Closed && !AutoQuit;
				if (!args.Cancel)
					Closed = true;
			};
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
			if (CurrentState == null || Closed) {
				Closed = true;
				Window.Close();
			}
			if (CurrentState != null)
				CurrentState.Update(dt);
		}

		static void Render() {
			if (CurrentState != null)
				CurrentState.Render();
			Window.SwapBuffers();
		}

		static void KeyDown(Key key) {
			if (key == Key.F4 && (Key.LAlt.Pressed() || Key.RAlt.Pressed()))
				Window.Close();
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