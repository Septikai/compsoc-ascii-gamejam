using compsoc_ascii_gamejam.Characters.Player;
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
            RedRidingHood.GetInstance().Start();
            Console.Read();
        }
    }
}