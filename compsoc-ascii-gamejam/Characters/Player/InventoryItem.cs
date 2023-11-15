using System.ComponentModel;
using System.Reflection;

namespace compsoc_ascii_gamejam.Characters.Player;

public enum InventoryItem
{
    [Description("Hard and solid")]
    Rock,
    [Description("Contains at least 2 ends")]
    Stick,
    [Description("Looks pretty")]
    Flowers,
    [Description("Rusted but still pointy")]
    RustedBlade
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
    
    public static String ToNiceString(this InventoryItem item)
    {
        switch (item)
        {
            case InventoryItem.RustedBlade:
                return "Rusted Blade";
            default:
                return item.ToString();
        }
    }
}