using Godot;
using Godot.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


public partial class Battle : Node
{
    [Export]
    public Array<Node3D> playerTeamSlots = new Array<Node3D>();
    [Export]
    public Array<Node3D> enemyTeamSlots = new Array<Node3D>();
    [Export]
    public Array<Node3D> neutralTeamSlots = new Array<Node3D>();

    //Used to hold upcoming and previous turns
    public List<List<BattleTurn>> battleRounds = new List<List<BattleTurn>>();

    //Stores all player fighters in the battle
    public List<Fighter> playerTeam = new List<Fighter>();
    //Stores all enemy fighters in the battle
    public List<Fighter> enemyTeam = new List<Fighter>();
    //Stores all neutral fighters in the battle
    public List<Fighter> neutralTeam = new List<Fighter>();

    //Turn counter
    public int curTurn = 0;
    //Round counter
    public int curRound = 0;
    private bool DEBUG_INPUT_BLOCKER = false;

    [Export]
    private Label DEBUG_TURN_LABEL;
    private bool DEBUG_STARTED = false;
    private RandomNumberGenerator DEBUG_RAND = new RandomNumberGenerator();
    [Export]
    private Node3D DEBUG_ATTACKER_SELECTOR;
    [Export]
    private Node3D DEBUG_DEFENDER_SELECTOR;
    private int DEBUG_TARGET = 0;
    private bool DEBUG_ENEMY_TARGETED = false;

    public void InitBattle(Array<Character> _playerTeam, Array<Character> _enemyTeam, Array<Character> _neutralTeam)
    {
        curTurn = -1;
        curRound = 0;

        battleRounds.Clear();

        playerTeam.Clear();
        enemyTeam.Clear();
        neutralTeam.Clear();

        for (int i = 0; i < _playerTeam.Count; i++)
        {
            playerTeam.Add(new Fighter(_playerTeam[i], FighterTeam.Player));
            if(i < playerTeamSlots.Count)
            {
                Sprite3D _newPlayerSprite = new Sprite3D();
                _newPlayerSprite.Texture = _playerTeam[i].debugCharacterTexture;
                playerTeamSlots[i].AddChild(_newPlayerSprite);
            }
            else
            {
                GD.PushWarning("Too many fighters on the Player team, not enough character slots!");
            }
        }

        for (int i = 0; i < _enemyTeam.Count; i++)
        {
            enemyTeam.Add(new Fighter(_enemyTeam[i], FighterTeam.Enemy));
            if (i < playerTeamSlots.Count)
            {
                Sprite3D _newEnemySprite = new Sprite3D();
                _newEnemySprite.Texture = _enemyTeam[i].debugCharacterTexture;
                enemyTeamSlots[i].AddChild(_newEnemySprite);
            }
            else
            {
                GD.PushWarning("Too many fighters on the Enemy team, not enough character slots!");
            }
        }

        for (int i = 0; i < _neutralTeam.Count; i++)
        {
            neutralTeam.Add(new Fighter(_neutralTeam[i], FighterTeam.None));
            if (i < neutralTeamSlots.Count)
            {
                Sprite3D _newNeutralSprite = new Sprite3D();
                _newNeutralSprite.Texture = _neutralTeam[i].debugCharacterTexture;
                neutralTeamSlots[i].AddChild(_newNeutralSprite);
            }
            else
            {
                GD.PushWarning("Too many fighters on the Neutral team, not enough character slots!");
            }
        }

        battleRounds.Add(PrepRound(curRound));
        IncrementTurn();
        DEBUG_STARTED = true;
    }

    public List<BattleTurn> PrepRound(int _round)
    {
        List<BattleTurn> _newTurns =  new List<BattleTurn>();

        foreach(Fighter f in playerTeam)
        {
            if(f.character.curHp > 0)
            {
                BattleTurn _newTurn = new BattleTurn(f, _round);
                _newTurns.Add(_newTurn);
            }
        }

        foreach (Fighter f in enemyTeam)
        {
            if (f.character.curHp > 0)
            {
                BattleTurn _newTurn = new BattleTurn(f, _round);
                _newTurns.Add(_newTurn);
            }
        }

        foreach (Fighter f in neutralTeam)
        {
            if (f.character.curHp > 0)
            {
                BattleTurn _newTurn = new BattleTurn(f, _round);
                _newTurns.Add(_newTurn);
            }
        }

        _newTurns.Sort(SortSpeedAscendingHelper.SortSpeedAscending());
        GD.Print($"Round {_round} Generated:");
        for (int i = 0; i < _newTurns.Count; i++)
        {
            GD.Print($"    Turn {i} : {_newTurns[i].fighter.character.characterName}");
        }

        return _newTurns;
    }

