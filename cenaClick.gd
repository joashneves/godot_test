extends Node2D

var _dragging: bool;
var _PositionMouse1 : Vector2;
var _PositionMouse2 : Vector2;

@export var texture : Texture2D:
	set(value):
		texture = value
		queue_redraw()
func _draw() -> void:
	draw_rect(Rect2(_PositionMouse2[0],_PositionMouse2[1], _PositionMouse1[0] - _PositionMouse2[0],_PositionMouse1[1] - _PositionMouse2[1]), Color.GREEN, false);
func _input(event: InputEvent) -> void:
	if event is InputEventMouseButton:
		if event.button_index == MOUSE_BUTTON_LEFT:
			print("aaaa", event.position)
			_PositionMouse2 = event.position;
			if !_dragging and event.pressed:
				_dragging = true;
			if _dragging and !event.pressed:
				_PositionMouse1 = Vector2(0,0);
				_PositionMouse2 = Vector2(0,0);
				queue_redraw();
				_dragging = false
	if event is InputEventMouseMotion and _dragging:
		_PositionMouse1 = event.position;
		queue_redraw();
# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	pass # Replace with function body.
# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	pass
