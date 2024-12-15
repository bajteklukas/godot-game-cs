using Godot;
using System;

public partial class Enemy : CharacterBody2D
{
	CharacterBody2D playerObject;
	int speed = 300;

	public override void _Ready(){
		playerObject =  GetTree().Root.GetNode<Node2D>("main").GetNode<CharacterBody2D>("Player");
	}

	public override void _PhysicsProcess(double delta){
		FollowPlayer();
		
	}

	void FollowPlayer(){
		Vector2 direction = (playerObject.Position - Position).Normalized();
		Velocity = direction * speed;
		MoveAndSlide();	
	}


}
