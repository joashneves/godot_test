extends CharacterBody2D

@onready var projectile = preload("res://bullet.tscn")

const SPEED = 300.0
const JUMP_VELOCITY = -400.0

@export var speed = 400

func get_input():
	var input_direction = Input.get_vector("left", "right", "up", "down")
	velocity = input_direction * speed

func _input(event: InputEvent) -> void:
	if event is InputEventMouseButton:
		if event.button_index == MOUSE_BUTTON_LEFT:
			print("aaaa", event.position)
			shoot()
		
func shoot():
	var instance = projectile.instantiate()
	get_tree().root.add_child(instance)
	instance.global_position = global_position
	
	

func _physics_process(delta):
	get_input()
	move_and_slide()
