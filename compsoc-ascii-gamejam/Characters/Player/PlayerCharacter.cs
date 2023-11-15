namespace compsoc_ascii_gamejam.Characters.Player;

public class PlayerCharacter : Character
{
    private static readonly PlayerCharacter Instance = new();

    private PlayerCharacter()
    {
        /*
         * 20 is high
         * 0 is low
         * starting values around 2-4 depending on character creation
         */
        this.Health = 20;
        this.MaxHealth = 20;
        this.Strength = 3;
        this.Agility = 3;
        this.Charisma = 3;
    }

    public static PlayerCharacter GetPlayerCharacter()
    {
        return Instance;
    }

    public Dictionary<string, Tuple<int, int?>> GetAllPlayerStats()
    {
        var statsDict = new Dictionary<string, Tuple<int, int?>>
        {
            { "Health", new Tuple<int, int?>(this.Health, this.MaxHealth) },
            { "Strength", new Tuple<int, int?>(this.Strength, null) },
            { "Agility", new Tuple<int, int?>(this.Agility, null) },
            { "Charisma", new Tuple<int, int?>(this.Charisma, null) }
        };

        return statsDict;
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
            case CharacterStat.Agility:
                this.Health += val;
                break;
            case CharacterStat.Strength:
                this.Health += val;
                break;
            case CharacterStat.Charisma:
                this.Health += val;
                break;
        }
        Console.WriteLine(stat.ToNiceString() + " " + (val > 0 ? "increased" : "decreased") + " by " + val + "!");
    }
}