    public void IncrementTurn()
    {
        curTurn++;

        if(curTurn >= battleRounds[curRound].Count)
        {
            curTurn = 0;
            curRound += 1;
            if (curRound >= battleRounds.Count)
            {
                battleRounds.Add(PrepRound(curRound));
            }
        }

        Fighter _nextFighter = battleRounds[curRound][curTurn].fighter;
        DEBUG_TURN_LABEL.Text = $"Cur Turn: {(_nextFighter.team == FighterTeam.Player ? "Player" : "Enemy")}\nRound Number: {curRound}\nTurn Number: {curTurn}";
        //GD.Print($"Num Rounds: {battleRounds.Count}");
        //GD.Print($"Num Turns: {battleRounds[curRound].Count}");
        if(_nextFighter.team == FighterTeam.Player)
        {
            int _fighterIndex = playerTeam.FindIndex(f => f == _nextFighter);

            DEBUG_ATTACKER_SELECTOR.GlobalPosition = playerTeamSlots[_fighterIndex].GlobalPosition + new Vector3(0f, 1.6f, 0f);
        }
        else
        {
            int _fighterIndex = enemyTeam.FindIndex(f => f == _nextFighter);

            DEBUG_ATTACKER_SELECTOR.GlobalPosition = enemyTeamSlots[_fighterIndex].GlobalPosition + new Vector3(0f, 1.6f, 0f);
        }
    }

    public void ExecuteAttack(Fighter _attacker, Fighter _defender, Attack _attackUsed)
    {
        int _num = DEBUG_RAND.RandiRange(0, 2);
        string _effectivenessText = ".";
        switch (_num)
        {
            case 0:
                _effectivenessText = ".";
                break;
            case 1:
                _effectivenessText = ", it was not very effective...";
                break;
            case 2:
                _effectivenessText = ", it was super effective!";
                break;
        }
        GD.Print($"{_attacker.character.Name} used {_attackUsed.attackName} on {_defender.character.Name}{_effectivenessText}");

        IncrementTurn();
    }

    public override void _Process(double delta)
    {
        if (!DEBUG_STARTED)
        {
            return;
        }

        //TODO: Basic debug testing attacks
        if (battleRounds[curRound][curTurn].fighter.team == FighterTeam.Player)
        {
            if (Input.IsKeyPressed(Key.J))
            {
                DEBUG_TARGET = 0;
            }
            else if (Input.IsKeyPressed(Key.I))
            {
                DEBUG_TARGET = 1;
            }
            else if (Input.IsKeyPressed(Key.M))
            {
                DEBUG_TARGET = 2;
            }
            else if (Input.IsKeyPressed(Key.K))
            {
                DEBUG_TARGET = 3;
            }

            DEBUG_DEFENDER_SELECTOR.GlobalPosition = enemyTeamSlots[DEBUG_TARGET].GlobalPosition + new Vector3(0f, 1.6f, 0f);


            if (Input.IsKeyPressed(Key.Key1) && !DEBUG_INPUT_BLOCKER)
            {
                DEBUG_INPUT_BLOCKER = true;
                ExecuteAttack(battleRounds[curRound][curTurn].fighter, enemyTeam[DEBUG_TARGET], battleRounds[curRound][curTurn].fighter.character.knownAttacks[0]);
            }
            else if(Input.IsKeyPressed(Key.Key2) && !DEBUG_INPUT_BLOCKER)
            {
                DEBUG_INPUT_BLOCKER = true;
                ExecuteAttack(battleRounds[curRound][curTurn].fighter, enemyTeam[DEBUG_TARGET], battleRounds[curRound][curTurn].fighter.character.knownAttacks[1]);
            }
            else if(!Input.IsKeyPressed(Key.Key1) && !Input.IsKeyPressed(Key.Key2))
            {
                DEBUG_INPUT_BLOCKER = false;
            }
        }
        else
        {
            if (!DEBUG_ENEMY_TARGETED)
            {
                //Select Target
                DEBUG_TARGET = DEBUG_RAND.RandiRange(0, 3);
                DEBUG_DEFENDER_SELECTOR.GlobalPosition = playerTeamSlots[DEBUG_TARGET].GlobalPosition + new Vector3(0f, 1.6f, 0f);
                GD.Print($"ATTACKING {DEBUG_TARGET}");

                DEBUG_ENEMY_TARGETED = true;
            }
            else
            {
                Thread.Sleep(500);

                //Attack
                ExecuteAttack(battleRounds[curRound][curTurn].fighter, playerTeam[DEBUG_TARGET], battleRounds[curRound][curTurn].fighter.character.knownAttacks[0]);

                DEBUG_ENEMY_TARGETED = false;
            }
        }
    }

}
