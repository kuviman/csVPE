using System;

using VitPro;
using VitPro.Engine;

class Test : State {
	public override void Update(double dt) {
		base.Update(dt);
		Console.WriteLine("Update {0}", dt);
	}
	public override void Render() {
		base.Render();
		Console.WriteLine("Render");
	}
}

class Program {
	static void Main(string[] args) {
		App.Run(new Test());
	}
}