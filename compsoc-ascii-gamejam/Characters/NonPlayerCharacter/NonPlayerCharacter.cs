namespace compsoc_ascii_gamejam.Characters.NonPlayerCharacter;

public class NonPlayerCharacter : Character
{
    public NonPlayerCharacter(int maxHealth, int strength, int agility, int charisma)
    {
        this.MaxHealth = maxHealth;
        this.Health = maxHealth;
        this.Strength = strength;
        this.Agility = agility;
        this.Charisma = charisma;
    }
    
    public void ModifyStat(CharacterStat stat, int val)
    {
        switch (stat)
        {
            case CharacterStat.Health:
                this.Health += val;
                break;
            case CharacterStat.MaxHealth:
                this.Health += val;
                break;
            case CharacterStat.Strength:
                this.Health += val;
                break;
            case CharacterStat.Agility:
                this.Health += val;
                break;
            case CharacterStat.Charisma:
                this.Health += val;
                break;
        }
    }
}