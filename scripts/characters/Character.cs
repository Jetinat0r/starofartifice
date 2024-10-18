using Godot;

public partial class Character : Node
{
    public CharacterData characterData;
    public float curHp;
    public float curMana;

    public Character(CharacterData _characterData)
    {
        characterData = _characterData;

        curHp = characterData.stats.maxHp;
        curMana = characterData.stats.maxMana;
    }
}
