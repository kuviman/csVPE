using System;

namespace VitPro.Engine {

	/// <summary>
	/// Class for working with the keyboard.
	/// </summary>
	public static class Keyboard {

		/// <summary>
		/// Check if the key is currently pressed.
		/// </summary>
		/// <param name="key">Key to check.</param>
		public static bool Pressed(this Key key) {
			return App.Window.Keyboard[(OpenTK.Input.Key)key];
		}
	}

}