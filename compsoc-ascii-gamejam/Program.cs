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
                {
                    "start", () =>
                    {
                        storyManager = new StoryManager("Story/StoryFiles/RedRidingHood.story");
                        while (true)
                        {
                            Console.WriteLine(storyManager.getDialogue());
                            var effect = storyManager.getEffect();
                            if (effect != null)
                            {
                                // parse effect
                            }

                            var decisons = storyManager.getDecisions();
                            if (decisons != null)
                            {
                                foreach (var dec in decisons)
                                {
                                    Console.WriteLine(">{" + dec + "}<");
                                }
                                var playerInput = Input.GetUserResponse(decisons);
                                storyManager.nextDecisionNode(playerInput);
                            }
                            else
                            {
                                var playerInput = Input.GetUserResponse(new List<String>() { "" });
                                storyManager.nextNode();
                            }
                            
                        }
                    }
                },
                { "quit", () => Environment.Exit(1) }
            });
            menu.DisplayMenu();
            Console.Read();
        }
    }
}