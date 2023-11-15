namespace compsoc_ascii_gamejam.ConsoleIO;

public class Menu
{
    private readonly bool _canQuit;
    private bool _isQuitting = false;
    private readonly Dictionary<String, Action> _options;
    private int _activeOption = 0;
    private bool _menuActive = false;
    
    public Menu(bool canQuit, Dictionary<String, Action> options)
    {
        this._canQuit = canQuit;
        this._options = options;
    }

    public void DisplayMenu()
    {
        while (!this._isQuitting)
        {
            UpdateMenu();
            var key = Console.ReadKey(true).Key;
            ProcessKeyPress(key);
        }
    }

    private void UpdateMenu()
    {
        Console.Clear();
        var h = Console.WindowHeight - 3;
        if (this._options.Count < h)
        {
            if (!this._menuActive) this._menuActive = true;
            var gap = (h - this._options.Count) / (this._options.Count + 1);
            var w = Console.WindowWidth;
            var wPadding = this._options.Select(kv => 
                (w - kv.Key.Length) / 2).ToList();
            Output.PrintBoxLine();
            foreach (var item in this._options.Select((option, i) => new { i, option }))
            {
                for (var i = 0; i < gap; i++) Console.WriteLine("|" + new String(' ', w - 2) + "|");
                if (item.i != this._activeOption)
                {
                    Console.WriteLine("|" + item.option.Key.PadLeft(wPadding[item.i] + item.option.Key.Length - 1).PadRight(w - 2) + "|");
                }
                else
                {
                    Console.WriteLine("|" + item.option.Key.ToUpper().PadLeft(wPadding[item.i] + item.option.Key.Length - 1).PadRight(w - 2) + "|");
                }
            }
            for (var i = 0; i < gap; i++) Console.WriteLine("|" + new String(' ', w - 2) + "|");
            Output.PrintBoxLine();
        }
        else
        {
            Console.WriteLine("PLEASE ENLARGE YOUR CONSOLE THEN PRESS ENTER");
        }
    }

    private void ProcessKeyPress(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.Escape:
                if (_canQuit) this._isQuitting = true;
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
                if (this._menuActive) ExecuteActiveOption();
                break;
        }
    }

    private void ExecuteActiveOption()
    {
        Console.Clear();
        this._options.Values.ToList()[this._activeOption].Invoke();
        this._isQuitting = true;
    }
}