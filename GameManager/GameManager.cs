using Godot;
using System;

public partial class GameManager : Node
{
	Node2D main;

	// ENEMY SPAWNER //
	EnemySpawner enemySpawner;
	public bool canSpawnEnemies = false;
	
	// PLAYER //
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
	
	void Interact() {
		GD.Print("INTERACT");
	}



	// LEVEL //
	int zoneLevel;














	public override void _Ready(){
		main = GetTree().Root.GetNode<Node2D>("main");
		interactInterface = main.GetNode<CanvasLayer>("MainUI").GetNode<Control>("UsableObjectOverlay");
		enemySpawner = main.GetNode<Node>("EnemySpawner") as EnemySpawner;
	}

	



	// INPUT HANDLING //

	public override void _Process(double delta){
		// PLAYER INTERACTION WITH ENVIRONMENT //
		if(Input.IsActionJustPressed("interact") && canPlayerInteract){
			Interact();
		}


	}




}
