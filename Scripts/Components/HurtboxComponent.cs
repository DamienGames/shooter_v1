using System;
using System.Threading;
using System.Threading.Tasks;
using Godot;
using static System.Net.Mime.MediaTypeNames;
using static HitboxComponent;

public partial class HurtboxComponent : Area2D
{
    #region Signals

    [Signal] public delegate void HurtEventHandler(Node2D other);
    [Signal] public delegate void BlockedEventHandler(Node2D other);
    [Signal] public delegate void InvincibleStartedEventHandler(float duration);
    [Signal] public delegate void InvincibleEndedEventHandler();
    #endregion

    #region Exports

    [Export] public PackedScene DamageNumberScene;
    #endregion

    #region Properties

    private bool _is_invincible;
    private HealthComponent _health;
    private HitboxComponent _hitbox;

    #endregion

    #region Métodos

    public override void _Ready()
    {
        _health = GetParent().GetNode<HealthComponent>("HealthComponent");
        _hitbox = GetParent().GetNodeOrNull<HitboxComponent>("HitboxComponent");
        AreaEntered += OnAreaEntered;
    }

    private void OnAreaEntered(Area2D area)
    {
        if (area is not HitboxComponent hitbox)
            return;

        if (_is_invincible)
        {
            EmitSignal(SignalName.Blocked, area);
            return;
        }

        EmitSignal(SignalName.Hurt, hitbox); // ou DamageContext se vier do hitbox
    }

    public void ShowDamageNumber(float damage)
    {
        var numberScene = DamageNumberScene.Instantiate<Node2D>();
        GetParent().AddChild(numberScene);
        numberScene.GlobalPosition = GlobalPosition;
        //numberScene.Setup(damage, GD.Randf() > 0.5f);
    }

    public async void SetInvincible(bool active, float duration = 0)
    {
        _is_invincible = active;

        if (active)
            EmitSignal(SignalName.InvincibleStarted, duration);

        if (duration > 0)
        {
            await ToSignal(GetTree().CreateTimer(0.5f), SceneTreeTimer.SignalName.Timeout);
            SetInvincible(false);
        }
        else
        {
            EmitSignal(SignalName.InvincibleStarted, duration);
        }
    }

    public bool CanBeHit()
    {
        return !_is_invincible && _health != null && !_health.Dead;
    }

    public void TakeDamage(float ammount)
    {
        _health.TakeDamage(ammount);
        ShowDamageNumber(ammount);
        EmitSignal(SignalName.Hurt, ammount);
    }

    #endregion
}