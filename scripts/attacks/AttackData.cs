using Godot;

//Serializable attack data
[GlobalClass]
public partial class AttackData : Resource
{
    [Export]
    public float baseAttackDamage = 1f;
    [Export]
    public float manaCost = 1f;
    [Export]
    public int turnUpkeep = 1;
    [Export]
    public float retrogradeModifier = 1f;
    [Export]
    public Alignment resonanceAlignment = Alignment.None;
    [Export]
    public float resonanceBonus = 1.0f;
    [Export]
    public DamageType damageType = DamageType.Arcane;
    [Export]
    public string attackName = "DEFAULT ATTACK";
    [Export]
    public bool canTargetEnemies = false;
    [Export]
    public bool canTargetAllies = true;
    //[Export]
    //public CharacterAnimaitonData characterAnimation;
    //[Export]
    //public MinigameData minigameData;
}
