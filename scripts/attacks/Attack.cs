using Godot;

//Instantiated attack based on attack data
//  for use in battles
[GlobalClass]
public partial class Attack : Resource
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
    public bool canTargetEnemies = true;
    [Export]
    public bool canTargetAllies = false;
    //[Export]
    //public CharacterAnimaitonData characterAnimation;
    //[Export]
    //public MinigameData minigameData;

    //Instance counter
    public float retrogradeCounter = 0f;
}
