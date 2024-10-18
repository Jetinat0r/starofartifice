using Godot;
using Godot.Collections;

//Serializable character data
[GlobalClass]
public partial class CharacterData : Resource
{
    [Export]
    public string characterName = "DEFAULT NAME";
    //[Export]
    //public SpriteData spriteSet;
    [Export]
    public Array<AttackData> knownAttacks = new Array<AttackData>();
    [Export]
    public CharacterStats stats;
}
