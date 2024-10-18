//Holds all necessary data to determine own order in battle
//  and what character to use
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
