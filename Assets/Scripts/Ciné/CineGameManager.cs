using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CineGameManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> animals;
    [SerializeField]
    List<GameObject> sieges;
    [SerializeField]
    public TMP_Text text;
    void Start()
    {
        foreach(GameObject animal in animals) {
            int emplacement = UnityEngine.Random.Range(0, sieges.Count);
            Instantiate(animal, sieges[emplacement].transform.position, Quaternion.Euler(0, 0, 0));
            sieges.RemoveAt(emplacement);
        }
    }
}
