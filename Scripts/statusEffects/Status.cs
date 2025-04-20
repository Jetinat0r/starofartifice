//Statuses are used for secondary effects
public enum Status: int
{
    None,
    AtkChange,
    DefChange, 
    SpdChange, 
    HpChange, //Healing or true dmg
    SPChange,
    AggroChange, 
    NoMiss,
    Shield,
    Counter,
    Revive,
    Bleeding,
    Burning,
    Paralysis,
    Silenced,
    Blighted,
    Stunned,
    Blocked,
    ActionAdvance
}