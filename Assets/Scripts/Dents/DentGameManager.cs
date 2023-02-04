using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DentGameManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> dents;
    [SerializeField]
    List<GameObject> emplacementHauts;
    [SerializeField]
    List<GameObject> emplacementBas;
    List<GameObject> dentsPlacees = new List<GameObject>();
    void Start()
    {
        var emplacements = new List<GameObject>();
        emplacements.AddRange(emplacementBas);
        emplacements.AddRange(emplacementHauts);
        foreach (GameObject dent in dents)
        {
            var emplacementDent = Random.Range(0, emplacements.Count);
            Instantiate(dent, emplacements[emplacementDent].transform.position, emplacements[emplacementDent].transform.rotation);
            emplacements.RemoveAt(emplacementDent);
            dentsPlacees.Add(dent);
        }
        dentsPlacees[Random.Range(0, dentsPlacees.Count)].GetComponent<ToothBehaviour>().isBad = true;  
    }
}
