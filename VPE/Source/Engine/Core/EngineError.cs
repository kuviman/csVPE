using System;

namespace VitPro.Engine {

	/// <summary>
	/// Engine error exception
	/// </summary>
	[Serializable]
	public class EngineError: Exception {
		internal EngineError(string message) : base(message) { }
		internal EngineError(string message, Exception inner) : base(message, inner) { }
	}

}