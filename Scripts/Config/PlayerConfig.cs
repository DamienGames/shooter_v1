using Godot;

[GlobalClass]
public partial class PlayerConfig : Resource
{
    [ExportGroup("Base")]
    [Export] public string Id { get; set; }
    [Export] public string DisplayName { get; set; }

    [ExportGroup("Combat")]
    [Export] public string MovingSpeed { get; set; }
    [Export] public string Damage { get; set; }
    [Export] public string Shield { get; set; }

    [ExportGroup("Visual")]
    [Export] public Texture2D DisplayIcon;
    [Export] public PackedScene PlayerScene;
}
