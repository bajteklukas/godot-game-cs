using Godot;
using System;

public partial class Enemy : Node2D
{
	CharacterBody2D playerObject;


	public override void _Ready(){
		playerObject =  GetTree().Root.GetNode<Node2D>("main").GetNode<CharacterBody2D>("Player");
		GD.Print(playerObject.Name);	
	}

	public override void _Process(double delta){
		
	}
}
