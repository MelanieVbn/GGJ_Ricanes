using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DentGameManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> dents;
    void Start()
    {
        int randomDent = Random.Range(0, dents.Count);
        dents[randomDent].GetComponent<ToothBehaviour>().isBad = true;
        //AfficheFenetre(dents[randomDent].GetComponent<SpriteRenderer>().sprite)
    }
}
