using Godot;

public partial class Enemy : StaticBody2D
{
    [Signal] public delegate void DiedEventHandler();

    [Export] private HealthComponent _health;

    public bool Active { get; private set; }
    public float Speed { get; private set; } = 100f;

    public override void _Ready()
    {
        _health.Died += OnDied;
        base._Ready();
    }

    public override void _PhysicsProcess(double delta)
    {
        if (Active)
        {
            var player = GetTree().Root.GetNodeOrNull<Player>("Main/Player");
            if (player is not null)
            {
                var distance = GlobalPosition.DistanceTo(player.GlobalPosition);
                if (distance >= 30f)
                {
                    Vector2 dir =
                        (player.GlobalPosition - GlobalPosition)
                        .Normalized();

                    GlobalPosition +=
                        dir *
                        Speed *
                        (float)delta;
                }
            }
        }
    }

    public void Activate(Vector2 pos)
    {
        GlobalPosition = pos;

        Visible = true;
        ProcessMode = ProcessModeEnum.Inherit;
        SetPhysicsProcess(true);

        Active = true;
    }

    public void Deactivate()
    {
        Visible = false;
        ProcessMode = ProcessModeEnum.Disabled;
        SetPhysicsProcess(false);
        Active = false;
    }

    public void OnDied()
    {
         EmitSignal(SignalName.Died);
        Deactivate();
    }
}