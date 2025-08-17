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
			_energy = value;
			GlobalRef.Hud.SetEnergyValue(_energy / MaxEnergy);
		}
	}
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
		if (direction != Vector2.Zero && (LinearVelocity + direction * Force * (float)delta).Length() < Speed && Energy > 0f)
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
		if (Energy > DataManager.InitAttributes.Energy)
		{
			Energy = DataManager.InitAttributes.Energy;
		}
		else if (Energy < 0f)
		{
			Energy = 0f;
		}
	}
}
