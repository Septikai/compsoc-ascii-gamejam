namespace compsoc_ascii_gamejam.Stories;

public class RedRidingHood //Starting story you launch into
{
    private static readonly RedRidingHood Instance = new RedRidingHood();

    private RedRidingHood()
    {
        string playerStatus;
        
        Console.WriteLine("Once upon a time there was a girl who wore a red cape gifted to her by her grandmother.");
        Console.WriteLine("One day her mother gave her a basket with wine, and fruits to bring to her grandmother, who lived in a cottage in the woods!");
        Console.WriteLine("Her mother warned her not to speak to strangers on the way, and to come straight home.");
        Console.WriteLine("You head out through the woods and begin your journey.");
        Console.WriteLine("Along the way you see a patch of flowers in various colours.");
        Console.WriteLine("Do you pick the flowers? please input 'yes' or 'no'");
        playerStatus = Console.ReadLine();
        if (playerStatus == "yes")
        {
            Console.WriteLine("FLOWERS WERE ADDED TO INVENTORY"); //add flowers to the inventory class
        }
        else if (playerStatus == "no")
        {
            Console.WriteLine("You look at the flowers and smile before you continue on your way");
        }
        
        /*introductory part of mom sending you on journey
        
        find some flowers along the way, collect
        **DONE UP TO HERE SO FAR**
        see some interesting looking rocks, collect
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
    
}