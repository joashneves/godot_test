extends Node2D

const BULLET = preload("res://player/bullet.tscn")
@onready var muzzle: Marker2D = $Marker2D

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	look_at(get_global_mouse_position())
	rotation_degrees = wrap(rotation_degrees, 0, 360)
	if rotation_degrees > 90 and rotation_degrees < 270:
		scale.y = -1;
	else:
		scale.y = 1;


func _input(event: InputEvent) -> void:
	if event is InputEventMouseButton:
		if event.button_index == MOUSE_BUTTON_LEFT:
			print("aaaa", event.position)
			shoot()
		
func shoot():
	var instance = BULLET.instantiate()
	get_tree().root.add_child(instance)
	instance.global_position = muzzle.global_position
	instance.rotation = rotation
	
