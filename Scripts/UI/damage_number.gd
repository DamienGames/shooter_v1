extends Label

var velocity := Vector2(0, -50)
var lifetime := 1.0

func _ready():
	modulate.a = 1.0
	
func _process(delta):
	position += velocity * delta    
	# fade out
	modulate.a -= delta / lifetime    
	lifetime -= delta
	if lifetime <= 0:
		queue_free()
		
func setup(value: int, is_crit: bool = false):
	text = str(value)
	if is_crit:
		add_theme_color_override("font_color", Color.RED)
		scale = Vector2(1.2, 1.2)
