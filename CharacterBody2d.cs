using Godot;
using System;

public partial class CharacterBody2d : CharacterBody2D
{
	[Export]
	public int Speed { get; set; } = 400;
	private Vector2 _target;
	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("click"))
		{
			_target = GetGlobalMousePosition();
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		Velocity = Position.DirectionTo(_target) * Speed;
		LookAt(_target);
		if (Position.DistanceTo(_target) > 10)
		{
			MoveAndSlide();
		}
	}
}
