using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootingManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject[] needleRange;
    [SerializeField] GameObject rootingZone;
    [SerializeField] GameObject needle;
    [SerializeField] float needleMoveSpeed = 1.5f;
    [SerializeField] int lives = 1;
    [SerializeField] int rootingSteps = 3;

    private RootingZoneGauge rootingZoneGaugeScript;
    private Coroutine balancier;

    private Vector3 gaugeStart;
    private Vector3 gaugeEnd;

    private bool isNeedleStopped;
    private bool canStop;

    private bool gameEnded;

    private void Awake()
    {
        if (needleRange.Length == 2)
        {
            gaugeStart = needleRange[0].transform.position;
            gaugeEnd = needleRange[1].transform.position;
        }

        rootingZoneGaugeScript = rootingZone.GetComponent<RootingZoneGauge>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartGauge();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameEnded)
        {
            if(rootingSteps == 0)
            {
                Debug.Log("You win");
                gameEnded = true;
            }
            else
            {
                if (canStop && Input.GetKeyDown(KeyCode.Space) && !isNeedleStopped && rootingSteps > 0)
                {
                    isNeedleStopped = true;
                    canStop = false;

                    StopCoroutine(balancier);
                    if (IsIndicatorInRightZone())
                    {
                        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 1, player.transform.position.z);
                        rootingSteps--;

                        StartGauge();
                    }
                    else
                    {
                        if(lives > 0)
                        {
                            StartGauge();
                            lives--;
                        }
                        else
                        {
                            gameEnded = true;
                            Debug.Log("You Loose");
                        }
                    }
                }
            }
        }
    }

    void StartGauge()
    {
        if (rootingSteps > 0 && lives > 0)
        {
            isNeedleStopped = false;
            canStop = true;
            needle.transform.position = gaugeStart;
            balancier = StartCoroutine(Balancier());
        }
    }

    bool IsIndicatorInRightZone()
    {
        return rootingZoneGaugeScript.isInZone;
    }
    IEnumerator Balancier()
    {
        float x = 0;
        while (true)
        {
            x += Time.deltaTime * needleMoveSpeed;

            // Set our position as a fraction of the distance between the markers.
            needle.transform.position = Vector3.Lerp(gaugeStart, gaugeEnd, Mathf.PingPong(x, 1));
            yield return null;
        }
    }
}
