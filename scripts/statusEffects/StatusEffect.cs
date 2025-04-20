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
    [Export]
    public float efficacy = 0;
    [Export]
    public Status statusEffect = None;

    //Instance Variable
    public int remainingTurns;

    public StatusEffect(float efficacy, Status statusEffect)
    {
        this.efficacy = efficacy;
        this.statusEffect = statusEffect;
        remainingTurns = turnDuration;
    }
}
