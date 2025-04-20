using Godot;

[GlobalClass]
public partial class AttackList : Resource
{
    [Export]
    public List<Attack> playerPhysicalAttacks = new List<Attack>();
    [Export]
    public List<Attack> playerSpells = new List<Attack>();
    [Export]
    public List<Attack> enemyPhysicalAttacks = new List<Attack>();
    [Export]
    public List<Attack> enemySpecialAttacks = new List<Attack>();

    public AttackList()
    {
        //Player Attacks
        
        //Enemy Attacks
        enemySpecialAttacks.Add(new Attack("Feather Attack", 0.2, 0, 0, None, 0, Physical, true, false, Attack, All, new Effect(None, 0, 0), new Effect(None, 0, 0), 0));
		enemySpecialAttacks.Add(new Attack("Talon Terror", 0.5, 0, 0, None, 0, Physical, true, false, Attack, Single, new Effect(None, 0, 0), new Effect(None, 0, 0), 0));
		enemySpecialAttacks.Add(new Attack("Siren", 0.3, 0, 0, None, 0, Primal, true, false, Attack, Single, new Effect(Stunned, 1, 0), new Effect(None, 0, 0)));

		enemySpecialAttacks.Add(new Attack("Glue Grenade", 0.6, 0, 0, None, 0, Physical, true, false, Attack, All, new Effect(Stunned, 1, 0), new Effect(None, 0, 0), 0));
		enemySpecialAttacks.Add(new Attack("Slime Blast", 0.2, 0, 0, None, 0, Physical, true, false, Attack, Single, new Effect(None, 0, 0), new Effect(None, 0, 0), 0));
		enemySpecialAttacks.Add(new Attack("Slime Rapid Fire", 0.2, 0, 0, None, 0, Physical, true, false, Attack, Single, new Effect(None, 0, 0), new Effect(None, 0, 0), 0));

		enemySpecialAttacks.Add(new Attack("Claw Launch", 0.3, 0, 0, None, 0, Physical, true, false, Attack, Single, new Effect(None, 0, 0), new Effect(None, 0, 0), 0));
    }
}