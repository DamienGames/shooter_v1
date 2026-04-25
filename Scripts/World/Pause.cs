using Godot;
using static GameManager;

public partial class Pause : Control
{
	[Export] Button ResumeButton;

	public override void _Ready()
	{
        ResumeButton.ButtonUp += OnButtonUp;
    }

	public void OnButtonUp()
	{
        GameManager.Instance.SetState(GameState.Playing);
    }
}
