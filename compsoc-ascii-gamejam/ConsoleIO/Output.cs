using compsoc_ascii_gamejam.Characters.Player;

namespace compsoc_ascii_gamejam.ConsoleIO;

public class Output
{
    public static void PrintStats()
    {
        var player = PlayerCharacter.GetPlayerCharacter();
        var statsDict = player.GetAllPlayerStats();

        var statsString = "| ";
        var statsStringLines = 1;
        var newLine = false;
        var statLength = (statsDict.Aggregate("", (max, current) => 
            max.Length > current.Key.Length ? max : current.Key).Length) + 7;
        foreach (var item in statsDict.Select((dictItem, i) => new { i, dictItem }))
        {
            if (item.dictItem.Value.Item2 is null)
            {
                if (!IsStringOutOfBounds(statsString.Split("\n")[statsStringLines - 1],  
                        (item.dictItem.Key + ": " + 
                         item.dictItem.Value.Item1).PadRight(statLength, ' ') + "|"))
                {
                    if (item.i != 0 && !newLine)statsString += new String(' ', statLength - (item.dictItem.Key +
                        ": " + item.dictItem.Value.Item1).Length);
                    newLine = false;
                    statsString += item.dictItem.Key + ": " + item.dictItem.Value.Item1;
                }
                else
                {
                    statsString += new String(' ', Console.WindowWidth - 
                                                   statsString.Split("\n")[statsStringLines - 1].Length - 1) + 
                                   "|\n| ";
                    statsStringLines++;
                    newLine = true;
                }
            }
            else
            {
                if (!IsStringOutOfBounds(statsString.Split("\n")[statsStringLines - 1], 
                        (item.dictItem.Key + ": " + item.dictItem.Value.Item1 + "/" + 
                        item.dictItem.Value.Item2).PadRight(statLength, ' ') + "|"))
                {
                    if (item.i != 0 && !newLine) statsString += new String(' ', statLength - (item.dictItem.Key 
                        + ": " + item.dictItem.Value.Item1 + "/" + item.dictItem.Value.Item2).Length);
                    newLine = false;
                    statsString += item.dictItem.Key + ": " + item.dictItem.Value.Item1 + "/" + item.dictItem.Value.Item2;
                }
                else
                {
                    statsString += new String(' ', Console.WindowWidth - 
                                       statsString.Split("\n")[statsStringLines - 1].Length - 1) + "|\n| ";
                    statsStringLines++;
                    newLine = true;
                }
            }
            if (item.i == statsDict.Count - 1)
            {
                statsString += new String(' ', 
                    Console.WindowWidth - statsString.Split("\n")[statsStringLines - 1].Length - 1) + "|";
            }
        }

        var output = "| Player Stats:";
        output = output + new String(' ', Console.WindowWidth - output.Length - 1) + "|\n" + statsString;
        PrintBoxLine();
        Console.WriteLine(output);
        PrintBoxLine();
    }

    private static bool IsStringOutOfBounds(string originString, string toAdd)
    {
        return originString.Length + toAdd.Length > Console.WindowWidth;
    }

    private static void PrintBoxLine()
    {
        Console.WriteLine("+" + new String('-', Console.WindowWidth - 2) + "+");
    }
}