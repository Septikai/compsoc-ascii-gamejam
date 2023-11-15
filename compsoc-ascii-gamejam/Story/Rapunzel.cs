using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using compsoc_ascii_gamejam.ConsoleIO;

namespace compsoc_ascii_gamejam.Stories;

//player will access snowwhite by completeing the TALK option in RedRidingHood
public class Rapunzel //start the story for snow white
{
    private static readonly Rapunzel Instance = new Rapunzel();

    private Rapunzel()
    {
        /*
        Character has left granny's and is walking home.
        Player hears the sound of singing coming from the woods and decides to follow it
        While walking to the sound player sees 
        Follows it to a tall tower where Rapunzel is up above singing beautifully
        Character looks everywhere for an entrance to meet her however none is to be found.
        Character leaves however continues to return daily until eventually mother gothel is heard saying "rapunzel rapunzel let down your hair"
        The next day the character will say rapunzel rapunzel and climb up to the top. Where they will meet rapunzel
        Rapunzel will be shocked however character will explain that they heard rapunzel singing and wanted to meet her, rapunzel believes and they make plan to escape
        However Rapunzel accidentally reveals this plan to the queen
        Queen will send rapunzel away and trick player character
        Character will begin run fight talk sequence
            RUN:
            Character will jump out of the window, blinding themselves in the thorns (-5 hp)
            Mother gothel is left alive (no WP)
            player wanders aimlessly and finds rapunzel and has vision restored and they marry and go back to the player's home results - succes and get a WP for rapunzel
            TALK:
            charisma roll
            Character will attempt to reason with gothel explain oh I'm so sorry I just think she's so beautiful
            Offer mother gothel a spot in your life and say that you don't blame her for wanting to hide rapunzel as well if you can take rapunzel as a bride (fix wording in game tho)
                Sucess:
                Gothel agrees and shows the character to rapunzel
                get married happily ever after yada yada (2 WP made gothel kind and got rapunzel)
                Fail:
                Gothel gets angry and claims no one has any right to her
                Gothel blinds the character, and they fall out of the tower severely injured and begin aimlessly wandering the woods (-7 hp)
            FIGHT
            fight mechanic
            Character will attack gothel demanding to know where rapunzel is
                Sucess:
                Character will get an answer and kill gothel, and immediately go to find rapunzel
                Get married live happily ever after
                Fail:
                Gothel hurts player (-10 hp) if player runs out of hp from this death
                Otherwise player simply falls out of the tower eventually is blinded and wanders aimlessly until getting home where you collapse resulting in game loss


        */
    }

}