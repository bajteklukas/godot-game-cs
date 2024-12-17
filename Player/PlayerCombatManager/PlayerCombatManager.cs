using Godot;
using System;

public partial class PlayerCombatManager : Node
{

	// PLAYER COMBAT STATS //
	float health = 100f;
	float maxHealth = 100f;

	int fireResistance = 0;
	int coldResistance = 0;
	int lightningResistance = 0;

	int armour = 0;
	int evasion = 0;


	//PLAYER XP STATS //
	int level = 1;
	double currentXP = 0f;
	double requiredXP;

	void ReceiveXP(double amount) {
		currentXP += amount;
		if(currentXP >= requiredXP) {
			level += 1;
			currentXP = currentXP - requiredXP;
			requiredXP = Math.Pow(level, 2);
		}
	}



	public override void _Ready(){
		requiredXP = Math.Pow(level, 2);
	}

	public override void _Process(double delta){
	}
}
