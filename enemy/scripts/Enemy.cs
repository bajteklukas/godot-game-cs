using Godot;
using System;

public partial class Enemy : CharacterBody2D
{
	CharacterBody2D playerObject;
	Node main;
	EnemySpawner enemySpawnerScript;

	int speed = 200;
	int frameCounterDistanceCheck = 0;

	public override void _Ready(){
		main = GetTree().Root.GetNode<Node2D>("main");
		playerObject =  main.GetNode<CharacterBody2D>("Player");
	}

	public override void _PhysicsProcess(double delta){
		FollowPlayer();

		frameCounterDistanceCheck++;
		if(frameCounterDistanceCheck >= 5) { CheckDistanceFromPlayer(); frameCounterDistanceCheck = 0; }
	}

	void FollowPlayer(){
		Vector2 direction = (playerObject.Position - Position).Normalized();
		Velocity = direction * speed;
		MoveAndSlide();	
	}

	void CheckDistanceFromPlayer() {
		float distanceToPlayer = Position.DistanceTo(playerObject.Position);

		if(distanceToPlayer > 4000f) {
			QueueFree();
		}
	}
}
