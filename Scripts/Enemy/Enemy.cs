using Godot;
using static EnemyConfig;

public partial class Enemy : StaticBody2D
{
    [Signal] public delegate void DiedEventHandler(int score);
    [Export] private HealthComponent _health;
    [Export] private PackedScene _projectileScene;

    private EnemyConfig _config;

    private Timer _timer;

    public bool Active { get; private set; }
    public float Speed { get; private set; } = 100f;
    private float _angle;
    private float _direction = 1;
    private Vector2 _center;

    public override void _Ready()
    {
        _health.Died += OnDied;
        _timer = new Timer();
        AddChild(_timer);
        _timer.Timeout += OnSpawnTimer;
    }

    public override void _PhysicsProcess(double delta)
    {
        if (Active)
        {
            switch (_config.MovementType)
            {
                case MovementTypes.FollowPlayer:
                    FollowPlayer(delta);
                    break;

                case MovementTypes.Circle:
                    MoveCircle(delta);
                    break;

                case MovementTypes.Horizontal:
                    MoveHorizontal(delta);
                    break;
            }
        }
    }

    public void Init(EnemyConfig config)
    {
        _config = config;
        _center = GlobalPosition;
        _angle = 0;
        Speed = config.MovingSpeed;
        _timer.WaitTime = config.Cooldown;
    }

    private void MoveCircle(double delta)
    {
        _angle += Speed * (float)delta;

        GlobalPosition = _center + new Vector2(
            Mathf.Cos(_angle),
            Mathf.Sin(_angle)
        ) * _config.Radius;

        if (_angle > Mathf.Pi * 4)
            Deactivate();
    }

    private void FollowPlayer(double delta)
    {
        var player = GetTree().Root.GetNodeOrNull<Player>("Main/Player");

        if (player == null) return;

        var dir = (player.GlobalPosition - GlobalPosition).Normalized();

        GlobalPosition += dir * Speed * (float)delta;
    }

    private void MoveHorizontal(double delta)
    {
        GlobalPosition += new Vector2(_direction * Speed * (float)delta, 0);

        if (GlobalPosition.X <= 0 || GlobalPosition.X >= GetViewportRect().Size.X)
            _direction *= -1;
    }

    public void Shoot()
    {
        if (Active)
        {
            var projectile = _projectileScene.Instantiate<Projectile>();
            GetTree().CurrentScene.AddChild(projectile);
            projectile.GlobalPosition = GlobalPosition;
            projectile.Init(this, GlobalPosition, "player");
            projectile.Fire(Vector2.Down);
        }
    }


    public void Activate(Vector2 pos)
    {
        GlobalPosition = pos;

        Visible = true;
        ProcessMode = ProcessModeEnum.Inherit;
        SetPhysicsProcess(true);

        Active = true;

        _center = pos;
        _angle = 0;
        _direction = 1;

        _timer.Start();
    }

    public void Deactivate()
    {
        Visible = false;
        ProcessMode = ProcessModeEnum.Disabled;
        SetPhysicsProcess(false);
        Active = false;
        _timer.Stop();
    }

    public void OnDied()
    {
        EmitSignal(SignalName.Died, _config.Score);
        Deactivate();
    }

    public void OnSpawnTimer()
    {
        Shoot();
    }
}