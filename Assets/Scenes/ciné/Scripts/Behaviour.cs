using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Behaviour : MonoBehaviour
{
    [SerializeField]
    Races race;
    TMP_Text text;

    private void Start() {
        text = GameObject.Find("GameManager").GetComponent<CineGameManager>().text;
    }
    private void OnMouseDown() {
        //Animate
        //Cri
        if (race == Races.Rat) {
            text.text = "Rat-cine !";
        } else {
            text.text = "De-Rat-cine !";
        }
    }

    private void OnMouseEnter() {
        this.GetComponent<SpriteRenderer>().flipX = true;
    }

    private void OnMouseExit() {
        this.GetComponent<SpriteRenderer>().flipX = false;
    }
}
