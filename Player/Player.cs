using Godot;
using System;

public partial class Player: CharacterBody2D
{
	[Export]
	public int Speed { get; set; } = 400;

	public void GetInput()
	{
		Vector2 inputDirection = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		Velocity = inputDirection * Speed;
		GD.Print(inputDirection);
	}

	public override void _PhysicsProcess(double delta)
	{
		GetInput();
		MoveAndSlide();
	}
}
