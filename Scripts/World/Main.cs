using Godot;

public partial class Main : Node2D
{
    [Export] private ShipConfig _shipConfig; 
    [Export] private CannonConfig _cannonConfig;

    [Export] private Marker2D _playerSpawn;
    [Export] private PackedScene _playerScene;
    [Export] private SceneComponent _sceneComponent;
    [Export] private PackedScene _sceneInitial;

    private Player _player;

    public override void _Ready()
    {
        _sceneComponent.Spawn(_sceneInitial, GlobalPosition);
        _playerSpawn = GetNode<Marker2D>("PlayerSpawn");
        _player = _playerScene.Instantiate<Player>();
        _player.GlobalPosition = _playerSpawn.GlobalPosition;
        _player.Setup(_shipConfig, _cannonConfig);
        AddChild(_player);
    }
}
