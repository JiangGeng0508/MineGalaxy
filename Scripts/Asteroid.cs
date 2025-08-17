using Godot;
using System;

public partial class Asteroid : TileMapLayer
{
	public override void _Ready()
	{
		GD.Print(TileMapData.GetValue(1));
		
	}
}
