using Godot;
using System;
using System.Numerics;

public partial class Player: CharacterBody2D
{
	float speed = 250f;

	public void Movement(){
		Godot.Vector2 inputDirection = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		Velocity = inputDirection * speed;
		MoveAndSlide();
	}

	public float rollSpeed = 800f;
	public float rollDuration = 0.5f;
	public float rollCooldown = 1f;

	private bool isRolling = false;
	private float rollTimer = 0f;
	private float cooldownTimer = 0f;

	private Godot.Vector2 rollDirection = Godot.Vector2.Zero;

	public void StartRoll()
	{
		isRolling = true;
		rollTimer = rollDuration;
		cooldownTimer = rollCooldown;

        if (rollDirection == Godot.Vector2.Zero)
        {
            rollDirection = Velocity.Normalized();
        }

			UpdateRollDirection();
	}
	
	public void UpdateRollDirection(){
        Godot.Vector2 inputDirection = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        if (inputDirection != Godot.Vector2.Zero)
        {
            inputDirection = inputDirection.Normalized();
            Velocity = inputDirection * rollSpeed;
        }		
	}

	public void HandleRolling(double delta)
	{
		rollTimer -= (float)delta;

		UpdateRollDirection();
		
		if (rollTimer <= 0f)
		{
			isRolling = false;
			Velocity = Godot.Vector2.Zero;
		}
		else
		{
			MoveAndSlide();
		}
	}

	public override void _PhysicsProcess(double delta){
		if (isRolling)
		{
			HandleRolling(delta);
		}
		else
		{
			Movement();
			if (cooldownTimer <= 0f && Input.IsActionJustPressed("roll"))
			{
				StartRoll();
			}
		}

		if (cooldownTimer > 0f)
		{
			cooldownTimer -= (float)delta;
		}
	}
}
