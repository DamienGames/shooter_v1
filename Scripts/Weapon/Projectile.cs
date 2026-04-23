using Godot;

public partial class Projectile : Area2D
{
    [Export] private ProjectileConfig _config;

    private ProjectileComponent _component;
    private Area2D _area;
    public override void _Ready()
    {
        _component = GetNode<ProjectileComponent>("ProjectileComponent");
        _area = GetNode<Area2D>("HitBox");
        _area.AreaEntered += OnAreaEntered;
    }

    public void Fire(Vector2 direction)
    {
        _component.Init(_config, direction);
    }

    private void OnAreaEntered(Area2D area)
    {
          var groups = area.Owner.GetGroups();
        if (area is HurtboxComponent hurtbox && area.Owner.IsInGroup("enemy"))
        {
            hurtbox.TakeDamage(_config.Damage);
            QueueFree();
        }
    }
}