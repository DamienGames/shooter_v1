using Godot;
using Godot.Collections;

public partial class EnemyPool : Node2D
{
    [Export] public Array<EnemyConfig> Enemies;

    private Dictionary<EnemyConfig, Array<Enemy>> _pools = new();

    public override void _Ready()
    {
        foreach (var config in Enemies)
        {
            var pool = new Array<Enemy>();

            for (int i = 0; i < config.PoolSize; i++)
            {
                var enemy = config.EnemyScene.Instantiate<Enemy>();
                AddChild(enemy);
                enemy.Deactivate();
                pool.Add(enemy);
            }

            _pools.Add(config, pool);
        }
    }

    public Enemy GetEnemy(EnemyConfig config, Vector2 pos)
    {
        foreach (var enemy in _pools[config])
        {
            if (!enemy.Active)
            {
                enemy.Activate(pos);

                return enemy;
            }
           }

        return null;
    }
}