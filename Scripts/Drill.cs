using Godot;
using System;

public partial class Drill : Area2D
{
	public void OnBodyEntered(Node2D node)
	{
		GD.Print(node.Name);
	}
}
