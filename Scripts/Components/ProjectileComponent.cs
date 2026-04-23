using Godot;
public partial class ProjectileComponent : Node
{
    private ProjectileConfig _config;
    private Vector2 _direction;
    private float _timeAlive;

    public void Init(ProjectileConfig config, Vector2 direction)
    {
        _config = config;
        _direction = direction.Normalized();
    }

    public override void _Process(double delta)
    {
        if (_config == null) return;

        _timeAlive += (float)delta;

        var parent = GetParent<Node2D>();
        parent.Position += _direction * _config.Speed * (float)delta;

        if (_timeAlive >= _config.Lifetime)
        {
            parent.QueueFree();
        }
    }
}