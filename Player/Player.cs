using Godot;
using System;

public partial class Player: CharacterBody2D
{
	int speed = 180;

	public void GetInput(){
		Vector2 inputDirection = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		Velocity = inputDirection * speed;
	}

	public override void _PhysicsProcess(double delta){
		GetInput();
		MoveAndSlide();
	}
}
