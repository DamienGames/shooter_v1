using Godot;
using System;
using static GameManager;

public partial class UIManager : CanvasLayer
{
    [Export] private Control _pauseMenu;
    [Export] private Control _gameOverMenu;
    [Export] private Control _startMenu;

    public override void _Ready()
    {
        GetTree().Paused = true;
        base._Ready();
    }

    public override void _Process(double delta)
    {
        var state = GameManager.Instance.CurrentState;

        _startMenu.Visible = state == GameState.Starting;
        _pauseMenu.Visible = state == GameState.Paused;
        if (state == GameState.GameOver)
        {
            GD.Print("GAmeOver");
        }
        _gameOverMenu.Visible = state == GameState.GameOver;
    }
}
