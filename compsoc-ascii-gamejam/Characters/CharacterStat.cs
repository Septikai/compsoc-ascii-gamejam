namespace compsoc_ascii_gamejam.Characters;

public enum CharacterStat
{
    Health,
    MaxHealth,
    Strength,
    Agility,
    Charisma,
    Defence
}

public static class CharacterStatExtensions
{
    public static String ToNiceString(this CharacterStat stat)
    {
        switch (stat)
        {
            case CharacterStat.MaxHealth:
                return "Max Health";
            default:
                return stat.ToString();
        }
    }
    
    public static String ToAbbreviation(this CharacterStat stat)
    {
        switch (stat)
        {
            case CharacterStat.MaxHealth:
                return "MXHP";
            case CharacterStat.Health:
                return "HP";
            case CharacterStat.Strength:
                return "STR";
            case CharacterStat.Agility:
                return "AGL";
            case CharacterStat.Charisma:
                return "CHR";
            case CharacterStat.Defence:
                return "DEF";
            default:
                return stat.ToString();
        }
    }
}