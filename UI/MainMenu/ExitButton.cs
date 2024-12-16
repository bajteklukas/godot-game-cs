using Godot;
using System;

public partial class ExitButton : Button
{
	public override void _Ready(){
	}

	
	public override void _Process(double delta){
	}


	public override void _Pressed(){
        GetTree().Quit();
    }


}
