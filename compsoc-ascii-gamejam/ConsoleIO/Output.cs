using compsoc_ascii_gamejam.Characters.Player;

namespace compsoc_ascii_gamejam.ConsoleIO;

public static class Output
{
    public static void PrintStats()
    {
        var player = PlayerCharacter.GetPlayerCharacter();
        var statsDict = player.GetAllPlayerStats();

        var statsString = "| ";
        var newLine = false;
        var statLength = (statsDict.Aggregate("", (max, current) => 
            max.Length > current.Key.Length ? max : current.Key).Length) + 7;
        foreach (var item in statsDict.Select((dictItem, i) => new { i, dictItem }))
        {
            if (item.dictItem.Value.Item2 is null)
            {
                if (!IsStringOutOfBounds(statsString.Split("\n").Last() +
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
                                                   statsString.Split("\n").Last().Length - 1) + 
                                   "|\n| ";
                    newLine = true;
                }
            }
            else
            {
                if (!IsStringOutOfBounds(statsString.Split("\n").Last() +
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
                                       statsString.Split("\n").Last().Length - 1) + "|\n| ";
                    newLine = true;
                }
            }
            if (item.i == statsDict.Count - 1)
            {
                statsString += new String(' ', 
                    Console.WindowWidth - statsString.Split("\n").Last().Length - 1) + "|";
            }
        }

        var output = "| Player Stats:";
        output = output + new String(' ', Console.WindowWidth - output.Length - 1) + "|\n" + statsString;
        PrintBoxLine();
        Console.WriteLine(output);
        PrintBoxLine();
    }

    private static bool IsStringOutOfBounds(string toCheck)
    {
        return toCheck.Length > Console.WindowWidth;
    }

    private static void PrintBoxLine()
    {
        Console.WriteLine("+" + new String('-', Console.WindowWidth - 2) + "+");
    }
    
    public static void PrintInv()
    {
        var invDict = Inventory.GetInventory().GetContents();

        var invString = "";
        foreach (var item in invDict.Select((dictItem, i) => new { i, dictItem }))
        {
            var toAdd = item.dictItem.Key + " (" + item.dictItem.Value + "): " + 
                        item.dictItem.Key.GetDescription();
            var toAddQueue = new List<string>();
            var currentLine = 0;
            if (IsStringOutOfBounds("| " + toAdd + " |"))
            {
                while (IsStringOutOfBounds("| " + toAdd + " |"))
                {
                    toAddQueue.Add("");
                    var splitString = toAdd.Split(' ');
                    var currentIndex = 0;
                    while (!IsStringOutOfBounds(toAddQueue[currentLine].Length + splitString[currentIndex]))
                    {
                        currentIndex++;
                        toAddQueue[currentLine] += splitString[currentIndex];
                    }

                    toAdd = String.Join(" ", splitString.Except(toAddQueue[currentLine].Split(' ')));
                    currentLine++;
                }
            }
            else
            {
                toAddQueue.Add("| " + toAdd);
            }
            

            foreach (var queueItem in toAddQueue.Select((line, i) => new { i, line }))
            {
                invString += queueItem.line;
                invString += new String(' ',
                    Console.WindowWidth - invString.Split("\n").Last().Length - 1) + "|" + 
                             (item.i < invDict.Count - 1 ? "\n" : "");
            }
        }

        var output = "| Inventory:";
        output = output + new String(' ', Console.WindowWidth - output.Length - 1) + "|\n" + invString;
        PrintBoxLine();
        Console.WriteLine(output);
        PrintBoxLine();
    }
}