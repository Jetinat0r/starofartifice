using Godot;
using Godot.Collections;

[GlobalClass]
public partial class Character : Node
{
    [Export]
    public string characterName = "DEFAULT NAME";
    //[Export]
    //public SpriteSet spriteSet; //Full of sprite data
    [Export]
    public Texture2D debugCharacterTexture;
    [Export]
    public float maxHp = 1f;
    [Export]
    public float maxMana = 1f;
    [Export]
    public float baseAttack = 1f;
    [Export]
    public float baseDefense = 1f;
    [Export]
    public float baseDamageResistance = 1f;
    [Export]
    public float baseSpeed = 1f;
    //Base chance to be targeted by enemy attacks
    [Export]
    public float baseTargetChance = 1f;
    [Export]
    public float baseCritChange = 1f;
    [Export]
    public Array<Attack> knownAttacks = new Array<Attack>();

    //Instance vars
    public float curHp;
    public float curMana;

    public Character()
    {
        curHp = maxHp;
        curMana = maxMana;
    }
}
