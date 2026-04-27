using Godot;
using System;
using static GameManager;

public partial class GameOver : Control
{

    [Signal] public delegate void OverEventHandler();

    [Export] Button RestartButton;
    public override void _Ready()
    {
        RestartButton.ButtonUp += OnButtonUp;
    }

    public void OnButtonUp()
    {
        GameManager.Instance.SetState(GameState.Starting);

        GetTree().ReloadCurrentScene();

        EmitSignal(SignalName.Over);
    }
}
