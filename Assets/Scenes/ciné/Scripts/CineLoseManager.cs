using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CineLoseManager : LoseManager
{
    public override void Lose()
    {
        Debug.Log("LOSER");
        SceneManager.LoadScene("Start Menu");
    }

    public override void Win()
    {
        throw new System.NotImplementedException();
    }
}
