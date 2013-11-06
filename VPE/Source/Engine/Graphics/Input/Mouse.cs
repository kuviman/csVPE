using OpenTK;
using OpenTK.Input;

namespace VitPro.Engine {

	/// <summary>
	/// Class for working with the mouse device.
	/// </summary>
	public static class Mouse {
		static bool _visible = true;

		/// <summary>
		/// Gets or sets mouse cursor visibility state.
		/// </summary>
		public static bool Visible {
			get { return _visible; }
			set {
				_visible = value;
				if (_visible)
					System.Windows.Forms.Cursor.Show();
				else
					System.Windows.Forms.Cursor.Hide();
			}
		}

		/// <summary>
		/// Gets or sets mouse position.
		/// </summary>
		public static Vec2 Position {
			get {
				return new Vec2(App.Window.Mouse.X, App.Window.Mouse.Y);
			}
			set {
				value = ToStandard(value);
				System.Windows.Forms.Cursor.Position = App.Window.PointToScreen(
					new System.Drawing.Point((int)value.X, (int)value.Y));
			}
		}

		/// <summary>
		/// Checks whether a mouse button is currently pressed
		/// </summary>
		/// <param name="button">Mouse button to check.</param>
		public static bool Pressed(this MouseButton button) {
			return App.Window.Mouse[(OpenTK.Input.MouseButton)button];
		}

		internal static Vec2 ToStandard(Vec2 pos) {
			return new Vec2(pos.X, App.Height - pos.Y - 1);
		}

		internal static Vec2 FromStandard(Vec2 pos) {
			return new Vec2(pos.X, App.Height - pos.Y - 1);
		}
	}

}