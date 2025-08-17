using Godot;
using System;

public partial class Mouse : Node2D
{
	public override void _Process(double delta)
	{
		GlobalPosition = GetGlobalMousePosition();
	}
}
