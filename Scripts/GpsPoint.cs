using Godot;
using System;

[GlobalClass]
public partial class GpsPoint : Marker2D
{
	[Export]
	public bool GpsVisible { get; set; }
	public GpsPoint()
	{
		GpsVisible = true;
		AddToGroup("GpsPoints");
	}
}
