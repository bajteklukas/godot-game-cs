using Godot;
using System;

public partial class GameManager : Node
{
	Node2D main;

	// ENEMY SPAWNER //
	EnemySpawner enemySpawner;
	bool canSpawnEnemies = false;
	
	// PLAYER //
	bool canRoll = false;

	// LEVEL //
	int zoneLevel;















	public override void _Ready(){
		main = GetTree().Root.GetNode<Node2D>("main");
		enemySpawner = main.GetNode<Node>("EnemySpawner").GetNode<EnemySpawner>("EnemySpawner");
	}

	public override void _Process(double delta)
	{
	}
}
