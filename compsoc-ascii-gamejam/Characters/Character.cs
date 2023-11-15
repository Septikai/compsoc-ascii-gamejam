namespace compsoc_ascii_gamejam.Characters;

public class Character
{
    private readonly Random _random = new Random();
    protected int MaxHealth { get; set; }
    protected int Health { get; set; }
    protected int Strength { get; set; }
    protected int Agility { get; set; }
    protected int Charisma { get; set; }

    public String GetFormattedHealth()
    {
        return this.Health + "/" + this.MaxHealth;
    }

    public int GetStrength()
    {
        return this.Strength;
    }

    public int GetAgility()
    {
        return this.Agility;
    }

    public bool Damage(int dmg)
    {
        this.Health -= dmg;
        return this.CheckForDeath();
    }

    private bool CheckForDeath()
    {
        return this.Health <= 0;
    }

    public bool StatTest(CharacterStat toTest, int targetVal)
    {
        var testVal = toTest switch
        {
            CharacterStat.MaxHealth => this.MaxHealth,
            CharacterStat.Health => this.Health,
            CharacterStat.Strength => this.Strength,
            CharacterStat.Agility => this.Agility,
            CharacterStat.Charisma => this.Charisma,
            _ => 0
        };

        return testVal + _random.Next(1, 7) >= targetVal;
    }
}