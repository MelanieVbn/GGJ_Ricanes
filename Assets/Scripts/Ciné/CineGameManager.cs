using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CineGameManager : MonoBehaviour
{
    public static bool mouseEnteredSomething = false;
    public List<Sprite> animalSprites;
    [SerializeField]
    List<GameObject> sieges;
    [SerializeField]
    public TMP_Text text;
    void Start()
    {
        GameObject rat = null;
        foreach(Sprite animal in animalSprites) {
            if (sieges.Count != 0) {
                int emplacement = UnityEngine.Random.Range(0, sieges.Count);
                sieges[emplacement].GetComponent<SpriteRenderer>().sprite = animal;
                sieges[emplacement].AddComponent<PolygonCollider2D>();
                sieges[emplacement].AddComponent<CineLoseManager>();

                rat = sieges[emplacement];
                sieges.RemoveAt(emplacement);
            }
        }
        if (rat) {
            rat.GetComponent<Behaviour>().race = Races.Rat;
        }
    }
}
