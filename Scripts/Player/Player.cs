using Godot;
using System;

public partial class Player : CharacterBody2D
{
    [Export] private Sprite2D _sprite;
    [Export] private ShipConfig _shipConfig;
    [Export] private CannonConfig _cannonConfig;

    public float Speed { get; private set; }
    public float Damage { get; private set; }

    public void Setup(ShipConfig shipConfig, CannonConfig cannonConfig)
    {
        _shipConfig = shipConfig;
        _cannonConfig = cannonConfig;
        _sprite.Texture = shipConfig.ShipSprite;
        Speed = shipConfig.MovingSpeed;
        Damage = cannonConfig.Damage;
    }

    public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
