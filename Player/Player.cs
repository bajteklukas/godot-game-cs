using Godot;
using System;
using System.Numerics;
using System.Transactions;

public partial class Player: CharacterBody2D
{
	GameManager gameManagerScript;
	Node2D main;

	float movementSpeed = 180f;
	public void Movement(){
		Godot.Vector2 inputDirection = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		Velocity = inputDirection * movementSpeed;
		MoveAndSlide();
	}

	CollisionShape2D playerCollider;

	bool canRoll = false;
	float rollSpeed = 800f;
	float rollDuration = 0.5f;
	float rollCooldown = 1f;

	bool isRolling = false;
	float rollTimer = 0f;
	float cooldownTimer = 0f;

	Godot.Vector2 rollDirection = Godot.Vector2.Zero;

	public void StartRoll(){
		playerCollider.Disabled = true;
		isRolling = true;
		rollTimer = rollDuration;
		cooldownTimer = rollCooldown;

        if (rollDirection == Godot.Vector2.Zero){ rollDirection = Velocity.Normalized(); }
		UpdateRollDirection();
	}
	
	public void UpdateRollDirection(){
        Godot.Vector2 inputDirection = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        if (inputDirection != Godot.Vector2.Zero){
            inputDirection = inputDirection.Normalized();
            Velocity = inputDirection * rollSpeed;
        }		
	}

	public void HandleRolling(double delta){
		rollTimer -= (float)delta;
		UpdateRollDirection();
		
		if (rollTimer <= 0f){
			isRolling = false;
			Velocity = Godot.Vector2.Zero;
			playerCollider.Disabled = false;
		}
		else{ MoveAndSlide(); }
	}

	public override void _Ready(){
		main = GetTree().Root.GetNode<Node2D>("main");
		gameManagerScript = main.GetNode<Node>("GameManager") as GameManager;

		playerCollider = GetNode<CollisionShape2D>("CollisionShape2D");
		SpawnPlayerInTown();
	}


	public override void _PhysicsProcess(double delta){
		if (isRolling){ HandleRolling(delta); }
		else {
			Movement();
			if (cooldownTimer <= 0f && Input.IsActionJustPressed("roll") && canRoll){
				StartRoll();
			}
		}
		if (cooldownTimer > 0f){ cooldownTimer -= (float)delta; }
	}

	void SpawnPlayerInTown() { Position = new Godot.Vector2(-115224, -28888); }
}
