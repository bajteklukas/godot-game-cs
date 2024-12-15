using Godot;
using System;
using System.Numerics;

public partial class EnemySpawner : Node
{
	CharacterBody2D playerObject;
	PackedScene enemyScene;
	RandomNumberGenerator rng = new RandomNumberGenerator();
	Node main;

	int enemyLimit = 1;
	int currentEnemies = 0;


	public override void _Ready(){
		main = GetTree().Root.GetNode<Node2D>("main");
		playerObject =  main.GetNode<CharacterBody2D>("Player");
		enemyScene = ResourceLoader.Load<PackedScene>("res://Enemy/enemy.tscn");
	}


	public override void _Process(double delta){
		while(currentEnemies < enemyLimit) { SpawnEnemy(); }
	}
	

	void SpawnEnemy(){
		CharacterBody2D enemyObject = enemyScene.Instantiate() as CharacterBody2D;
		main.AddChild(enemyObject);
		Godot.Vector2 spawnPosition = new Godot.Vector2();
		
		do {
			spawnPosition = new Godot.Vector2(rng.RandiRange(-3000, 3000) + playerObject.Position.X, rng.RandiRange(-3000, 3000) + playerObject.Position.Y);
		} while (spawnPosition.DistanceTo(playerObject.Position) < 1500);

		enemyObject.Position = spawnPosition;
		currentEnemies++;
	}

	public void RemoveEnemy(){ currentEnemies--; GD.Print("REMOVING"); }
}
