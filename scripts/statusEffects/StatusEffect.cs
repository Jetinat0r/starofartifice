//Instance of status effect
public partial class StatusEffect
{
    public StatusEffectData statusEffectData;
    public int remainingTurns;

    public StatusEffect(StatusEffectData _statusEffectData)
    {
        statusEffectData = _statusEffectData;
        remainingTurns = _statusEffectData.turnDuration;
    }
}
