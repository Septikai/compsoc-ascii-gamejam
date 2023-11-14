namespace compsoc_ascii_gamejam.Characters.Player;

public enum ITEMS
{
    ROCK,
    STICK
}

public class Inventory
{
    // <ID, <Name, Description>>
    private static Dictionary<ITEMS, Tuple<String, String>> itemDescription =
        new Dictionary<ITEMS, Tuple<string, string>>()
        {
            {
                ITEMS.ROCK, new Tuple<string, string>("Rock", "hard and solid")
            },
            {
                ITEMS.STICK, new Tuple<string,string>("Stick", "Contains at least 2 ends")
            }
        };

    private Dictionary<ITEMS, uint> inventory = new Dictionary<ITEMS, uint>();

    public void addToInventory(ITEMS item)
    {
        if (inventory.ContainsKey(item))
        {
            inventory[item]++;
        }
        else
        {
            inventory.Add(item, 1);
        }
    }
    
    public void subtractFromInventory(ITEMS item)
    {
        if (inventory.ContainsKey(item))
        {
            if (inventory[item] > 1)
            {
                inventory[item]++;
            }
            else
            {
                inventory.Remove(item);
            }
        }
        else
        {
            Console.WriteLine("No such item found");
        }
    }
    
    public void checkInventory(ITEMS item)
    {
        if (inventory.TryGetValue(item, out var value))
        {
            Console.WriteLine($"Currently there are: {value.ToString()} {itemDescription[item].Item1}");
        }
        else
        {
            Console.WriteLine($"There are no {itemDescription[item].Item1} in the inventory");
        }
    }

    public void getDescription(ITEMS item)
    {
        if (inventory.TryGetValue(item, out var value))
        {
            Console.WriteLine($"{itemDescription[item].Item1} : {itemDescription[item].Item2}");
        }
        else
        {
            Console.WriteLine($"There are no {itemDescription[item].Item1} in the inventory");
        }
    }
}