using System;

namespace VitPro {

	partial struct Color {
		/// <summary>White color.</summary>
		public static Color White = new Color(1, 1, 1);
		/// <summary>Black color.</summary>
		public static Color Black = new Color(0, 0, 0);
		/// <summary>Color(0, 0, 0, 0).</summary>
		public static Color Transparent = new Color(0, 0, 0, 0);
		/// <summary>Color(1, 1, 1, 0).</summary>
		public static Color TransparentWhite = new Color(1, 1, 1, 0);
		/// <summary>Red color.</summary>
		public static Color Red = new Color(1, 0, 0);
		/// <summary>Green color.</summary>
		public static Color Green = new Color(0, 1, 0);
		/// <summary>Blue color.</summary>
		public static Color Blue = new Color(0, 0, 1);
		/// <summary>Gray color.</summary>
		public static Color Gray = new Color(0.5, 0.5, 0.5);
		/// <summary>Cyan color.</summary>
		public static Color Cyan = new Color(0, 1, 1);
		/// <summary>Yellow color.</summary>
		public static Color Yellow = new Color(1, 1, 0);
		/// <summary>Magenta color.</summary>
		public static Color Magenta = new Color(1, 0, 1);
		/// <summary>Orange color.</summary>
		public static Color Orange = new Color(1, 0.5, 0);
		/// <summary>Sky color.</summary>
		public static Color Sky = new Color(0.8, 0.8, 1);
	}

}