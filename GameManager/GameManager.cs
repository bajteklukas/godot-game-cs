using Godot;
using System;

public partial class GameManager : Node
{
	Node2D main;

	// ENEMY SPAWNER //
	EnemySpawner enemySpawner;
	
	// PLAYER //
	CharacterBody2D player;
	bool canRoll = false;

	// PLAYER INTERACTION WITH ENVIRONMENT //
	Control interactInterface;
	bool canPlayerInteract = false;

	public void StartInteract() {
		canPlayerInteract = true;
		interactInterface.Visible = true;
	}
	public void StopInteract() {
		canPlayerInteract = false;
		interactInterface.Visible = false;
	}



	// LEVEL //
	int zoneLevel;














	public override void _Ready(){
		main = GetTree().Root.GetNode<Node2D>("main");
		player = main.GetNode<CharacterBody2D>("Player");
		interactInterface = main.GetNode<CanvasLayer>("MainUI").GetNode<Control>("UsableObjectOverlay");
		enemySpawner = main.GetNode<Node>("EnemySpawner") as EnemySpawner;
	}

	



	// INPUT HANDLING //

	public override void _Process(double delta){
		// PLAYER INTERACTION WITH ENVIRONMENT //
		


	}




}
