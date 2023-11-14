namespace compsoc_ascii_gamejam.Characters.Player;

public enum Items
{
    Rock,
    Stick
}

public class Inventory
{
    // <ID, <Name, Description>>
    private static readonly Dictionary<Items, Tuple<String, String>> ItemDescription =
        new Dictionary<Items, Tuple<string, string>>()
        {
            {
                Items.Rock, new Tuple<string, string>("Rock", "hard and solid")
            },
            {
                Items.Stick, new Tuple<string, string>("Stick", "Contains at least 2 ends")
            }
        };

    private readonly Dictionary<Items, uint> _inventory = new Dictionary<Items, uint>();

    public void AddToInventory(Items item)
    {
        if (_inventory.ContainsKey(item))
        {
            _inventory[item]++;
        }
        else
        {
            _inventory.Add(item, 1);
        }
    }

    public void SubtractFromInventory(Items item)
    {
        if (_inventory.ContainsKey(item))
        {
            if (_inventory[item] > 1)
            {
                _inventory[item]--;
            }
            else
            {
                _inventory.Remove(item);
            }
        }
        else
        {
            Console.WriteLine("No such item found");
        }
    }

    public void CheckInventory(Items item)
    {
        if (_inventory.TryGetValue(item, out var value))
        {
            Console.WriteLine($"Currently there are: {value.ToString()} {ItemDescription[item].Item1}");
        }
        else
        {
            Console.WriteLine($"There are no {ItemDescription[item].Item1} in the inventory");
        }
    }

    public void GetDescription(Items item)
    {
        if (_inventory.TryGetValue(item, out var value))
        {
            Console.WriteLine($"{ItemDescription[item].Item1} : {ItemDescription[item].Item2}");
        }
        else
        {
            Console.WriteLine($"There are no {ItemDescription[item].Item1} in the inventory");
        }
    }
}