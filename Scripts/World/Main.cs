using Godot;
using static GameManager;

public partial class Main : Node2D
{
    [Export] private ShipConfig _shipConfig; 
    [Export] private CannonConfig _cannonConfig;

    [Export] private Marker2D _playerSpawn;
    [Export] private PackedScene _playerScene;
    [Export] private SceneComponent _sceneComponent;
    [Export] private PackedScene _sceneInitial;
    [Export] private Node _startMenu;
    [Export] private EnemySpawner _enemySpawner;
    [Export] private Label _score;

    private Player _player;

    public override void _Ready()
    {
        GameManager.Instance.SetState(GameState.Starting);
        var startMenu = _startMenu as Start;
        startMenu.Started += OnGameStarted;
        _enemySpawner.EnemyKilled += OnEnemyKilled;
    }

    public void OnGameStarted()
    {
        _sceneComponent.Spawn(_sceneInitial, GlobalPosition);
        _playerSpawn = GetNode<Marker2D>("PlayerSpawn");
        _player = _playerScene.Instantiate<Player>();
        _player.GlobalPosition = _playerSpawn.GlobalPosition;
        _player.Init(_shipConfig, _cannonConfig);
        AddChild(_player);
    }

    public void OnEnemyKilled(int score)
    {
        var current = _score.Text.ToInt();
        _score.Text = (current + score).ToString();
    }
}
