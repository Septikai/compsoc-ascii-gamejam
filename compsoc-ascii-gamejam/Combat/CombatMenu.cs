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
    private readonly Queue<String> _eventQueue = new();
    
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
                    item.Key.ToNiceString().ToUpper() + "(" + item.Item3 + ") - " + item.Item2.ToAbbreviation() + 
                    " +" + item.Item2 : 
                    item.Key.ToNiceString().ToLower() + "(" + item.Item3 + ") - " + item.Item2.ToAbbreviation() + 
                    " +" + item.Item2);
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
            // foreach (var item in items.Select((line, i) => new { i, line }))
            // {
            //     for (var i = 0; i < (gap - 2) / 5; i++) Console.WriteLine("|" + new String(' ', w) + "|");
            //     Console.WriteLine("|" + );
                
                
                
                // var toAdd = item.line;
                // var toAddQueue = new List<string>();
                // var currentLine = 0;
                // if (item.line.Length > w)
                // {
                //     while (item.line.Length > w)
                //     {
                //         toAddQueue.Add("");
                //         var splitString = toAdd.Split(' ');
                //         var currentIndex = 0;
                //         while (!IsStringOutOfBounds(toAddQueue[currentLine].Length + splitString[currentIndex]))
                //         {
                //             currentIndex++;
                //             toAddQueue[currentLine] += splitString[currentIndex];
                //         }
                //
                //         toAdd = String.Join(" ", splitString.Except(toAddQueue[currentLine].Split(' ')));
                //         currentLine++;
                //     }
                // }
                // else
                // {
                //     toAddQueue.Add("| " + toAdd);
                // }
                //
                //
                // foreach (var queueItem in toAddQueue.Select((line, i) => new { i, line }))
                // {
                //     invString += queueItem.line;
                //     invString += new String(' ',
                //                      Console.WindowWidth - invString.Split("\n").Last().Length - 1) + "|" +
                //                  (item.i < invDict.Count - 1 ? "\n" : "");
                // }
            // }
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
                    "    o ", "       ", " o     "
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
                // if (_canQuit) this._isQuitting = true;
                break;
            case ConsoleKey.UpArrow:
                this._activeOption -= this._activeOption > 0 ? 1 : 0;
                break;
            case ConsoleKey.DownArrow:
                this._activeOption += this._activeOption < this._options.Count - 1 ? 1 : 0;
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
        this._currentCombat.PassTurn();
    }

    public void SetDieValue(int result)
    {
        this._dieValue = result;
    }

    public void Victory()
    {
        
        CombatManager.GetInstance().EndCombat();
    }

    public void Defeat()
    {
        
        CombatManager.GetInstance().EndCombat();
    }
    
    public void PushToEventQueue(String evnt)
    {
        this._eventQueue.Enqueue(evnt);
    }
}