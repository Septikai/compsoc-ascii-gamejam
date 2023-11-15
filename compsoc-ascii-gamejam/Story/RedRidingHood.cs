using compsoc_ascii_gamejam.Characters;
using compsoc_ascii_gamejam.Characters.Player;
using compsoc_ascii_gamejam.ConsoleIO;

namespace compsoc_ascii_gamejam.Story;

public class RedRidingHood //Starting story you launch into
{
    private static readonly RedRidingHood Instance = new RedRidingHood();

    private RedRidingHood()
    {
        /*introductory part of mom sending you on journey
        
        find some flowers along the way, collect
        get option to choose paths
        see some interesting looking rocks, collect
        see blade, collect
        statement giving you option on what you want to do 

        RUN:
        agility roll - are you agile enough to escape??? 
            Success:
            Run away and come across some sheep. TRIGGER BOY WHO CRIED WOLF SEQUENCE

            Fail:
            Start running wolf catches you and hurts you (-3 hp) then you escape and keep running. TRIGGER BOY WHO CRIED WOLF SEQUENCE
        
        TALK:
        charisma roll - can you sweet talk your way to get the wolf to be honest???
            Success: 
            Wolf tells you it's plans apologizes, and runs off never to be seen again dun dun duhhh (+1 WP)
            Finish red riding hood sequence. Find snow white
            
            Fail:
            Wolf gets upset with you, and attacks you (-4 hp) then runs off, and you decide to continue to grandma's. Only to find her DEAD and quickly flee before wolf can kill you.
            Lose red riding hood. Get lose when leaving TRIGGER SNOW WHITE SEQUENCE

        FIGHT:
        strength roll 

        */
    }

    public static RedRidingHood GetInstance()
    {
        return Instance;
    }

    public void Start()
    {
        RRHStart();
    }

    private void RRHStart()
    {
        Console.WriteLine("Once upon a time there was a girl who wore a red cape gifted to her by her grandmother.");
        Console.WriteLine("One day her mother gave her a basket with wine, and fruits to bring to her grandmother, who lived in a cottage in the woods!");
        Console.WriteLine("Her mother warned her not to speak to strangers on the way, and to come straight home.");
        Console.WriteLine("You head out through the woods and begin your journey.");
        Console.WriteLine("Along the way you see a patch of flowers in various colours.");
        Console.WriteLine("Do you pick the flowers? please input 'yes' or 'no'");

        var playerInput = Input.GetUserResponse(new List<String>() { "yes", "no" });

        if (playerInput == "yes")
        {
            Inventory.GetInventory().AddToInventory(InventoryItem.Flowers, 1);
        }
        else if (playerInput == "no")
        {
            Console.WriteLine("You look at the flowers and smile before you continue on your way");
        }
        else
        {
            Console.WriteLine(playerInput + " is an invalid answer. Please try again!");
        }
        Console.WriteLine("You continue walking looking across the trees, and admiring the natural scenery. You keep walking until eventually you come across a split in the path");
        Console.WriteLine("both paths will take you to your grandmothers house, however one while safer takes longer, but the faster path is more dangerous.");
        Console.WriteLine("Which path do you take? Please enter in 'safe' or 'fast' to decide!");
        playerInput = Input.GetUserResponse(new List<String>() { "safe", "fast" });
        if (playerInput == "safe") RRHSafePath();
        else if (playerInput == "fast") RRHFastPath();
    }

    private void RRHSafePath()
    {
        Console.WriteLine("You begin to walk down the safe but longer path. As you walk through you see some stones that look as though you could use them as little weights");
        Console.WriteLine("Do you collect a stone? Please input 'yes' or 'no'!");
        var playerInput = Input.GetUserResponse(new List<String>() { "yes", "no" });
        if (playerInput == "yes")
        {
            Inventory.GetInventory().AddToInventory(InventoryItem.Rock, 1);
        }
        else if (playerInput == "no")
        {
            Console.WriteLine("You don't have enough time and need to keep going to get to granny's. You continue on the path!");
        }
        Console.WriteLine("You continue on the path, until eventually you reach the point where the two paths would link up.");
        RRHFinalPath();

    }

