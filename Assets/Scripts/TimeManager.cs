using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    int timeUntilLose;
    void Start()
    {
        Invoke("Lose", timeUntilLose);
    }

    void Lose() {
        GetComponent<LoseManager>().Lose();
    }
}
