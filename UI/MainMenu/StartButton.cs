using Godot;
using System;

public partial class StartButton : Button
{
	Control mainMenu;
	public override void _Ready(){
		mainMenu = GetParent<Control>();
	}

	public override void _Process(double delta){
	
	}

	public override void _Pressed(){
		mainMenu.Visible = false;
		Engine.TimeScale = 1f;
    }

}
