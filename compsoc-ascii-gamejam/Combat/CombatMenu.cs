using compsoc_ascii_gamejam.Characters;
using compsoc_ascii_gamejam.Characters.Player;
using compsoc_ascii_gamejam.ConsoleIO;

namespace compsoc_ascii_gamejam.Combat;

public class CombatMenu
{
    private readonly Dictionary<String, Action> _options = new()
    {
        { "attack", () => CombatManager.GetInstance().GetCombat().Attack() },
        { "defend", () => CombatManager.GetInstance().GetCombat().Defend() },
        { "inventory", () => CombatManager.GetInstance().GetCombat().Inventory() }
    };
    private int _activeOption = 0;
    private readonly Combat _currentCombat;
    private bool _hasBeenDisplayed = false;
    private int _dieValue = 0;
    private bool _showInventory = false;
    public readonly Queue<String> _eventQueue = new();
    
    public CombatMenu(Combat currentCombat)
    {
        this._currentCombat = currentCombat;
    }

    public void AwaitPlayerAction()
    {
        while (this._currentCombat.IsPlayerTurn())
        {
            var key = Console.ReadKey(true).Key;
            ProcessKeyPress(key);
            UpdateMenu();
        }
    }

    public void ToggleShowInventory()
    {
        this._activeOption = 0;
        this._showInventory = !this._showInventory;
    }

    public void UpdateMenu()
    {
        var h = Console.WindowHeight - 3;
        var gap = (h - 4) / 5;
        var w = Console.WindowWidth - 2;
        var wPadding = w / 5;

        var items = new List<String>();
        if (!this._showInventory)
        {
            List<String> initialItems = new() { "attack", "defend", "inventory" };
            foreach (var item in initialItems)
            {
                items.Add(item == initialItems[this._activeOption] ? item.ToUpper() : item.ToLower());
            }
        }
        else
        {
            var initialItems = Inventory.GetInventory().GetContents().Select(kv => 
                (kv.Key, kv.Key.GetStatType(), kv.Key.GetStatEffect(), kv.Value)).ToList();
            foreach (var item in initialItems)
            {
                items.Add(item.Key == initialItems[this._activeOption].Key ? 
                    item.Key.ToNiceString().ToUpper() + " (" + item.Value + ") - " + item.Item2.ToAbbreviation() + 
                    " +" + item.Item3 : 
                    item.Key.ToNiceString().ToLower() + " (" + item.Value + ") - " + item.Item2.ToAbbreviation() + 
                    " +" + item.Item3);
            }
        }
        List<String> dieFace = GetDieValue();

        if (this._hasBeenDisplayed)
        {
            var top = 3 + gap * 3;
            Console.SetCursorPosition(0, top);
        }
        
        Output.PrintBoxLine();
        if (!this._showInventory)
        {
            for (var i = 0; i < gap - 2; i++) Console.WriteLine("|" + new String(' ', w) + "|");
            Console.WriteLine("|" + "+-------+".PadLeft(wPadding * 4 + 7).PadRight(w) + "|");
        
            Console.WriteLine("|" + ("|" + dieFace[0] + "|").PadLeft(wPadding * 4 + 7).PadRight(w) + "|");
        
            Console.WriteLine("|" + (items[0].PadLeft(wPadding + 1) + 
                                     items[1].PadLeft(wPadding + 1) + 
                                     items[2].PadLeft(wPadding + 1) +
                                     ("|" + dieFace[1] + "|").PadLeft(wPadding + 4).PadRight(wPadding * 2)).PadRight(w) + "|");
        
            Console.WriteLine("|" + ("|" + dieFace[2] + "|").PadLeft(wPadding * 4 + 7).PadRight(w) + "|");
        
            Console.WriteLine("|" + "+-------+".PadLeft(wPadding * 4 + 7).PadRight(w) + "|");
        
            for (var i = 0; i < gap - 2; i++) Console.WriteLine("|" + new String(' ', w) + "|");
            Output.PrintBoxLine();
        }
        else
        {
            var prevItemLength = 0;
            var top = 3 + gap * 3;
            var newGap = 3 + (gap - 2) * 3 - Math.Ceiling((float) items.Count / 2) - 1;
            
            for (var i = 0; i < Math.Floor((float) newGap / 2); i++) Console.WriteLine("|" + new String(' ', w) + "|");
            Console.WriteLine("|" + "Inventory:".PadLeft(wPadding + 10).PadRight(w) + "|");
            foreach (var item in items.Select((line, i) => new { i, line }))
            {
                if (item.i % 2 != 0)
                {
                    Console.WriteLine(item.line.PadLeft(wPadding + item.line.Length).PadRight(w - prevItemLength) + "|");
                    prevItemLength = 0;
                }
                else
                {
                    for (var i = 0; i < (gap - 2) / 5; i++) Console.WriteLine("|" + new String(' ', w) + "|");
                    Console.Write("|" + item.line.PadLeft(wPadding + item.line.Length).PadRight(wPadding * 2 + item.line.Length));
                    prevItemLength = item.line.PadLeft(wPadding + item.line.Length)
                        .PadRight(wPadding * 2 + item.line.Length).Length;
                }
            }
            if (prevItemLength > 0) Console.WriteLine(" ".PadRight(w - prevItemLength) + "|");
            if (items.Count == 0) Console.WriteLine("|" + " ".PadRight(w) + "|");
            for (var i = 0; i < Math.Ceiling((float) newGap / 2); i++) Console.WriteLine("|" + new String(' ', w) + "|");
            Output.PrintBoxLine();
        }
        if (!this._hasBeenDisplayed) this._hasBeenDisplayed = true;
    }

