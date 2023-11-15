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
    private bool _menuActive = false;
    private Combat _currentCombat;
    private bool _hasBeenDisplayed = false;
    private int _dieValue = 0;
    
    public CombatMenu(Combat currentCombat)
    {
        this._currentCombat = currentCombat;
    }

    public void AwaitPlayerAction()
    {
        ConsoleKey key;
        while (this._currentCombat.IsPlayerTurn())
        {
            UpdateMenu();
            key = Console.ReadKey(true).Key;
            ProcessKeyPress(key);
        }
    }

    private void UpdateMenu()
    {
        var h = Console.WindowHeight - 3;
        var gap = (h - 4) / 5;
        var w = Console.WindowWidth - 2;
        var wPadding = w / 5;

        var initialItems = new List<String>() { "attack", "defend", "inventory" };
        var items = new List<String>();
        foreach (var item in initialItems)
        {
            items.Add(item == initialItems[this._activeOption] ? item.ToUpper() : item.ToLower());
        }
        List<String> dieFace = GetDieValue();

        if (this._hasBeenDisplayed)
        {
            var top = 3 + gap * 3;
            Console.SetCursorPosition(0, top);
        }
        
        Output.PrintBoxLine();
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
        if (!this._hasBeenDisplayed) this._hasBeenDisplayed = true;
    }

    private List<String> GetDieValue()
    {
        switch (this._dieValue)
        {
            case 1:
                return new List<String>()
                {
                    "       ", "   .   ", "       "
                };
            case 2:
                return new List<String>()
                {
                    "     . ", "       ", " .     "
                };
            case 3:
                return new List<String>()
                {
                    "     . ", "   .   ", " .     "
                };
            case 4:
                return new List<String>()
                {
                    " .   . ", "       ", " .   . "
                };
            case 5:
                return new List<String>()
                {
                    " .   . ", "   .   ", " .   . "
                };
            case 6:
                return new List<String>()
                {
                    " .   . ", " .   . ", " .   . "
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
        Console.Clear();
        this._options.Values.ToList()[this._activeOption].Invoke();
        this._currentCombat.PassTurn();
    }
}