    private void RRHFastPath()
    {
        Console.WriteLine("You begin down the darker path which isn't as smooth, and has some thorns along it.");
        Console.WriteLine("As you're walking you accidentally trip over a tree root that is crossing the path and skin your knee.");
        PlayerCharacter.GetPlayerCharacter().ModifyStat(CharacterStat.Health, -1);
        Console.WriteLine("You get up and dust yourself off and continue walking taking note to pay more attention");
        Console.WriteLine("You hear some branches crack in the woods around you and quickly do a scan, however nothing is there. You continue walking and see a blade stuck into a tree. ");
        Console.WriteLine("Do you grab the blade? Please input 'yes' or 'no'?");
        var playerInput = Input.GetUserResponse(new List<String>() { "yes", "no" });
        if (playerInput == "yes")
        {
            Inventory.GetInventory().AddToInventory(InventoryItem.RustedBlade, 1);
        }
        else if (playerInput == "no")
        {
            Console.WriteLine("You decide it's not worth risking getting hurt, or staying on this path any longer, and continue walking until you reach the point where the two paths sink up!");
        }
        RRHFinalPath();
    }

    private void RRHFinalPath()
    {
        Console.WriteLine("You are on the final stretch to get to granny's house. You begin walking down the path when suddenly a wolf runs out in front of you blocking your way.");
        Console.WriteLine("You have three options. You can 'run' away, 'talk' to the wolf and try to reason with it, or you can 'fight' the wolf and not have to worry about it again");
        Console.WriteLine("Which option do you choose? Please enter any phrase that was in quotes int he previous statement!");
        var playerInput = Input.GetUserResponse(new List<String>() { "run", "talk", "fight" });
        if (playerInput == "run")
        {
            /*
            You turn around and begin to run away from the wolf. You don't pay attention where you run, anywhere will work as long as it gets you away from the wolf

            *INSERT THE AGILITY STAT ROLL HERE*

            IF YOU WIN

            You refuse to turn around to see if you've lost the wolf. You make turns when you can to try and disorient it without realizing you're disorienting yourself.
            You simply keep running until eventually you see the shephard boy on a hill. You begin to wave your arms at him, while you run until you reach the top of the hill and
            notice that you have lost the wolf. You sit down and explain what has happened 

            *BEGIN BOY WHO CRIED WOLF*

            IF YOU LOSE 
            *-4 HP* 

            You continue to run however the wolf grabs your leg making you fall. You kick at it a few times until eventually it releases your leg and you run off. Fueled by
            pure adrenaline you continue to run, until you see the shephard boy at the top of a hill. You run towards him and once you reach the top of the hill you sit down, and explain
            to him what just occured. 
            
            *BEGIN BOY WHO CRIED WOLF*
            */
        }
        else if (playerInput == "talk")
        {
            /*

            You stare at the wolf for a moment before you ask what it wants.

            *INSERT CHARISMA ROLL HERE*

            IF YOU WIN
            
            The wolf stares at you before sighing. It apologizes and explains that it intended to get you lost so that you could starve and be an easy dinner. However you're simply
            too kind, and it can't bear harming you. Then it proceeds to turn around and run away leaving you shocked. You sigh and continue you're walk to granny's where you will give
            give her the wine and fruits. She thanks you and sends you home. While on your way home however you hear a beautiful singing voice that you feel compelled to follow. You
            begin to follow it until you reach a tower 

            *Get two winpoints for RRH as granny lived but wolf didn't die, finished the quest*
            *BEGIN RAPUNZEL*

            IF YOU LOSE

            The wolf starts explaining how it was out exploring when it got lost and know it can't find it's den. It looks to be a rather young wolf, and so you decide to trust it.
            You begin to help the wolf find it's home asking questions like what it looks like, and any identifying land marks, however the wolf seems to not know anything. Eventually
            however you turn around and the wolf has disappeared. You begin to realize you have no idea where you are, and realize you have gotten lost in the woods. You attempt to 
            retrace your steps, however you're simply too far into the woods at this point. You eventually hear a beautiful singing voice in the distance. You decide to follow it hoping you 
            can ask the person how to get back home. 

            *NO WINPOINTS*
            *BEGIN RAPUNZEL*
            */
        }
        else if (playerInput == "fight")
        {
            //WE HAVE NOT PLANNED THIS BIT OUT AT ALL WOOOO
        }
        //END OF LITTLE RED RIDING HOOD. CODE SHOULD NOW BEGIN THE NEXT STORY YIPPEE
    }
    
}