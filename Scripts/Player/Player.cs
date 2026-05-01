using Godot;
using System;
using static GameManager;

public partial class Player : CharacterBody2D
{
    [Export] private Sprite2D _sprite;
    [Export] private ShipConfig _shipConfig;
    [Export] private CannonConfig _cannonConfig;
    [Export] private PackedScene _projectileScene;
    [Export] private HealthComponent _health;
    [Export] private AudioStreamPlayer2D _shootSound;
    [Export] private AudioStreamPlayer2D _dieSound;
    [Export] private Marker2D _cannon;

    public float Speed { get; private set; }
    public float Damage { get; private set; }

    public void Init(ShipConfig shipConfig, CannonConfig cannonConfig)
    {
        _shipConfig = shipConfig;
        _cannonConfig = cannonConfig;
        _sprite.Texture = shipConfig.ShipSprite;
        Speed = shipConfig.MovingSpeed;
        Damage = cannonConfig.Damage;
        _health.Died += OnDied;
        _shootSound = GetNode<AudioStreamPlayer2D>("SFX/ShootSound");
        _dieSound = GetNode<AudioStreamPlayer2D>("SFX/DieSound");
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

        if (Input.IsActionJustPressed("ui_accept"))
        {
            Shoot();
        }

        Velocity = velocity;
        MoveAndSlide();
    }

    public void Shoot()
    {
        var projectile = _projectileScene.Instantiate<Projectile>();

        GetTree().CurrentScene.AddChild(projectile);
        projectile.Init(this, _cannon.GlobalPosition, "enemy");
        projectile.GlobalPosition = _cannon.GlobalPosition;
        _shootSound.Play();
        projectile.Fire(Vector2.Up);
    }

    public void OnDied()
    {
        _dieSound.Play();
        GameManager.Instance.SetState(GameState.GameOver);
    }
}
