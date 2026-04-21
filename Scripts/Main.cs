using Godot;

public partial class Main : Node2D
{
    [Export] private ShipConfig _shipConfig;
    [Export] private Marker2D _playerSpawn;
    [Export] private PackedScene _playerScene;

    private Player _player;
    public override void _Ready()
    {
        _playerSpawn = GetNode<Marker2D>("PlayerSpawn");
        _player = _playerScene.Instantiate<Player>();
        _player.GlobalPosition = _playerSpawn.GlobalPosition;
        _player.Setup(_shipConfig);
        AddChild(_player);
    }
}
