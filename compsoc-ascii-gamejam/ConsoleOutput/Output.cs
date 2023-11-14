using compsoc_ascii_gamejam.Characters.Player;

namespace compsoc_ascii_gamejam.ConsoleOutput;

public class Output
{
    public static void PrintStats()
    {
        var player = PlayerCharacter.GetPlayerCharacter();
        var statsDict = player.GetAllPlayerStats();

        var statsString = "| ";
        var statsStringLines = 1;
        
        foreach (var item in statsDict.Select((dictItem, i) => new { i, dictItem }))
        {
            if (item.dictItem.Value.Item2 is null)
            {
                statsString += item.dictItem.Key + ": " + item.dictItem.Value.Item1;
            }
            else
            {
                statsString += item.dictItem.Key + ": " + item.dictItem.Value.Item1 + "/" + item.dictItem.Value.Item2;
            }

            if (item.i != 0 && (item.i % 4 == 0 && item.i != statsDict.Count - 1))
            {
                statsString += "\n";
                statsStringLines++;
            }
            else if (item.i == statsDict.Count - 1) statsString += " |";
            else statsString += " | ";
        }

        var output = "| Player Stats:";
        
        output = output + new String(' ', (statsStringLines > 1 ? 
            statsString.Split("\n")[0].Length : statsString.Length) - output.Length - 1) + "|\n" + statsString;
        output = "+" + new String('-', (statsStringLines > 1 ? 
            statsString.Split("\n")[0].Length : statsString.Length) - 2) + "+\n" + output + "\n";
        output = output + "+" + new String('-', (statsStringLines > 1 ? 
            statsString.Split("\n")[0].Length : statsString.Length) - 2) + "+\n";
        
        Console.WriteLine(output);

    }
}