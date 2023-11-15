using System.ComponentModel;
using System.Reflection;

namespace compsoc_ascii_gamejam.Characters.Player;

// If you add an item and its name wouldn't look nice in text (eg "RustedBlade") then remember
// to also add it to the ToNiceString method at the bottom of this file
public enum InventoryItem
{
    [Description("Hard and solid")]
    [StatEffect(CharacterStat.Strength, 1)]
    Rock,
    
    [Description("Contains at least 2 ends")]
    [StatEffect(CharacterStat.Strength, 1)]
    Stick,
    
    [Description("Looks pretty")]
    [StatEffect(CharacterStat.Health, 1)]
    Flowers,
    
    [Description("Rusted but still pointy")]
    [StatEffect(CharacterStat.Strength, 2)]
    RustedBlade,
    
    [Description("a long vine with very sharp thorns")]
    [StatEffect(CharacterStat.Strength, 2)]
    ThornyVine,

    [Description("It's covered in chocolate frosting")]
    [StatEffect(CharacterStat.Health, 2)]
    CakeSlice,

    [Description("soft to the touch")]
    [StatEffect(CharacterStat.Charisma, 1)]

    Fur,

    [Description("a vine of berries you grabbed from a bush")]
    [StatEffect(CharacterStat.Health, 3)]

    Berries
}

class StatEffectAttribute(CharacterStat stat, int val) : Attribute
{
    public CharacterStat Stat { get; private set; } = stat;
    public int Val { get; private set; } = val;
}


public static class InventoryItemExtension
{
    public static String GetDescription(this InventoryItem source)
    {
        FieldInfo fi = source.GetType().GetField(source.ToString());

        DescriptionAttribute[] attributes = (DescriptionAttribute[]) fi.GetCustomAttributes(
            typeof(DescriptionAttribute), false);

        return attributes is { Length: > 0 } ? attributes[0].Description : source.ToString();
    }
    
    public static int GetStatEffect(this InventoryItem source)
    {
        FieldInfo fi = source.GetType().GetField(source.ToString());

        StatEffectAttribute[] attributes = (StatEffectAttribute[]) fi.GetCustomAttributes(
            typeof(StatEffectAttribute), false);

        return attributes is { Length: > 0 } ? attributes[0].Val : 0;
    }
    
    public static String ToNiceString(this InventoryItem item)
    {
        switch (item)
        {
            case InventoryItem.RustedBlade:
                return "Rusted Blade";
            case InventoryItem.ThornyVine:
                return "Thorny Vine";
            default:
                return item.ToString();
        }
    }
}