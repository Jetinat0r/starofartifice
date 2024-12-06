//Instance of status effect
using Godot;

public partial class StatusEffect
{
    [Export]
    public StatusEffectType type = StatusEffectType.Buff;
    [Export]
    public int turnDuration = 1;
    [Export]
    public Alignment alignment = Alignment.None;
    [Export]
    public DamageType damageType = DamageType.Primal;

    //Instance Variable
    public int remainingTurns;

    public StatusEffect()
    {
        remainingTurns = turnDuration;
    }
}
