using Godot;

public partial class SceneComponent : Node
{
    [Export] public Control SceneContainer;

    public override void _Ready()
    {
        if (SceneContainer == null)
        {
            GD.PrintErr("SceneContainer não definido no SceneComponent");
        }
    }

    public T Spawn<T>(PackedScene scene, Vector2 position) where T : Node2D
    {
        if (scene == null || SceneContainer == null)
            return null;

        var instance = scene.Instantiate<T>();
        SceneContainer.AddChild(instance);

        instance.GlobalPosition = position;

        return instance;
    }

    public Node Spawn(PackedScene scene, Vector2 position)
    {
        if (scene == null || SceneContainer == null)
            return null;

        var instance = scene.Instantiate();
        SceneContainer.AddChild(instance);
        return instance;
    }
}