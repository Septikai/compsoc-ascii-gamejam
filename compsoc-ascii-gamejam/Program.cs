using compsoc_ascii_gamejam.Characters.NonPlayerCharacter;
using compsoc_ascii_gamejam.Characters.Player;
using compsoc_ascii_gamejam.Combat;
using compsoc_ascii_gamejam.ConsoleIO;
using compsoc_ascii_gamejam.Story;

namespace compsoc_ascii_gamejam
{
    static class Program
    {
        static void Main()
        {
            Output.PrintStats();
            Inventory.GetInventory().AddToInventory(InventoryItem.Stick, 2);
            Inventory.GetInventory().AddToInventory(InventoryItem.Rock, 1);
            Output.PrintInv();
            
            // var storyManager = new StoryManager("Story\\testStory.txt");
            var menu = new Menu(false, new Dictionary<string, Action>()
            {
                { "start", () => RedRidingHood.GetInstance().Start() },
                { "fight", () => CombatManager.GetInstance().InitiateCombat(
                    new NonPlayerCharacter(6, 6, 3, 3)) },
                { "load", () => Console.WriteLine("Loaded") },
                { "quit", () => Environment.Exit(1) }
            });
            menu.DisplayMenu();
            Console.Read();
        }
    }
}