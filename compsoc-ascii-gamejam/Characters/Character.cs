namespace compsoc_ascii_gamejam.Characters;

public class Character
{
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
}