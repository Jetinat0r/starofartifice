using Godot;
using Godot.Collections;

public partial class CharacterInstantiator : Node
{
    [Export]
    public Array<Character> playerCharacters = new Array<Character>();
    [Export]
    public Array<Character> enemyCharacters = new Array<Character>();

    public override void _Ready()
    {
        
    }
}
