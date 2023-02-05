using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothBehaviour : MonoBehaviour
{
    public bool isBad;
    public bool retournee = false;
    [SerializeField]
    int minMagnitude = 200;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip dentTiree;
    [SerializeField] AudioClip dentEnlevee;
    [SerializeField]
    int tempsDArrachage = 5;
    Vector3 mousePosition;
    float localTempsArrache;
    [SerializeField]
    float speed = 1.0f; //how fast it shakes
    float originalSpeed;
    [SerializeField]
    float amount = 1.0f; //how much it shakes
    Vector3 originalPosition;
    float tempsPasse = 0;
    bool tooLate = false;

    int score = 100;

    GameOrchestrator gameOrchestrator;

    private void Awake()
    {
        gameOrchestrator = FindAnyObjectByType<GameOrchestrator>();
    }

    private void Start() {
        originalPosition = transform.position;
        originalSpeed = speed;
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
            if(!audioSource.isPlaying) {
                audioSource.clip = dentTiree;
                audioSource.loop = true;
            }
            if (heading.magnitude > minMagnitude) {
                if ((dragPosition.y > 0 && !retournee) || (dragPosition.y < 0 && retournee)) {
                    localTempsArrache -= Time.deltaTime;
                    speed += Time.deltaTime;
                    if (localTempsArrache < 0) {
                        tooLate = true;
                        if (retournee) {
                            transform.position += new Vector3(0, -1, 0);
                            this.GetComponent<SpriteRenderer>().sortingOrder = 10;
                        }
                        else {
                            transform.position += new Vector3(0, 1, 0);
                        }
                        audioSource.clip = dentTiree;
                        audioSource.loop = false;
                        Invoke("WinOrLose", 2);
                    }
                }

            }
        }

    }

    void WinOrLose() {
        if (isBad)
        {
            print("Win !!!");
            gameOrchestrator.MiniGameEnded(score);
        }
        else
        {
            print("LOSE");
            gameOrchestrator.MiniGameEnded(0);
        }
    }

    void Shake(float localTime) {
        var xOffset = Mathf.PerlinNoise ( localTime * speed, 0 );
        var yOffset = Mathf.PerlinNoise ( 0, localTime * speed );

        transform.position = originalPosition + new Vector3 ( xOffset, yOffset, 0 ) * amount;
    }

    private void OnMouseUp() {
        if (!tooLate) {
            localTempsArrache = tempsDArrachage;
            transform.position = originalPosition;
            audioSource.loop = false;
        }
    }

    private void OnMouseOver() {
        var xOffset = Mathf.PerlinNoise ( 1, 0 );
        var yOffset = Mathf.PerlinNoise ( 0, 1 );

        transform.position = originalPosition + new Vector3 ( xOffset, yOffset, 0 ) * amount;
    }

    private void OnMouseExit() {
        transform.position = originalPosition;
    }
    
    private void FixedUpdate() {
        tempsPasse += Time.deltaTime;
    }
}
