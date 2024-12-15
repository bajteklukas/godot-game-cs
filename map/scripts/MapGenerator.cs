using Godot;
using System;

public partial class MapGenerator : Node2D
{
	TileMapLayer tileMap;
	int tileSetID = 1;
	Vector2I tilePos = new Vector2I(1, 1);
	
	int width = 100;
	int height = 100;
	
	public override void _Ready(){
		tileMap = GetNode<TileMapLayer>("TileMapLayer");
		GenerateMap();
	}

	void GenerateMap(){
		for(int x = 0; x < width; x++){
			for(int y = 0; y < height; y++){
				tileMap.SetCell(new Vector2I(x - width / 2, y - height / 2), tileSetID, tilePos);
			}
		}
	}



	public override void _Process(double delta){
		
	}
}
