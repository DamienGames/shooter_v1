using Godot;
using System;

public partial class ScoreManager : Node
{
    public int Score { get; private set; }

    public void AddScore(int value)
    {
        Score += value;
        GD.Print($"Score: {Score}");
    }
}
