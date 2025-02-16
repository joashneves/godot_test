extends Node2D

const SPEED = 500

func _process(delta: float) -> void:
	position += transform.x * SPEED * delta
