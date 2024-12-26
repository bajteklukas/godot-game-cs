using Godot;
using System;

public partial class EnemyCombatManager : Node
{

	float health = 1000f;


	float speed = 200f;
	public float Speed{
		get { return speed; }
		set { speed = value; }
	}

	public void TakeDamage(float damage){
		this.health -= damage;
	}

	public override void _Ready(){
	
	}

	public override void _Process(double delta){

	}
}
