using Godot;
using Godot.Collections;

public partial class BattleTester : Node
{
    [Export]
    public CharacterInstantiator characters;
    [Export]
    public Battle battle;
    private bool startedBattle = false;
    public override void _Process(double delta)
    {
        if (Input.IsKeyPressed(Key.A) && !startedBattle)
        {
            InitBattleNode();
        }
    }

    public void InitBattleNode()
    {
        battle.InitBattle(characters.playerCharacters, characters.enemyCharacters, new Array<Character>());
        startedBattle = true;
    }
}
