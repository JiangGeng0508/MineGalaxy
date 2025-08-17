using Godot;
using System;

public partial class Hud : CanvasLayer
{
	[Signal]
	public delegate void EnergyValueEventHandler(float value);
	[Signal]
	public delegate void MaxEnergyValueEventHandler(float value);
	public override void _Ready()
	{
		GlobalRef.Hud = this;
	}

	public void SetEnergyValue(float value) => EmitSignal(nameof(EnergyValue), value);
	public void SetMaxEnergyValue(float value) => EmitSignal(nameof(MaxEnergyValue), value);
}
