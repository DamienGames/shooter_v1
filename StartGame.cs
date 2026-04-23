using Godot;

public partial class StartGame : Control
{
    [Export] public TextureButton botaoStart;
    [Export] public TextureButton botaoQuit;
    [Export] public PackedScene PackedScene;

    public override void _Ready()
    {
        botaoStart.Pressed += OnIniciarPressed;
        botaoQuit.Pressed += OnSairPressed;
    }

    public void OnIniciarPressed()
    {
        GD.Print("TESTE inicio");
    }

    public void OnSairPressed()
    {
        GD.Print("TESTE sair");
    }
}
