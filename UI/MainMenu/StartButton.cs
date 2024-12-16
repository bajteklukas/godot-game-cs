using Godot;
using System;

public partial class StartButton : Button
{
	Control mainMenuObject;
	public override void _Ready(){
		mainMenuObject = GetParent<Control>();
	}

	public override void _Process(double delta){

	}

	public override void _Pressed() {
		mainMenuObject.Visible = false;
		Engine.TimeScale = 1f;
	}
	
}
