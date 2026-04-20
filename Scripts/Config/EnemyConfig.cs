using Godot;

[GlobalClass]
public partial class EnemyConfig : Resource
{
    [ExportGroup("Base")]
    [Export] public string Id { get; set; }
    [Export] public string DisplayName { get; set; }
    [Export] public int PoolSize { get; set; } = 10;


    [ExportGroup("Combat")]
    [Export] public float MovingSpeed { get; set; } = 200f;
    [Export] public float Damage { get; set; } = 10;
    [Export] public float Shield { get; set; } = 0;

    [ExportGroup("Visual")]
    [Export] public Texture2D DisplayIcon;
    [Export] public PackedScene EnemyScene;
}
