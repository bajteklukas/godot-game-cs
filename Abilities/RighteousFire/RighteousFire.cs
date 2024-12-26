using Godot;
using System;

public partial class RighteousFire : Area2D
{
	Node main;
	GameManager gameManagerScript;
	PlayerCombatManager playerCombatManagerScript;
	
	public override void _Ready(){
		main = GetTree().Root.GetNode<Node2D>("main");
		gameManagerScript = main.GetNode<Node>("GameManager") as GameManager;
		playerCombatManagerScript = main.GetNode<CharacterBody2D>("Player").GetNode<Node>("PlayerCombatManager") as PlayerCombatManager;
	}

	int frameCounter = 0;

	public override void _Process(double delta){
		frameCounter++;

		if(frameCounter >= 5){
			CheckCollisions();
			frameCounter = 0;
		}
	}

	void CheckCollisions(){
		Godot.Collections.Array<Area2D> overlappingAreas = GetOverlappingAreas();
		if(overlappingAreas.Count > 0) { DamageAllEnemiesInArea(overlappingAreas); }			
	}

	void DamageAllEnemiesInArea(Godot.Collections.Array<Area2D> enemyAreas){
		float damage = CalculateDamage();
		for (int i = 0; i < enemyAreas.Count; i++){
			EnemyCombatManager enemyCombatScript = enemyAreas[i].GetParent().GetNode<Node>("EnemyCombatManager") as EnemyCombatManager;
			enemyCombatScript.TakeDamage(damage);
		}
	}

	float CalculateDamage(){
		float baseFireDamage = 100;
		float totalDamage = baseFireDamage * playerCombatManagerScript.increasedFireDamage * playerCombatManagerScript.moreFireDamage;

		return totalDamage;
	}
}
