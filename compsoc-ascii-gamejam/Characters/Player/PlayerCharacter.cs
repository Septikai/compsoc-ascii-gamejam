namespace compsoc_ascii_gamejam.Characters.Player;

public class PlayerCharacter : Character
{
    private static readonly PlayerCharacter Instance = new PlayerCharacter();

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
        Dictionary<string, Tuple<int, int?>> statsDict = new Dictionary<string, Tuple<int, int?>>();
        statsDict.Add("Health", new Tuple<int, int?>(this.Health, this.MaxHealth));
        statsDict.Add("Strength", new Tuple<int, int?>(this.Strength, null));
        statsDict.Add("Agility", new Tuple<int, int?>(this.Agility, null));
        statsDict.Add("Charisma", new Tuple<int, int?>(this.Charisma, null));

        return statsDict;
    }
}