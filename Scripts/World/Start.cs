using Godot;
using System;
using static GameManager;

public partial class Start : Control
{
    [Signal] public delegate void StartedEventHandler();


    [Export] Button StartButton;
    public override void _Ready()
    {
        StartButton.ButtonUp += OnButtonUp;
    }

    public void OnButtonUp()
    {
        GameManager.Instance.SetState(GameState.Playing);
        EmitSignal(SignalName.Started);
    }
}
