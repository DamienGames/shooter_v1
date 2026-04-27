using Godot;

public partial class GameManager : Node
{
    public static GameManager Instance;

    public GameState CurrentState { get; private set; } = GameState.Starting;

    public override void _Ready()
    {
        Instance = this;
    }

    public void SetState(GameState newState)
    {
        CurrentState = newState;

        switch (newState)
        {
            case GameState.Playing:
                GetTree().Paused = false;
                break;

            case GameState.Paused:
                GetTree().Paused = true;
                break;

            case GameState.GameOver:
                GetTree().Paused = false;
                break;
        }
    }

    public enum GameState
    {
        Starting,
        Playing,
        Paused,
        GameOver
    }
}
