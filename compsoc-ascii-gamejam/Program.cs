using compsoc_ascii_gamejam.ConsoleIO;
using compsoc_ascii_gamejam.Stories;

namespace compsoc_ascii_gamejam
{
    static class Program
    {
        static void Main()
        {
            Output.PrintStats();
            RedRidingHood.GetInstance().Start();
            Console.Read();
        }
    }
}