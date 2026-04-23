using Godot;

[GlobalClass]
public partial class ProjectileConfig : Resource
{
    #region Exports
    [ExportGroup("Combat")]
    [Export] public float Speed = 400f;
    [Export] public float Damage = 10f;
    [Export] public float Lifetime = 3f;

    [ExportGroup("Behavior")]
    [Export] public bool Pierce = false;
    [Export] public int MaxBounce = 0;
    [Export] public bool ReturnToOwner = false;
    [Export] public int KnockbackForce = 0;
    [Export] public int PullForce = 0;

    [ExportGroup("View")]
    [Export] public Texture2D ProjectileSprite;

    #endregion

    #region Enums
    public enum EffectPhase
    {
        OnHit,
        Control,
        Movement,
        DamageOverTime
    }
    #endregion
}

