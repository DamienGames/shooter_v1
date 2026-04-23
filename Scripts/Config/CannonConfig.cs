using Godot;

[GlobalClass]
public partial class CannonConfig : Resource
{
    [ExportGroup("Base")]
    [Export] public string Id { get; set; }
    [Export] public string DisplayName { get; set; }

    [ExportGroup("Combat")]
    [Export] public float Damage { get; set; } = 5;
    [Export] public float AttackSpeed { get; set; } = 1;
    [Export] public float Range { get; set; } = 100;
    [Export] public float Burst { get; set; } = 1;

    [ExportGroup("Visual")]
    [Export] public Texture2D DisplayIcon;
    [Export] public Texture2D CannonSprite;
    [Export] public PackedScene ProjectileScene;

    public enum CannonType
    {
        Bullet,
        Missile,
        Shot,
        Laser
    }
}
