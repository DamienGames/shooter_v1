//using Godot;

//public partial class AttackComponent : Node
//{
//    #region Signals

//    #endregion
   
//    #region Exports

//    [Export] public WeaponConfig Config;
//    [Export] public Node2D Owner;

//    [Export] public ProjectileSpawner ProjectileSpawner;
//    [Export] public MeleeAttack Melee;
//    [Export] public AreaAttack Area;
//    #endregion

//    #region Properties

//    private float _cooldown;
//    #endregion

//    #region Métodos

//    public override void _Process(double delta)
//    {
//        if (_cooldown > 0)
//            _cooldown -= (float)delta;
//    }

//    public void TryAttack()
//    {
//        if (_cooldown > 0 || Config == null)
//            return;

//        switch (Config.Pattern)
//        {
//            case WeaponConfig.AttackPattern.Hit:
//            case WeaponConfig.AttackPattern.Arc:
//                Melee.Execute(Config);
//                break;

//            case WeaponConfig.AttackPattern.Projectile:
//            case WeaponConfig.AttackPattern.Boomerang:
//            case WeaponConfig.AttackPattern.Bounce:
//                ProjectileSpawner.Execute(Config);
//                break;

//            case WeaponConfig.AttackPattern.Pulse:
//            case WeaponConfig.AttackPattern.Zone:
//            case WeaponConfig.AttackPattern.Aura:
//                Area.Execute(Config);
//                break;

//            //  ESPECIAIS (implementa depois)
//            case WeaponConfig.AttackPattern.Beam:
//            case WeaponConfig.AttackPattern.Orbit:
//            case WeaponConfig.AttackPattern.Rain:
//            case WeaponConfig.AttackPattern.Chain:
//            case WeaponConfig.AttackPattern.Trap:
//            case WeaponConfig.AttackPattern.Dash:
//            case WeaponConfig.AttackPattern.Repeat:
//            case WeaponConfig.AttackPattern.Binary:
//                GD.Print($"Pattern ainda não implementado: {Config.Pattern}");
//                break;
//            default:
//                GD.PrintErr($"Pattern desconhecido: {Config.Pattern}");
//                break;
//        }

//        _cooldown = Config.Cooldown;
//    }
//    #endregion
//}

