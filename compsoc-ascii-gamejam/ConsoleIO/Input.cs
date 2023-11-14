namespace compsoc_ascii_gamejam.ConsoleIO;

public enum PlayerCommands
{
    None,
    Stats,
    Inventory,
    Pause,
    Save,
    Quit
}



public class Input
{
    private static readonly Dictionary<PlayerCommands, List<String>> Commands = GetAllPlayerCommands();

    private static Dictionary<PlayerCommands, List<String>> GetAllPlayerCommands()
    {
        return new Dictionary<PlayerCommands, List<String>>()
        {
            { PlayerCommands.Stats, new List<String>() {"stats", "stat", "statistic", "statistics"} },
            { PlayerCommands.Inventory, new List<String>() {"inv", "inventory"} },
            { PlayerCommands.Pause, new List<String>() {"pause"} },
            { PlayerCommands.Save, new List<String>() {"save"} },
            { PlayerCommands.Quit, new List<String>() {"quit"} }
        };
    }
    
    public static String GetUserResponse(List<String> validResponses)
    {
        String? input;
        do
        {
            Console.Write(">>> ");
            input = Console.ReadLine();
            if (input is null) throw new NullReferenceException();
            var command = 
                Commands.FirstOrDefault(kv => kv.Value.Contains(input)).Key;
            if (command != PlayerCommands.None) HandleCommand(command);
        } while (!validResponses.Contains(input));

        return input;
    }

    private static void HandleCommand(PlayerCommands command)
    {
        switch (command)
        {
            case PlayerCommands.Stats:
                break;
            case PlayerCommands.Inventory:
                break;
            case PlayerCommands.Pause:
                break;
            case PlayerCommands.Save:
                break;
            case PlayerCommands.Quit:
                break;
        }
    }
}