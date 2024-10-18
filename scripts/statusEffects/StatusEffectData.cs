using Godot;

//Serializable status effect data
[GlobalClass]
public partial class StatusEffectData : Resource
{
    [Export]
    public StatusEffectType type = StatusEffectType.Buff;
    [Export]
    public int turnDuration = 1;
    [Export]
    public Alignment alignment = Alignment.None;
    [Export]
    public DamageType damageType = DamageType.Primal;
    //func for per turn effect
    //func for add passive effect
    //func for remove passive effect
}
