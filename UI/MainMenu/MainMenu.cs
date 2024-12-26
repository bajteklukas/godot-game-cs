using Godot;
using System;

public partial class MainMenu : Control
{
	public override void _Ready(){
		Visible = true;
		Engine.TimeScale = 0f;
	}

	public override void _Process(double delta){
		if(Input.IsActionJustPressed("escape")){
			if(Visible == false) {
				Visible = true;
				Engine.TimeScale = 0f;
			}
			else { Visible = false; Engine.TimeScale = 1f; }
		}
	}
}