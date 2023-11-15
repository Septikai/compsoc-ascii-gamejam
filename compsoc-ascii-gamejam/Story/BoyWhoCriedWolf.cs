using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using compsoc_ascii_gamejam.ConsoleIO;

namespace compsoc_ascii_gamejam.Stories;

public class BoyCriedWolf //start the story for hansel and gretel
{
    private static readonly BoyCriedWolf Instance = new BoyCriedWolf();

    private BoyCriedWolf()
    {
        /*
     The boy begins to loudly yell "wolf" after you finish explaining. You tell him there is no wolf and he doesn't need to shout but he doesn't listen. The townspeople hear this, and
     run up the hill thinking that there is a wolf, and they need to defend the sheep. Annoyed, the townspeople leave and the shepherd boy's father stays behind to scold the two of you
     explaining to only shout "wolf" if there is a wolf approaching. You nod your head, and then he turns to the boy. In an even more stern tone he says "you need to knock it off, second
     time you've done this today it isn't funny" he lectures before turning around and walking off. However not long after the townspeople are gone, the wolf begins to runup the hill. 
     You both begin to scream "wolf" however no one shows. Leaving you to make a choice in either attempting to "run" away from the wolf, "talk" to the wolf, or "fight" the wolf! 
     Which do you choose?

     *INPUT TO GET RESPONSE OF RUN TALK FIGHT*

     IF RUN
     
        You decide your best bet is to run away again, but this time you make your focus to get home. 

        *AGILITY ROLL HERE*

            IF WIN

                You continue to run until you get home hoping the wolf isn't following you. Once you get there you explain to your mother what happened. She is understanding and just
                glad that you made it home okay. 
            
            IF LOSE
                *-6 hp*

                You attempt to run away however the wolf catches your leg before the boy hit's it on the head with a stick he found nearby. The wolf cowers away from that momentarily
                giving you just enough time to start running home. Your leg is bleeding quite badly however, and you don't know if you'll make it. Surprisingly you do however, and
                immediately upon seeing you your mother takes you to clean of your wounds and makes you rest in bed the rest of the day so you don't become further injured.

                *END GAME HERE FOR THIS STORY LINE, THIS IS ONE ENDING*
    
     IF TALK 

        You beg the wolf to please just leave you be and apologize for running away initially explaining you were frightened by it's sudden apperance.

        *charisma roll against wolf*

        IF WIN
            
            The wolf stares at you before backing off. This gives you the chance to go home and explain to your mother what happened. She is upset you didn't deliver the basket to
            your granny but understands why. The two of you walk there together in order to give her the basket. When you arrive there your granny fixes you a dinner for you all to
            enjoy together before you and your mother head back home. The dinner is one of the best things you have ever had and you ask your granny how she made it. She just smiles
            and said with a secret ingredient before giving you a wink.

            *END GAME AT THAT, THIS IS A SECOND ENDING*
        IF LOSE
            The wolf does not forgive you and instead chases off the sheep. This upsets the boy who was meant to prevent them from running off. He begins to shout at you for even
            bringing the wolf over here, blaming you for the sheep being gone. Eventually the towns people come up the hill wondering what is going on to see what has occured. The 
            boy's father scolds him for losing the sheep, and you take this moment to slip away feeling guilty. You didn't mean to get him in trouble you simply didn't know what to do.
            
            *END GAME AT THIS FOR NOW, HOWEVER PREFERABLY LINK THIS INTO ANOTHER STORY IF TIME PERMITS*
            
     IF FIGHT
        fighting mechanic 
        Attack the wolf
            Sucess:
            You kill the wolf, bring the corpse to the villagers so they can use it and they are very happy as the wolf has been causing problems (it's the only wolf in the forest ig?)
            In return you are given a cake which you take home to your mother. game over win game
            Fail:
            You attempt to fight the wolf however it attacks you as well (-6 hp) you begin crying out however causing the villagers to see what is the matter, they are upset and save you
            however the sheep have gone, and the shephard boy is upset you brought the wolf over and someone helps you home to your mother where you immediately are made to rest to recover
            game over wolf is still out there
        */
    }

}