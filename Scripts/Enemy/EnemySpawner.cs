using Godot;
using Godot.Collections;

public partial class EnemySpawner : Node2D
{
    [Export] public EnemyPool Pool { get; set; }
    [Export] public Array<EnemyConfig> SpawnTable { get; set; }
    [Export] public float SpawnInterval { get; set; } = 2f;

    private Timer _timer;

    public override void _Ready()
    {
        _timer = new Timer();
        AddChild(_timer);
        _timer.WaitTime = SpawnInterval;
        _timer.Timeout += OnSpawnTimer;
        _timer.Start();
    }

    void OnSpawnTimer()
    {
        if (SpawnTable.Count == 0)
            return;

        int index =
            GD.RandRange(0, SpawnTable.Count - 1);

        EnemyConfig config =
            SpawnTable[index];

        Pool.GetEnemy(
            config,
            GlobalPosition
        );
    }
}