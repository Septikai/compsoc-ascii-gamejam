namespace compsoc_ascii_gamejam.Characters.Player;

public class Inventory
{
    private static readonly Inventory Instance = new();

    private readonly Dictionary<InventoryItem, uint> _inventoryContents = new();

    private Inventory()
    {
        
    }

    public static Inventory GetInventory()
    {
        return Instance;
    }

    public Dictionary<InventoryItem, uint> GetContents()
    {
        return this._inventoryContents;
    }

    public void AddToInventory(InventoryItem item, uint amount, bool silent = false)
    {
        if (_inventoryContents.TryGetValue(item, out var value))
        {
            _inventoryContents[item] = value + amount;
        }
        else
        {
            _inventoryContents.Add(item, amount);
        }
        if (!silent) Console.WriteLine("Added " + amount + " " + item.ToNiceString() + " to your inventory!");
    }

    public void RemoveFromInventory(InventoryItem item, uint amount, bool silent = false)
    {
        if (_inventoryContents.TryGetValue(item, out var value))
        {
            if (value > 1)
            {
                _inventoryContents[item] = amount <= value ? value - amount : 0;
            }
            else
            {
                _inventoryContents.Remove(item);
            }
            if (!silent) Console.WriteLine("Removed " + (amount <= value ? amount : value) + " " + item.ToNiceString() +
                                           " from your inventory!");
        }
        else
        {
            Console.WriteLine("You had no " + item.ToNiceString() + " to remove!");
        }
    }
}