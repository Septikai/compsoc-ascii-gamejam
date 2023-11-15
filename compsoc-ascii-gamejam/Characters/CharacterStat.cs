namespace compsoc_ascii_gamejam.Characters;

public enum CharacterStat
{
    Health,
    MaxHealth,
    Strength,
    Agility,
    Charisma
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
}