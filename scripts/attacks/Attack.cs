//Instantiated attack based on attack data
//  for use in battles
public class Attack
{
    public AttackData attackData;
    public float retrogradeCounter = 0f;

    public Attack(AttackData _attackData)
    {
        attackData = _attackData;
    }
}
