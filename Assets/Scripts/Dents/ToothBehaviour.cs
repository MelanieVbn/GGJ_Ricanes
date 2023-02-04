using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothBehaviour : MonoBehaviour
{
    public int id;
    public bool direction;
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
    }

    private void OnMouseDrag() {
        var heading = Input.mousePosition - mousePosition;
        var dragPosition = heading / heading.magnitude;
        if (dragPosition.y > 0 && heading.magnitude > minMagnitude) {
            localTempsArrache -= Time.deltaTime;
            if (localTempsArrache < 0) {
                print("Win !!!");
            }
        }
    }

    private void OnMouseUp() {
        localTempsArrache = tempsDArrachage;
    }
}
