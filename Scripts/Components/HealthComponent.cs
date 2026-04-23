using Godot;
using System.Reflection.Emit;
using static System.Net.Mime.MediaTypeNames;

public partial class HealthComponent : Node
{
    #region Signals
    [Signal] public delegate void DiedEventHandler();
    [Signal] public delegate void HealthChangedEventHandler(float currentHealth);
    [Signal] public delegate void HealthFullEventHandler(float currentHealth);
    #endregion

    #region Exports
    [Export] private int maxHealth = 100;

    #endregion

    #region Properties
    private float _currentHealth;
    private bool _dead;
    public bool Dead => _dead;
    #endregion

    #region Métodos

    public override void _Ready()
    {
        _currentHealth = maxHealth;
    }

    public void TakeDamage(float ammount)
    {
        if (_currentHealth <= 0)
            return;

        _currentHealth -= ammount;
        EmitSignal(SignalName.HealthChanged, _currentHealth);

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            EmitSignal(SignalName.Died);
        }
    }

    public void Heal(float amount)
    {
        _currentHealth += amount;
        if (_currentHealth > maxHealth)
            _currentHealth = maxHealth;
        EmitSignal(SignalName.HealthChanged, _currentHealth);
    }

    public void FullHeal()
    {
        if (_currentHealth != maxHealth)
            _currentHealth = maxHealth;
        EmitSignal(SignalName.HealthFull, _currentHealth);
    }
    #endregion
}