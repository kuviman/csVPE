using System;

using VitPro;
using VitPro.Engine;

class Test : State {

	Color backColor = new Color(0.8, 0.8, 1);

	public override void Update(double dt) {
		base.Update(dt);
	}
	public override void Render() {
		Draw.Clear(backColor);
	}

	public override void KeyDown(Key key) {
		base.KeyDown(key);
		Console.WriteLine("keydown {0}", key);
	}

	public override void KeyUp(Key key) {
		base.KeyUp(key);
		Console.WriteLine("keyup {0}", key);
	}

	public override void MouseDown(MouseButton button, Vec2 pos) {
		base.MouseDown(button, pos);
		Console.WriteLine("mousedown {0} {1}", button, pos);
	}

	public override void MouseUp(MouseButton button, Vec2 pos) {
		base.MouseUp(button, pos);
		Console.WriteLine("mouseup {0} {1}", button, pos);
	}

	public override void MouseMove(Vec2 pos) {
		base.MouseMove(pos);
		Console.WriteLine("mousemove {0}", pos);
	}
}

class Program {
	static void Main(string[] args) {
		App.Run(new Test());
	}
}