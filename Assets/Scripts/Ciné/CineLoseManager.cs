using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CineLoseManager : LoseManager
{
    GameOrchestrator gameOrchestrator;

    private void Awake()
    {
        gameOrchestrator = FindAnyObjectByType<GameOrchestrator>();
    }
    public override void Lose()
    {
        gameOrchestrator.MiniGameEnded(0);
    }

    public override void Win(int score)
    {
        gameOrchestrator.MiniGameEnded(score);
        //throw new System.NotImplementedException();
    }
}
