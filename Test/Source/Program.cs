using System;

using VitPro;
using VitPro.Engine;

class Test : State {

	Color backColor = new Color(0.8, 0.8, 1);

	public override void Update(double dt) {
		base.Update(dt);
		Console.WriteLine("Update {0}", dt);
	}
	public override void Render() {
		Draw.Clear(backColor);
	}
}

class Program {
	static void Main(string[] args) {
		App.Run(new Test());
	}
}