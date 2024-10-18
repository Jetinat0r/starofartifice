using Godot;

//Serializable character stats
[GlobalClass]
public partial class CharacterStats : Resource
{
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
    [Export]
    public float baseTaunt = 1f;
    [Export]
    public float baseCritChange = 1f;
}
