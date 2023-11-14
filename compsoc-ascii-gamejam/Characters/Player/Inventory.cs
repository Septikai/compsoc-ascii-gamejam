namespace compsoc_ascii_gamejam.Characters.Player;

public enum Items
{
    Rock,
    Stick
}

public class Inventory
{
    // <ID, <Name, Description>>
    private static readonly Dictionary<Items, Tuple<string, string>> ItemDescription =
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
        if (_inventory.TryGetValue(item, out var value))
        {
            _inventory[item] = ++value;
        }
        else
        {
            _inventory.Add(item, 1);
        }
    }

    public void SubtractFromInventory(Items item)
    {
        if (_inventory.TryGetValue(item, out var value))
        {
            if (value > 1)
            {
                _inventory[item] = --value;
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
        Console.WriteLine(_inventory.TryGetValue(item, out var value)
            ? $"Currently there are: {value.ToString()} {ItemDescription[item].Item1}"
            : $"There are no {ItemDescription[item].Item1} in the inventory");
    }

    public void GetDescription(Items item)
    {
        Console.WriteLine(_inventory.TryGetValue(item, out var value)
            ? $"{ItemDescription[item].Item1} : {ItemDescription[item].Item2}"
            : $"There are no {ItemDescription[item].Item1} in the inventory");
    }
}