    private List<String> GetDieValue()
    {
        switch (this._dieValue)
        {
            case 1:
                return new List<String>()
                {
                    "       ", "   o   ", "       "
                };
            case 2:
                return new List<String>()
                {
                    "     o ", "       ", " o     "
                };
            case 3:
                return new List<String>()
                {
                    "     o ", "   o   ", " o     "
                };
            case 4:
                return new List<String>()
                {
                    " o   o ", "       ", " o   o "
                };
            case 5:
                return new List<String>()
                {
                    " o   o ", "   o   ", " o   o "
                };
            case 6:
                return new List<String>()
                {
                    " o   o ", " o   o ", " o   o "
                };
            default:
                return new List<String>()
                {
                    "       ", "       ", "       "
                };
        }
    }

    private void ProcessKeyPress(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.Escape:
                if (this._showInventory) this.ToggleShowInventory();
                break;
            case ConsoleKey.Backspace:
                if (this._showInventory) this.ToggleShowInventory();
                break;
            case ConsoleKey.UpArrow:
                if (!this._showInventory) this._activeOption -= this._activeOption > 0 ? 1 : 0;
                else if (this._activeOption - 2 >= 0) this._activeOption -= 2;
                else this._activeOption -= this._activeOption > 0 ? 1 : 0;
                break;
            case ConsoleKey.DownArrow:
                if (!this._showInventory) this._activeOption += this._activeOption < this._options.Count - 1 ? 1 : 0;
                else if (this._activeOption + 2 <= this._options.Count - 1) this._activeOption += 2;
                else this._activeOption += this._activeOption < this._options.Count - 1 ? 1 : 0;
                break;
            case ConsoleKey.LeftArrow:
                this._activeOption -= this._activeOption > 0 ? 1 : 0;
                break;
            case ConsoleKey.RightArrow:
                this._activeOption += this._activeOption < this._options.Count - 1 ? 1 : 0;
                break;
            case ConsoleKey.Enter:
                ExecuteActiveOption();
                break;
        }
    }

    private void ExecuteActiveOption()
    {
        if (!this._showInventory) this._options.Values.ToList()[this._activeOption].Invoke();
        else _currentCombat.UseItem(Inventory.GetInventory().GetContents().Keys
            .ToList()[this._activeOption]);
    }

    public void SetDieValue(int result)
    {
        this._dieValue = result;
    }

    public void ResetActiveOption()
    {
        this._activeOption = 0;
    }

    public void Victory()
    {
        Console.Clear();
        PlayerCharacter.GetPlayerCharacter().ModifyStat(CharacterStat.Health ,3);
        Console.WriteLine("Restored 3 HP");
        CombatManager.GetInstance().EndCombat();
    }

    public void Defeat()
    {
        Console.Clear();
        Console.WriteLine("You Lost :(");
        //CombatManager.GetInstance().EndCombat();
    }
    
    public void PushToEventQueue(String evnt)
    {
        this._eventQueue.Enqueue(evnt);
        if (this._eventQueue.Count > 2) this._eventQueue.Dequeue();
        CombatManager.GetInstance().UpdateCombat();
        CombatManager.GetInstance().GetCombatMenu().UpdateMenu();
    }
}