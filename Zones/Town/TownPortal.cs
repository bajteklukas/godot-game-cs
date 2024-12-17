using Godot;
using System;

public partial class TownPortal : Area2D
{
	Node2D main;
	GameManager gameManager;

	public override void _Ready(){
		main = GetTree().Root.GetNode<Node2D>("main");
		gameManager = main.GetNode<Node>("GameManager") as GameManager;
	}

	bool isPlayerInArea = false;
	int collisionCheckFrameTime = 0;

	public override void _Process(double delta){
		collisionCheckFrameTime++;
		if(collisionCheckFrameTime >= 5) { CheckCollisions(); }
	}


	void CheckCollisions(){
		Godot.Collections.Array<Area2D> overlappingAreas = GetOverlappingAreas();
		if(overlappingAreas.Count != 0 && isPlayerInArea == false) { Area2D playerArea = overlappingAreas[0]; isPlayerInArea = true; gameManager.StartInteract(); }
		else if(overlappingAreas.Count == 0 && isPlayerInArea == true) { isPlayerInArea = false; gameManager.StopInteract(); }
	}
	
}
