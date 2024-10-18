using Godot;
using System.Collections.Generic;


public partial class Battle : Node
{
    //Used to hold upcoming turns
    public List<BattleTurn> currentRound = new List<BattleTurn>();
    //Used to hold next round's turns
    public List<BattleTurn> nextRound = new List<BattleTurn>();
    //Used to hold most recently used turns
    public List<BattleTurn> spentTurns = new List<BattleTurn>();

    //Stores all player fighters in the battle
    public List<Fighter> playerTeam = new List<Fighter>();
    //Stores all enemy fighters in the battle
    public List<Fighter> enemyTeam = new List<Fighter>();
    //Stores all neutral fighters in the battle
    public List<Fighter> neutralTeam = new List<Fighter>();
}
