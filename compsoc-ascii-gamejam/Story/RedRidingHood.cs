using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;

namespace compsoc_ascii_gamejam.Stories;

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
        String playerStatus;
        String whichPath;

        Console.WriteLine("Once upon a time there was a girl who wore a red cape gifted to her by her grandmother.");
        Console.WriteLine("One day her mother gave her a basket with wine, and fruits to bring to her grandmother, who lived in a cottage in the woods!");
        Console.WriteLine("Her mother warned her not to speak to strangers on the way, and to come straight home.");
        Console.WriteLine("You head out through the woods and begin your journey.");
        Console.WriteLine("Along the way you see a patch of flowers in various colours.");
        Console.WriteLine("Do you pick the flowers? please input 'yes' or 'no'");
        playerStatus = Console.ReadLine();
        Console.WriteLine(playerStatus);
        
        //playerStatus( validResponses, new list<String>() {"yes", "no", "fight", "run", "talk", "fast", "safe"});

        if (playerStatus == "yes")
        {
            Console.WriteLine("FLOWERS WERE ADDED TO INVENTORY"); //add flowers to the inventory class
        }
        else if (playerStatus == "no")
        {
            Console.WriteLine("You look at the flowers and smile before you continue on your way");
        }
        else
        {
            Console.WriteLine(playerStatus + " is an invalid answer. Please try again!");
        }
        Console.WriteLine("You continue walking looking across the trees, and admiring the natural scenery. You keep walking until eventually you come across a split in the path");
        Console.WriteLine("both paths will take you to your grandmothers house, however one while safer takes longer, but the faster path is more dangerous.");
        Console.WriteLine("Which path do you take? Please enter in 'safe' or 'fast' to decide!");
        whichPath = Console.ReadLine();
        // playerStatus(yes, no, fight, run, talk, fast, safe);
        if (whichPath == "safe")
        {
            Console.WriteLine("You begin to walk down the safe but longer path. As you walk through you see some stones that look as though you could use them as little weights");
            Console.WriteLine("Do you collect the stones? Please input 'yes' or 'no'!");
            playerStatus = Console.ReadLine();
            if (playerStatus == "yes")
            {
                Console.WriteLine("SMOOTH STONES ADDED TO INVENTORY"); //add the stones to the inventory
            }
            else if (playerStatus == "no")
            {
                Console.WriteLine("You don't have enough time and need to keep going to get to granny's. You continue on the path!");
            }
            Console.WriteLine("You continue on the path, until eventually you reach the point where the two paths would link up.");
        }
        else if (whichPath == "fast")
        {
            Console.WriteLine("You begin down the darker path which isn't as smooth, and has some thorns along it.");
            Console.WriteLine("As you're walking you accidently trip over a tree root that is crossing the path and skin your knee.");//add -1 hp
            Console.WriteLine("You get up and dust yourself off and continue walking taking note to pay more attention");
            Console.WriteLine("You hear some branches crack in the woods around you and quickly do a scan, however nothing is there. You continue walking and see a blade stuck into a tree. ");
            Console.WriteLine("Do you grab the blade? Please input 'yes' or 'no'?");
            playerStatus = Console.ReadLine();
            if (playerStatus == "yes")
            {
                Console.WriteLine("RUSTY BLADE HAS BEEN ADDED TO INVENTORY"); //add the blade to the inventory
            }
            else if (playerStatus == "no")
            {
                Console.WriteLine("You decide it's not worth risking getting hurt, or staying on this path any longer, and continue walking until you reach the point where the two paths sink up!");
            }
            Console.WriteLine("You are on the final stretch to get to granny's house. You begin walking down the path when suddenly a wolf runs out infront of you blocking your way.");
            Console.WriteLine("You have three options. You can 'run' away, 'talk' to the wolf and try to reason with it, or you can 'fight' the wolf and not have to worry about it again");
            Console.WriteLine("Which option do you choose? Please enter any phrase that was in quotes int he previous statement!");
            playerStatus = Console.ReadLine();
            if (playerStatus == "run")
            {
                //WHATEVER IT IS I SAID WOULD HAPPEN
            }
            else if (playerStatus == "talk")
            {
                //WHATEVER IT IS I SAID WOULD HAPPEN
            }
            else if (playerStatus == "fight")
            {
                //WE HAVE NOT PLANNED THIS BIT OUT AT ALL WOOOO
            }
            //END OF LITTLE RED RIDING HOOD. CODE SHOULD NOW BEGIN THE NEXT STORY YIPPEE

        }
    }
    
}