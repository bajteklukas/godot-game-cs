using Godot;
using System;

public partial class MainCamera : Camera2D
{
	Node2D player;
	public override void _Ready(){
		player = GetParent().GetNode<>();
	}

	public override void _Process(double delta)
	{
	}
}
