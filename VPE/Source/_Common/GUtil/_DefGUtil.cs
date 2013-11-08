using System;
using System.IO;
using BinaryFormatter = System.Runtime.Serialization.Formatters.Binary.BinaryFormatter;

namespace VitPro {

	/// <summary>
	/// Provides utility functions.
	/// </summary>
	public static partial class GUtil {

		/// <summary>
		/// Swap a with b.
		/// </summary>
		public static void Swap<T>(ref T a, ref T b) {
			T c = a;
			a = b;
			b = c;
		}

		/// <summary>
		/// Serialize object into a file.
		/// </summary>
		public static void Dump(object o, string path) {
			using (var f = new FileStream(path, FileMode.Create, FileAccess.Write)) {
				var fmt = new BinaryFormatter();
				fmt.Serialize(f, o);
			}
		}

		/// <summary>
		/// Deserialize object from a file.
		/// </summary>
		public static T Load<T>(string path) {
			using (var f = new FileStream(path, FileMode.Open, FileAccess.Read)) {
				var fmt = new BinaryFormatter();
				return (T)fmt.Deserialize(f);
			}
		}

		/// <summary>
		/// Reads contents of a text file.
		/// </summary>
		/// <param name="path">File to read.</param>
		public static string ReadFile(string path) {
			using (var f = new StreamReader(path))
				return f.ReadToEnd();
		}

	}

}