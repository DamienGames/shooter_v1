using Godot;

public partial class Main : Node2D
{
    [Export] private PlayerConfig _playerConfig;
    [Export] private Marker2D _playerSpawn;

    private Player _player;

    public override void _Ready()
    {
        _playerSpawn = GetNode<Marker2D>("PlayerSpawn");
        _player = _playerConfig.PlayerScene.Instantiate<Player>();
        _player.GlobalPosition = _playerSpawn.GlobalPosition;
        AddChild(_player);
    }
}
