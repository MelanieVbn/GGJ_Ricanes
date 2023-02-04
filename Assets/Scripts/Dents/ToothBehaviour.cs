using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothBehaviour : MonoBehaviour
{
    public bool isBad;
    public bool retournee = false;
    [SerializeField]
    int minMagnitude = 200;
    [SerializeField]
    int tempsDArrachage = 5;
    Vector3 mousePosition;
    float localTempsArrache;

    private void OnMouseDown() {
        GameObject.Find("GameManager");
        mousePosition = Input.mousePosition;
        localTempsArrache = tempsDArrachage;
        if(!isBad) {
            print("pas la bonne dent");
        }
    }

    private void OnMouseDrag() {
        var heading = Input.mousePosition - mousePosition;
        var dragPosition = heading / heading.magnitude;
        if (heading.magnitude > minMagnitude) {
            if ((dragPosition.y > 0 && !retournee) || (dragPosition.y < 0 && retournee)) {
                localTempsArrache -= Time.deltaTime;
                if (localTempsArrache < 0) {
                    if (isBad)
                        print("Win !!!");
                    else
                        print("LOSE");
                }
            }

        }
    }

    private void OnMouseUp() {
        localTempsArrache = tempsDArrachage;
    }
}
