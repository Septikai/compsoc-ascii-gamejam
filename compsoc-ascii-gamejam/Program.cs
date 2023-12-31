﻿using compsoc_ascii_gamejam.Characters.NonPlayerCharacter;
using compsoc_ascii_gamejam.Characters.Player;
using compsoc_ascii_gamejam.Combat;
using compsoc_ascii_gamejam.Characters.NonPlayerCharacter;
using compsoc_ascii_gamejam.Combat;
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
                        storyManager = new StoryManager("Story/StoryFiles/RedRidingHood.gamestory");
                        while (true)
                        {
                            Console.WriteLine(storyManager.getDialogue());
                            var effect = storyManager.getEffect();
                            if (effect != null)
                            {
                                if (effect[0] == "ROLL")
                                {
                                    if (effect[1] == "STR")
                                    {
                                        CombatManager.GetInstance().InitiateCombat(new NonPlayerCharacter(8,5,3,3));
                                        storyManager.nextDecisionNode("win");
                                        continue;
                                    }
                                    Random rnd = new Random();
                                    int num = rnd.Next(6) + 1;
                                    if (num > 2)
                                    {
                                        storyManager.nextDecisionNode("win");
                                    }
                                    else
                                    {
                                        storyManager.nextDecisionNode("lose");
                                    }
                                    continue;
                                }
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
                { "fight", () =>
                    {
                        Inventory.GetInventory().AddToInventory(InventoryItem.Stick, 2);
                        Inventory.GetInventory().AddToInventory(InventoryItem.Rock, 1);
                        Inventory.GetInventory().AddToInventory(InventoryItem.RustedBlade, 1);
                        CombatManager.GetInstance().InitiateCombat(new NonPlayerCharacter(10, 5, 3, 3));
                    }
                },
                { "quit", () => Environment.Exit(1) }
            });
            menu.DisplayMenu();
            Console.Read();
        }
    }
}