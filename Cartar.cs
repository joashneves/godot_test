using Godot;
using System;

public partial class Cartar : Node2D
{
	private Texture2D _texture;
	public Vector2 _PositionMouse1;
	public Vector2 _PositionMouse2;

	[Export]
	public Texture2D Texture{
		get {
			return _texture;
		}
		set{
			_texture = value;
			QueueRedraw();
		}
	}
	public override void _Draw()
	{
		DrawLine( _PositionMouse2, _PositionMouse1, Colors.Green, 1.0f);
		
	}
	public override void _Input(InputEvent @event)
	{
	// Mouse in viewport coordinates.
	if (@event is InputEventMouseButton eventMouseButton)
	{
		GD.Print("Mouse Click/Unclick at: ", eventMouseButton.Position);
		_PositionMouse1 = GetViewport().GetMousePosition();

	}
	else if (@event is InputEventMouseMotion eventMouseMotion){
		GD.Print("Mouse Motion at: ", eventMouseMotion.Position);
		_PositionMouse2 = GetViewport().GetMousePosition();
		QueueRedraw();
	}

	// Print the size of the viewport.
	GD.Print("Viewport Resolution is: ", GetViewport().GetVisibleRect().Size);
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}
	public override void _Process(double delta)
	{
		
	}
}
