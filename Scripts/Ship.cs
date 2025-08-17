using Godot;
public partial class Ship : RigidBody2D
{
	public float Force = DataManager.InitAttributes.Force;
	public float Torque = DataManager.InitAttributes.Torque;
	public float Speed = DataManager.InitAttributes.Speed;
	public float AngularSpeed = DataManager.InitAttributes.AngularSpeed;
	public override void _PhysicsProcess(double delta)
	{
		var direction = Input.GetVector("Left", "Right", "Up", "Down").Normalized().Rotated(Rotation);
		var rotation = Input.GetAxis("RotateL", "RotateR");
		if (direction != Vector2.Zero && (LinearVelocity + direction * Force * (float)delta).Length() < Speed)
		{
			ApplyCentralForce(direction * Force);
		}
		if (rotation != 0f && float.Abs(AngularVelocity + rotation * Torque * (float)delta) < AngularSpeed)
		{
			ApplyTorque(rotation * Torque);
		}
	}
}
