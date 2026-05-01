using Godot;
using Godot.Collections;
using System;

public partial class EnemySpawner : Node2D
{
    [Signal] public delegate void EnemyKilledEventHandler(int score);

    [Export] public EnemyPool Pool { get; set; }
    [Export] public Array<EnemyConfig> SpawnTable { get; set; }
    [Export] public float SpawnInterval { get; set; } = 2f;

    [Export] public Array<Marker2D> EnemySpawns;

    private Timer _timer;

    public override void _Ready()
    {
        _timer = new Timer();
        AddChild(_timer);
        _timer.WaitTime = SpawnInterval;
        _timer.Timeout += OnSpawnTimer;
        Pool.Deactivated += OnEnemyDied;

        _timer.Start();
    }

    private void OnSpawnTimer()
    {
        if (SpawnTable.Count == 0)
            return;

        int index =
            GD.RandRange(0, SpawnTable.Count - 1);

        EnemyConfig config =
            SpawnTable[index];

       var spawnPostition = EnemySpawns[GD.RandRange(0, 2)].GlobalPosition;

        var enemy = Pool.GetEnemy(
            config,
            spawnPostition
        );
    }

    public void OnEnemyDied(int score)
       {
        EmitSignal(SignalName.EnemyKilled, score);
    }
}