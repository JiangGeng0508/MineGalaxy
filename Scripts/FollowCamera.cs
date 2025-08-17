using Godot;
using System;

public partial class FollowCamera : Camera2D
{
	[Export]
	public NodePath shipPath;
	public Node2D ship;
	public override void _Ready()
	{
		ship = GetNodeOrNull<Node2D>(shipPath);
	}
	public override void _PhysicsProcess(double delta)
	{
		if (ship != null)
		{
			Position = ship.Position;
			Rotation = ship.Rotation;
		}
	}
}
