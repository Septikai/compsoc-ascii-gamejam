using System.ComponentModel;

namespace compsoc_ascii_gamejam.Characters;

public enum CharacterStat
{
    Health,
    [Description("Max Health")]
    MaxHealth,
    Strength,
    Agility,
    Charisma
}