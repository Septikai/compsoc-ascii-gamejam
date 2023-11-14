namespace compsoc_ascii_gamejam.Characters.Player;

public class PlayerCharacter : Character
{
    private static readonly PlayerCharacter Instance = new PlayerCharacter();
    private int _agility;
    private int _charisma;

    private PlayerCharacter()
    {
        /*
         * 20 is high
         * 0 is low
         * starting values around 2-4 depending on character creation
         */
        this.Health = 20;
        this.Strength = 3;
        this._agility = 3;
        this._charisma = 3;
    }
}