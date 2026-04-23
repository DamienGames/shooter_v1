using Godot;

public partial class StartGame : Control
{
    [Export] public TextureButton botaoStart;
    [Export] public TextureButton botaoQuit;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        botaoStart.Pressed += OnIniciarPressed;
        botaoQuit.Pressed += OnSairPressed;
    }

    public void OnIniciarPressed()
    {

    }

    public void OnSairPressed()
    {

    }
}
