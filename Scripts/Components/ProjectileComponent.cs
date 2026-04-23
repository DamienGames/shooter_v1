using Godot;

public partial class ProjectileComponent : Area2D
{
    #region Properties

    private ProjectileConfig _config;
    private Vector2 _direction = Vector2.Right;
    private Node _source;
    private float _lifeTimer;
    #endregion

    #region Métodos

    public void Init(ProjectileConfig config, Node source)
    {
        _config = config;
        _source = source;
        _lifeTimer = config.Lifetime;
    }

    public void SetDirection(Vector2 dir)
    {
        _direction = dir.Normalized();
    }

    public override void _PhysicsProcess(double delta)
    {
        Translate(_direction * _config.Speed * (float)delta);

        _lifeTimer -= (float)delta;
        if (_lifeTimer <= 0)
            QueueFree();
    }

    private void OnBodyEntered(Node body)
    {
        if (body is not HurtboxComponent hurtbox || !hurtbox.CanBeHit())
            return;


        hurtbox.TakeDamage(_config.Damage);

        if (!_config.Pierce)
            QueueFree();
    }
    #endregion


}