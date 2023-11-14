namespace compsoc_ascii_gamejam.Utils;

public class GameManager
{
    private static readonly GameManager Instance = new GameManager();
    private int _playerScore = 0;

    private GameManager()
    {
        
    }

    public GameManager GetGameManager()
    {
        return Instance;
    }
}