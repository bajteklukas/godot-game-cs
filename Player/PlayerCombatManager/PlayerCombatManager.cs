using Godot;
using System;

public partial class PlayerCombatManager : Node
{

	// PLAYER COMBAT STATS //
	public float health = 100f;
	public float maxHealth = 100f;

	public int fireResistance = 0;
	public int coldResistance = 0;
	public int lightningResistance = 0;

	public int armour = 0;
	public int evasion = 0;

	//FIRE INC
	public float increasedFireDamage = 1;
	public float increasedFireDamageOverTime = 1;

	//FIRE MORE
	public float moreFireDamage = 1;
	public float moreFireDamageMulti = 1;




	//PLAYER XP STATS //
	public int level = 1;
	public double currentXP = 0f;
	public double requiredXP;

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
