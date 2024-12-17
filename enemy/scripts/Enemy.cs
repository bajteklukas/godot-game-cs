using Godot;
using System;

public partial class Enemy : CharacterBody2D
{
	CharacterBody2D playerObject;
	Node main;
	EnemySpawner enemySpawnerScript;

	int speed = 200;

	public override void _Ready(){
		main = GetTree().Root.GetNode<Node2D>("main");
		playerObject =  main.GetNode<CharacterBody2D>("Player");
	}

	int frameCounterDistanceCheck = 0;
	int frameCounterPlayerFollow = 0;
	public override void _PhysicsProcess(double delta){
		frameCounterDistanceCheck++;
		if(frameCounterDistanceCheck >= 15) { CheckDistanceFromPlayer(); frameCounterDistanceCheck = 0; }

		frameCounterPlayerFollow++;
		if(frameCounterDistanceCheck >= 5) { FollowPlayer(); frameCounterPlayerFollow = 0; }
		MoveAndSlide();
	}

	void FollowPlayer(){
		Vector2 direction = (playerObject.Position - Position).Normalized();
		Velocity = direction * speed;	
	}

	void CheckDistanceFromPlayer() {
		float distanceToPlayer = Position.DistanceTo(playerObject.Position);

		if(distanceToPlayer > 4000f) {
			QueueFree();
		}
	}
}
