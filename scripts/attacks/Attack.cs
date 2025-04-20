using Godot;

//Instantiated attack based on attack data
//  for use in battles
[GlobalClass]
public partial class Attack : Resource
{
    [Export]
    public string attackName = "DEFAULT ATTACK";
    [Export]
    public float baseAttackDamage = 1f;
    [Export]
    public float manaCost = 1f;
    [Export]
    public int turnUpKeep = 1;
    [Export]
    public float retrogradeModifier = 1f;
    [Export]
    public Alignment resonanceAlignment = Alignment.None;
    [Export]
    public float resonanceBonus = 1.0f;
    [Export]
    public DamageType damageType = DamageType.Arcane;
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
    [Export]
    public Stat statUsed = Attack;
    [Export]
    public AOE enemiesAffected = Single;
    //Placeholders for secondary effects
    [Export]
    public Effect one;
    [Export]
    public Effect two;
    [Export]
    public int requiredLevel;

    public Attack(string attackName, float baseAttackDamage, float manaCost, int turnUpKeep, Alignment resonanceAlignment, float resonanceBonus, DamageType damageType, 
    bool canTargetEnemies, bool canTargetAllies, Stat statUsed, AOE enemiesAffected, Effect one, Effect two, int requiredLevel)
    {
        this.attackName = attackName;
        this.baseAttackDamage = baseAttackDamage;
        this.manaCost = manaCost;
        this.turnUpKeep = turnUpKeep;
        this.resonanceAlignment = resonanceAlignment;
        this.resonanceBonus = resonanceBonus;
        this.damageType = damageType;
        this.canTargetEnemies = canTargetEnemies;
        this.canTargetAllies = canTargetAllies;
        this.statUsed = statUsed;
        this.enemiesAffected = enemiesAffected;
        this.one = one;
        this.two = two;
        this.requiredLevel = requiredLevel;
    }
}
