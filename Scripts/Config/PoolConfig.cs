using Godot;

[GlobalClass]
public partial class PoolConfig : Resource
{
    [Export] public PackedScene EnemyScene { get; set; }

    [Export] public int PoolSize { get; set; } = 10;

    [Export] public string Id { get; set; } = "";
}