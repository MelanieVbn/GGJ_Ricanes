using UnityEngine;
public class MathLoseManager : LoseManager
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