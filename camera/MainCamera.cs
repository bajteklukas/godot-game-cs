using Godot;
using System;

public partial class MainCamera : Camera2D
{
	Node2D player;
	public override void _Ready(){
		
	}

	public override void _Process(double delta){
		if(Input.IsActionJustPressed("zoom_in")) {
			ZoomIn();
		}
		if(Input.IsActionJustPressed("zoom_out")) {
			ZoomOut();
		}
	}
	
	void ZoomIn(){
		if(Zoom.X < 2) { 
			Zoom += new Vector2(0.1f, 0.1f);
		}
	}
	
	void ZoomOut(){
		if(Zoom.X > 1) { 
			Zoom -= new Vector2(0.1f, 0.1f);
		}
	}
}
