using Godot;
using System;

public partial class Fps : Control
{
	public override void _Process(double delta){
		GetNode<Label>("Label").Text = $"{Engine.GetFramesPerSecond()}FPS";
	}
	
}
