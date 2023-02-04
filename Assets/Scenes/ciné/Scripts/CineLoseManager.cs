using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CineLoseManager : LoseManager
{
    public override void Lose()
    {
        Debug.Log("LOSER");
    }

    public override void Win()
    {
        throw new System.NotImplementedException();
    }
}
