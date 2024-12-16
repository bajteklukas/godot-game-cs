using Godot;
using System;

public partial class MainMenu : Control
{
<<<<<<< Updated upstream
	bool isActive = true;

	public override void _Ready(){
		Engine.TimeScale = 0;
	}

	public override void _Process(double delta){
		
=======
	public bool isGameStarted = false;
	public override void _Ready(){
		Engine.TimeScale = 0f;
		GD.PrintErr("  aaa sd a dasdas ");
	}

	public override void _Process(double delta){
		if(Input.IsActionJustPressed("escape") && !Visible) {
			Visible = true;
			Engine.TimeScale = 0f;
		}
>>>>>>> Stashed changes
	}

	

}
