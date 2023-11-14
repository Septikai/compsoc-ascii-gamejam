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
        statsDict.Add("Charisma0", new Tuple<int, int?>(this.Charisma, null));
        statsDict.Add("Charisma1", new Tuple<int, int?>(this.Charisma, null));
        statsDict.Add("Charisma2", new Tuple<int, int?>(this.Charisma, null));
        statsDict.Add("Charisma3", new Tuple<int, int?>(this.Charisma, null));
        statsDict.Add("Charisma4", new Tuple<int, int?>(this.Charisma, null));
        statsDict.Add("Charisma5", new Tuple<int, int?>(this.Charisma, null));
        statsDict.Add("Charisma6", new Tuple<int, int?>(this.Charisma, null));
        statsDict.Add("Charisma7", new Tuple<int, int?>(this.Charisma, null));
        statsDict.Add("Charisma8", new Tuple<int, int?>(this.Charisma, null));
        statsDict.Add("Charisma9", new Tuple<int, int?>(this.Charisma, null));
        statsDict.Add("Charisma10", new Tuple<int, int?>(this.Charisma, null));
        statsDict.Add("Charisma11", new Tuple<int, int?>(this.Charisma, null));
        statsDict.Add("Charisma12", new Tuple<int, int?>(this.Charisma, null));
        statsDict.Add("Charisma13", new Tuple<int, int?>(this.Charisma, null));
        statsDict.Add("Charisma14", new Tuple<int, int?>(this.Charisma, null));
        statsDict.Add("Charisma15", new Tuple<int, int?>(this.Charisma, null));
        statsDict.Add("Charisma16", new Tuple<int, int?>(this.Charisma, null));
        statsDict.Add("Charisma17", new Tuple<int, int?>(this.Charisma, null));
        statsDict.Add("Charisma18", new Tuple<int, int?>(this.Charisma, null));
        statsDict.Add("Charisma19", new Tuple<int, int?>(this.Charisma, null));
        statsDict.Add("Charisma20", new Tuple<int, int?>(this.Charisma, null));
        statsDict.Add("Charisma21", new Tuple<int, int?>(this.Charisma, null));
        statsDict.Add("Charisma22", new Tuple<int, int?>(this.Charisma, null));
        statsDict.Add("Charisma23", new Tuple<int, int?>(this.Charisma, null));
        statsDict.Add("Charisma24", new Tuple<int, int?>(this.Charisma, null));
        statsDict.Add("Charisma25", new Tuple<int, int?>(this.Charisma, null));
        statsDict.Add("Charisma26", new Tuple<int, int?>(this.Charisma, null));
        statsDict.Add("Charisma27", new Tuple<int, int?>(this.Charisma, null));
        statsDict.Add("Charisma28", new Tuple<int, int?>(this.Charisma, null));
        statsDict.Add("Charisma29", new Tuple<int, int?>(this.Charisma, null));
        statsDict.Add("Charisma30", new Tuple<int, int?>(this.Charisma, null));
        statsDict.Add("Charisma31", new Tuple<int, int?>(this.Charisma, null));
        statsDict.Add("Charisma32", new Tuple<int, int?>(this.Charisma, null));
        statsDict.Add("Charisma33", new Tuple<int, int?>(this.Charisma, null));
        statsDict.Add("Charisma34", new Tuple<int, int?>(this.Charisma, null));
        statsDict.Add("Charisma35", new Tuple<int, int?>(this.Charisma, null));

        return statsDict;
    }
}