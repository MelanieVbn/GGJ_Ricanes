using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Behaviour : MonoBehaviour
{
    CineLoseManager loseBehaviour;
    [SerializeField]
    public Races race;
    TMP_Text text;

    private static bool eventProcessed = false;

    private void Start()
    {
        loseBehaviour = gameObject.GetComponent<CineLoseManager>();
    }
    //private void Start() {
    //    text = GameObject.Find("GameManager").GetComponent<CineGameManager>().text;
    //}

    private void OnMouseDown() {
        //Animate
        //Cri
        if (race == Races.Rat) {
            //text.text = "Rat-cine !";
            loseBehaviour.Win();

        } else {
            //text.text = "De-Rat-cine !";
            loseBehaviour.Lose();
        }
    }

    private void OnMouseEnter() {
        if (!eventProcessed) {
            this.GetComponent<SpriteRenderer>().flipX = true;
            eventProcessed = true;
        }
    }

    private void OnMouseExit() {
        this.GetComponent<SpriteRenderer>().flipX = false;
        eventProcessed = false;
    }
}

