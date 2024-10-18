using Godot;

//Characters actually participating in a fight
public partial class Fighter : Node
{
    public Character character;
    public FighterTeam team;
    //public List<StatusEffect> activeStatusEffects;

    public Fighter(Character _character, FighterTeam _team)
    {
        character = _character;
        team = _team;
    }
}
