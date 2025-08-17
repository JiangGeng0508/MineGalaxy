using Godot;
using System.Collections.Generic;

public partial class GpsNotifer : Control
{
	public float GpsPositionRadios = DataManager.InitHudData.GpsPositionRadios;
	public float DetectRadios = DataManager.InitHudData.DetectRadios;
	public float ShowGpsDistance = DataManager.InitHudData.ShowGpsDistance;
	public Dictionary<GpsPoint, Sprite2D> GpsCursorMap { get; set; } = [];
	public override void _Process(double delta)
	{
		foreach (var gpsPoint in GetTree().GetNodesInGroup("GpsPoints"))
		{
			if (gpsPoint is GpsPoint gps && !GpsCursorMap.ContainsKey(gps))
			{
				var cursor = new Sprite2D
				{
					Texture = ResourceLoader.Load<Texture2D>(DataManager.Uid["Icon"]),
					Scale = new Vector2(0.3f, 0.3f),
					Visible = gps.GpsVisible,
					Position = gps.GlobalPosition.DirectionTo(GlobalPosition) * GpsPositionRadios,
				};
				AddChild(cursor);
				GpsCursorMap.Add(gps, cursor);
			}
		}
		foreach (var gpsPoint in GpsCursorMap.Keys)
		{
			if (!GetTree().GetNodesInGroup("GpsPoints").Contains(gpsPoint))
			{
				GpsCursorMap[gpsPoint].QueueFree();
				GpsCursorMap.Remove(gpsPoint);
				continue;
			}
			var distant = gpsPoint.GlobalPosition.DistanceTo(GlobalPosition);
			if (distant < ShowGpsDistance || distant > DetectRadios)
			{
				GpsCursorMap[gpsPoint].Visible = false;
				continue;
			}
			else
			{
				GpsCursorMap[gpsPoint].Visible = gpsPoint.GpsVisible;
				GpsCursorMap[gpsPoint].Position = -gpsPoint.GlobalPosition.DirectionTo(GlobalPosition) * GpsPositionRadios;
			}
		}
		Rotation = -GetParent<Node2D>().Rotation;
	}
}

