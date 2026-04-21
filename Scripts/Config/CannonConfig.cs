using Godot;

[GlobalClass]
public partial class CannonConfig : Node
{
    [ExportGroup("Base")]
    [Export] public string Id { get; set; }
    [Export] public string DisplayName { get; set; }

    [ExportGroup("Combat")]
    [Export] public float Damage { get; set; }
    [Export] public float AttackSpeed { get; set; }
    [Export] public float Range { get; set; }
    [Export] public float Burst { get; set; }

    [ExportGroup("Visual")]
    [Export] public Texture2D DisplayIcon;
    [Export] public PackedScene CannonScene;

    public enum CannonType
    {
        Missile,
        Bullet,
        Shot,
        Laser
    }
}
