//Holds all necessary data to determine own order in battle
//  and what character to use
using System.Collections.Generic;

public partial class BattleTurn
{
    public Fighter fighter;
    //What round this turn occurs in
    public int round;
    //What place in the round this turn should attempt to fall into
    //  ties are broken by the first turn added is used first
    //Higher speeds are first
    public float speed;

    public BattleTurn(Fighter _fighter, int _round)
    {
        fighter = _fighter;
        round = _round;

        //speed = fighter.stats.speed;
    }

    public BattleTurn(Fighter _fighter, int _round, float _speed)
    {
        fighter = _fighter;
        round = _round;
        speed = _speed;
    }
}

//Sorting function for turn order
public class SortSpeedAscendingHelper : IComparer<BattleTurn>
{
    public static IComparer<BattleTurn> SortSpeedAscending()
    {
        return new SortSpeedAscendingHelper();
    }

    public int Compare(BattleTurn x, BattleTurn y)
    {
        if (x.fighter.GetSpeed() > y.fighter.GetSpeed())
        {
            return -1;
        }
        else if (x.fighter.GetSpeed() < y.fighter.GetSpeed())
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}