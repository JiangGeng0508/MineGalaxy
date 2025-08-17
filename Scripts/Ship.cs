using Godot;
public partial class Ship : RigidBody2D
{
	public float Force = DataManager.InitAttributes.Force;
	public float Torque = DataManager.InitAttributes.Torque;
	public float Speed = DataManager.InitAttributes.Speed;
	public float AngularSpeed = DataManager.InitAttributes.AngularSpeed;
	public float MaxEnergy = DataManager.InitAttributes.Energy;
	private float _energy = DataManager.InitAttributes.Energy;
	public float Energy
	{
		get
		{
			return _energy;
		}
		set
		{
			if (_energy > DataManager.InitAttributes.Energy) _energy = DataManager.InitAttributes.Energy;
			else if (_energy < 0f) _energy = 0f;
			else _energy = value;
			if (_energy <= 0f && IsEngineOn) IsEngineOn = false;
			else if (_energy > MaxEnergy * 0.3f && !IsEngineOn) IsEngineOn = true;
			GlobalRef.Hud.SetEnergyValue(_energy / MaxEnergy);
		}
	}
	public bool IsEngineOn = true;
	public GpuParticles2D Engine;
	public override void _Ready()
	{
		GlobalRef.Ship = this;
		Engine = GetNode<GpuParticles2D>("Engine");
	}
	public override void _PhysicsProcess(double delta)
	{
		var direction = Input.GetVector("Left", "Right", "Up", "Down").Normalized().Rotated(Rotation);
		var rotation = Input.GetAxis("RotateL", "RotateR");
		if (direction != Vector2.Zero && (LinearVelocity + direction * Force * (float)delta).Length() < Speed && IsEngineOn)
		{
			Energy -= 10f * (float)delta;
			ApplyCentralForce(direction * Force);
			Engine.Emitting = true;
		}
		else
		{
			Engine.Emitting = false;
		}
		if (rotation != 0f && float.Abs(AngularVelocity + rotation * Torque * (float)delta) < AngularSpeed)
		{
			ApplyTorque(rotation * Torque);
		}
		Energy += 1f * (float)delta;
	}
	public void OnBodyShapeEntered(Rid rid, Node node, int shapeIdx, int localIdx)
	{
		GD.Print($"{rid} entered {node} shape {shapeIdx} local {localIdx}");
	}
}
