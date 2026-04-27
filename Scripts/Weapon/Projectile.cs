using Godot;
using static Godot.TextServer;

public partial class Projectile : Area2D
{
    [Export] private ProjectileConfig _config;

    private ProjectileComponent _component;
    private Node _owner;
    private Area2D _area;
    private Vector2 _direction;
    private string _targetGroup;

    public override void _Ready()
    {
        _component = GetNode<ProjectileComponent>("ProjectileComponent");
        _area = GetNode<Area2D>("HitBoxComponent");
        _area.AreaEntered += OnAreaEntered;
    }

    public void Init(Node owner, Vector2 position, string targetGroup)
    {
        GlobalPosition = position;
        _targetGroup = targetGroup;
        _owner = owner;
        Visible = true;
        SetPhysicsProcess(true);
    }


    public void Fire(Vector2 direction)
    {
        _component.Init(_config, direction);
    }

    private void OnAreaEntered(Area2D area)
    {
        if (area is not HurtboxComponent hurtbox)
            return;

        if (hurtbox.GetParent() == _owner)
            return;

         if (!hurtbox.GetParent().IsInGroup(_targetGroup))
            return;

        hurtbox.TakeDamage(_config.Damage);
        QueueFree();
    }
}