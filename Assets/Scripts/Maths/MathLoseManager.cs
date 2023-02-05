using UnityEngine;
public class MathLoseManager : LoseManager
{
    GameOrchestrator gameOrchestrator;

    private void Awake()
    {
        gameOrchestrator = FindAnyObjectByType<GameOrchestrator>();
    }

    public override void Lose()
    {
        Debug.Log("LOSER");
    }

    public override void Win(int score)
    {
        Debug.Log("Winner !!");
        gameOrchestrator.MiniGameEnded(score);
    }
}