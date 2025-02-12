using Godot;
using System;

public partial class Cartar : Node2D
{
	private Texture2D _texture;
	private bool _dragging = false;

	private Vector2 _PositionMouse1;
	private Vector2 _PositionMouse2;

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
		DrawRect(new Rect2(_PositionMouse2[0],_PositionMouse2[1], _PositionMouse1[0] - _PositionMouse2[0],  _PositionMouse1[1] - _PositionMouse2[1]), Colors.Green, false);
	}
	public override void _Input(InputEvent @event)
	{

	if (@event is InputEventMouseButton mouseEvent && mouseEvent.ButtonIndex == MouseButton.Left)
	{
		GD.Print("Mouse Click/Unclick at: ", mouseEvent.Position);
		_PositionMouse2 = mouseEvent.Position;
		if (!_dragging && mouseEvent.Pressed)
				{
					_dragging = true;
				}
			// Stop dragging if the button is released.
			if (_dragging && !mouseEvent.Pressed)
			{
				_dragging = false;
			}
	}
	else
		{
			if (@event is InputEventMouseMotion motionEvent && _dragging)
			{
				GD.Print("Mouse _dragging on: ", motionEvent.Position);
				_PositionMouse1 = motionEvent.Position;
				GD.Print(_PositionMouse2, _PositionMouse1);
				QueueRedraw();
			}
		}

	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}
	public override void _Process(double delta)
	{
		
	}
}
