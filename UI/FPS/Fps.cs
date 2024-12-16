using Godot;
using System;

public partial class Fps : Control
{
	bool isPaused = false;

	public override void _Process(double delta)
	{
		GetNode<Label>("Label").Text = $"{Engine.GetFramesPerSecond()}FPS";

		if (Input.IsActionJustPressed("escape"))
        {
            TogglePause();
        }
	}
	void TogglePause()
    {
        isPaused = !isPaused;

        Engine.TimeScale = isPaused ? 0.0f : 1.0f;

        GD.Print(isPaused ? "Game Paused" : "Game Resumed");
    }
}
