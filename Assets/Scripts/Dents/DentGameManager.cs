using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DentGameManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> dents;
    void Start()
    {
        dents[Random.Range(0, dents.Count)].GetComponent<ToothBehaviour>().isBad = true;  
    }
}
