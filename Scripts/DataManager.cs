using Godot;
using Godot.Collections;

public static class DataManager
{
	public static readonly Dictionary<string, string> Uid = [];//ResourceName -> ResourceUid
	public static readonly ShipAttributes InitAttributes = new();
	public static readonly HudData InitHudData = new();

	static DataManager()
	{
		Uid.Add("Ship", "uid://cn203d0jjhba0");
		Uid.Add("Icon", "uid://bcix1isad08ig");

		InitAttributes.Health = 100f;
		InitAttributes.Force = 100f;
		InitAttributes.Torque = 1000f;
		InitAttributes.Speed = 1000f;
		InitAttributes.AngularSpeed = 1000f;

		InitHudData.GpsPositionRadios = 100f;
		InitHudData.DetectRadios = 20000f;
		InitHudData.ShowGpsDistance = 300f;
	}
}
public struct ShipAttributes()
{
	public float Health;
	public float Force;
	public float Torque;
	public float Speed;
	public float AngularSpeed;
}
public struct HudData()
{
	public float GpsPositionRadios;
	public float DetectRadios;
	public float ShowGpsDistance;
}
