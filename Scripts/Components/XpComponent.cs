using Godot;
using System;

public partial class XPComponent : Node
{ 
    #region Signals

    [Signal] public delegate void XpChangedEventHandler(int current, int required);
    [Signal] public delegate void LeveledEventHandler(int newLevel);
    #endregion

    #region Exports

    [Export] private int baseXpRequired = 10;
    [Export] private float growthFactor = 1.5f;
    #endregion

    #region Properties

    public int Level { get; private set; } = 1;
    public int CurrentXp { get; private set; }
    public int RequiredXp => CalculateRequiredXp(Level);
    #endregion

    #region Métodos

    public override void _Ready()
    {
        EmitSignal(SignalName.XpChanged, CurrentXp, RequiredXp);
    }

    public void AddXp(int amount)
    {
        if (amount <= 0)
            return;

        CurrentXp += amount;

        while (CurrentXp >= RequiredXp)
        {
            CurrentXp -= RequiredXp;
            LevelUp();
        }

        EmitSignal(SignalName.XpChanged, CurrentXp, RequiredXp);
    }

    private void LevelUp()
    {
        Level++;
        EmitSignal(SignalName.Leveled, Level);
    }

    private int CalculateRequiredXp(int level)
    {
        return (int)(baseXpRequired * Math.Pow(growthFactor, level - 1));
    }
    #endregion
}