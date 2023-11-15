using compsoc_ascii_gamejam.Characters.NonPlayerCharacter;
using compsoc_ascii_gamejam.Characters.Player;
using compsoc_ascii_gamejam.ConsoleIO;

namespace compsoc_ascii_gamejam.Combat;

public class CombatManager
{
    private static readonly CombatManager Instance = new();
    
    private Combat _currentCombat;
    private CombatMenu _combatMenu;
    private bool _combatOver = false;

    private CombatManager()
    {
        
    }

    public static CombatManager GetInstance()
    {
        return Instance;
    }

    public Combat GetCombat()
    {
        return this._currentCombat;
    }

    public CombatMenu GetCombatMenu()
    {
        return this._combatMenu;
    }

    public void InitiateCombat(NonPlayerCharacter enemy)
    {
        this._currentCombat = new Combat(enemy);
        this._combatMenu = new CombatMenu(this._currentCombat);

       this.DisplayCombat();
    }

    private void DisplayCombat()
    {
        while (!this._combatOver)
        {
            var ok = UpdateCombat();
            if (!ok) continue;
            this._currentCombat.AwaitEndOfTurn();
        }
    }

    public void EndCombat()
    {
        this._combatOver = true;
    }

    public bool UpdateCombat()
    {
        Console.Clear();
        var h = Console.WindowHeight - 3;
        var gap = (h - 4) / 5;
        if (h > 4)
        {
            var w = Console.WindowWidth - 2;
            var wPadding = new List<int>()
            {
                (w - ("Strength: " + PlayerCharacter.GetPlayerCharacter().GetStrength() + "Opponent Strength: " +
                          this._currentCombat.GetEnemy().GetStrength()).Length) / 3,
                (w - ("Health: " + PlayerCharacter.GetPlayerCharacter().GetFormattedHealth() + "Opponent Health: " +
                          this._currentCombat.GetEnemy().GetFormattedHealth()).Length) / 3
            };
            var combatInfoLines = new List<Tuple<String, String>>()
            {
                new("Strength: " + PlayerCharacter.GetPlayerCharacter().GetStrength(), "Opponent Strength: " + 
                    this._currentCombat.GetEnemy().GetStrength()),
                new("Health: " + PlayerCharacter.GetPlayerCharacter().GetFormattedHealth(), "Opponent Health: " + 
                this._currentCombat.GetEnemy().GetFormattedHealth())
            };
            Output.PrintBoxLine();
            foreach (var item in combatInfoLines.Select((line, i) => new { i, line }))
            {
                for (var i = 0; i < gap; i++) Console.WriteLine("|" + new String(' ', w) + "|");
                Console.WriteLine("|" + item.line.Item1.PadLeft(wPadding[item.i] + item.line.Item1.Length) +
                    new String(' ', w - (item.line.Item1.PadLeft(wPadding[item.i] + item.line.Item1.Length).Length 
                                     + item.line.Item2.PadRight(wPadding[item.i] + item.line.Item2.Length,
                                         ' ').Length)) + item.line.Item2.PadRight(wPadding[item.i] 
                        + item.line.Item2.Length, ' ') + "|");
            }
            for (var i = 2; i < gap; i++) Console.WriteLine("|" + new String(' ', w) + "|");
            for (var i = this._combatMenu._eventQueue.Count; i < 2; i++) Console.WriteLine("|" + new String(' ', w) + "|");
            var index = 0;
            foreach (var str in this._combatMenu._eventQueue)
            {
                Console.WriteLine("| " + this._combatMenu._eventQueue.ElementAt(index++).PadRight(w-1) + "|");
            }
            return true;
        }
        else
        {
            Console.WriteLine("PLEASE ENLARGE YOUR CONSOLE THEN PRESS ENTER");
            return false;
        }
    }
}