using Godot;
using System;

public partial class MainMenu : Control
{
	bool isActive = true;

	public override void _Ready(){
		Engine.TimeScale = 0;
	}

	public override void _Process(double delta){
		
	}
}
