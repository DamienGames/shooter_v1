using Godot;

public partial class GameManager : Node
{
    public static GameManager Instance;

    public GameState CurrentState { get; private set; } = GameState.Playing;

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
                GetTree().Paused = true;
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
