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
    [SerializeField]
    float speed = 1.0f; //how fast it shakes
    [SerializeField]
    float amount = 1.0f; //how much it shakes
    Vector3 originalPosition;
    float tempsPasse = 0;
    bool tooLate = false;

    private void Start() {
        originalPosition = transform.position;
    }

    private void OnMouseDown() {
        GameObject.Find("GameManager");
        mousePosition = Input.mousePosition;
        localTempsArrache = tempsDArrachage;
        if(!isBad) {
            print("pas la bonne dent");
        }
    }

    private void OnMouseDrag() {
        if (!tooLate) {
            var heading = Input.mousePosition - mousePosition;
            var dragPosition = heading / heading.magnitude;
            Shake(localTempsArrache);
            if (heading.magnitude > minMagnitude) {
                if ((dragPosition.y > 0 && !retournee) || (dragPosition.y < 0 && retournee)) {
                    localTempsArrache -= Time.deltaTime;
                    if (localTempsArrache < 0) {
                        tooLate = true;
                        if (retournee)
                            transform.position += new Vector3(0, -1, 0);
                        else
                            transform.position += new Vector3(0, 1, 0);
                        if (isBad) //TODO changer en invoke
                            print("Win !!!");
                        else
                            print("LOSE");
                    }
                }

            }
        }

    }

    void Shake(float localTime) {
        var xOffset = Mathf.PerlinNoise ( localTime * speed, 0 );
        var yOffset = Mathf.PerlinNoise ( 0, localTime * speed );

        transform.position = originalPosition + new Vector3 ( xOffset, yOffset, 0 ) * amount;
    }

    private void OnMouseUp() {
        localTempsArrache = tempsDArrachage;
        transform.position = originalPosition;
    }
    
    private void FixedUpdate() {
        tempsPasse += Time.deltaTime;
    }
}
