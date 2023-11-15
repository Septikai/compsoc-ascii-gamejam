using System.ComponentModel;
using System.Reflection;

namespace compsoc_ascii_gamejam.Characters.Player;

public enum InventoryItem
{
    [Description("Hard and solid")]
    [StrengthEffect(1)]
    Rock,
    [Description("Contains at least 2 ends")]
    [StrengthEffect(1)]
    Stick,
    [Description("Looks pretty")]
    Flowers,
    [Description("Rusted but still pointy")]
    [StrengthEffect(2)]
    RustedBlade,

    [Description("a long vine with very sharp thorns")]
    [StrengthEffect(2)]
    ThornyVine
}

class StrengthEffectAttribute : Attribute
{
    public int val { get; private set; }

    public StrengthEffectAttribute(int val)
    {
        this.val = val;
    }
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
    
    public static int GetStrengthEffect(this InventoryItem source)
    {
        FieldInfo fi = source.GetType().GetField(source.ToString());

        StrengthEffectAttribute[] attributes = (StrengthEffectAttribute[]) fi.GetCustomAttributes(
            typeof(StrengthEffectAttribute), false);

        return attributes is { Length: > 0 } ? attributes[0].val : 0;
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