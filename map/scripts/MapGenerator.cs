using Godot;
using System;

public partial class MapGenerator : Node2D
{
	TileMapLayer tileMap;
	int tileSetID = 1;
	Vector2I tilePos = new Vector2I(1, 1);
	
	int width = 1000;
	int height = 1000;
	
	public override void _Ready(){
		tileMap = GetNode<TileMapLayer>("TileMapLayer");
		GenerateMap();
	}

	void GenerateMap(){
		for(int x = 0; x < width; x++){
			for(int y = 0; y < height; y++){
				if(x % 2 == 0 || y % 2 == 0) { tileMap.SetCell(new Vector2I(x - width / 2, y - height / 2), tileSetID, new Vector2I(-1, -1)); continue; }
				tileMap.SetCell(new Vector2I(x - width / 2, y - height / 2), tileSetID, tilePos);
			}
		}
	}



	public override void _Process(double delta){
		
	}
}
