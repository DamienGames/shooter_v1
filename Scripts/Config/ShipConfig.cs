using Godot;

[GlobalClass]
public partial class ShipConfig : Resource
{
    [ExportGroup("Base")]
    [Export] public string Id { get; set; }
    [Export] public string DisplayName { get; set; }

    [ExportGroup("Combat")]
    [Export] public float MaxHealth;
    [Export] public float MovingSpeed { get; set; } = 300f;   
    [Export] public float Shield { get; set; } = 5f;    
    [Export] public float Energy { get; set; } = 100f;

    [ExportGroup("Visual")]
    [Export] public Texture2D DisplayIcon;
    [Export] public Texture2D ShipSprite;
}
