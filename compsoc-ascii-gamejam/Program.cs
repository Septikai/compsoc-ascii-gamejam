using compsoc_ascii_gamejam.ConsoleIO;
using compsoc_ascii_gamejam.Story;

namespace compsoc_ascii_gamejam
{
    static class Program
    {
        static void Main()
        {
            StoryManager storyManager;
            var menu = new Menu(false, new Dictionary<string, Action>()
            {
                { "start", () => storyManager = new StoryManager("Story\\testStory.txt") },
                { "quit", () => Environment.Exit(1) }
            });
            menu.DisplayMenu();
            Console.Read();
        }
    }
}