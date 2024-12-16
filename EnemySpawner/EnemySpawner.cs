using Godot;
using System;
using System.Numerics;

public partial class EnemySpawner : Node
{
	bool canSpawnEnemies = false;
	CharacterBody2D playerObject;
	PackedScene enemyScene;
	RandomNumberGenerator rng = new RandomNumberGenerator();
	Node main;

	public override void _Ready(){
		main = GetTree().Root.GetNode<Node2D>("main");
		playerObject =  main.GetNode<CharacterBody2D>("Player");
		enemyScene = ResourceLoader.Load<PackedScene>("res://Enemy/enemy.tscn");
	}

	int spawnFrequency = 10;
	int spawnTimer = 0;

	public override void _Process(double delta){
		spawnTimer++;
		if(spawnTimer >= spawnFrequency) { SpawnEnemy(); spawnTimer = 0; }
	}
	

	void SpawnEnemy(){
		if(canSpawnEnemies){
			CharacterBody2D enemyObject = enemyScene.Instantiate() as CharacterBody2D;
			main.AddChild(enemyObject);
			Godot.Vector2 spawnPosition;
			
			do {
				spawnPosition = new Godot.Vector2(rng.RandiRange(-4000, 4000) + playerObject.Position.X, rng.RandiRange(-3000, 3000) + playerObject.Position.Y);
			} while (spawnPosition.DistanceTo(playerObject.Position) < 2000);

			enemyObject.Position = spawnPosition;
		}
	}
}
