using System;
using System.Collections.Generic;

namespace VitPro {

	public static class ExtICollection {

		public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> range) {
			foreach (var o in range)
				collection.Add(o);
		}

	}

}