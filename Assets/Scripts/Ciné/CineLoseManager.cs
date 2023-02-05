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
        gameOrchestrator.MiniGameEnded();
    }

    public override void Win()
    {
        gameOrchestrator.MiniGameEnded();
        //throw new System.NotImplementedException();
    }
}
