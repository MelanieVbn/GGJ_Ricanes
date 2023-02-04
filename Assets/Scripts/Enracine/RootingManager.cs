using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootingManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject[] needleRange;
    [SerializeField] GameObject rootingZone;
    [SerializeField] GameObject needle;
    [SerializeField] float needleMoveSpeed = 2f;

    private RootingZoneGauge rootingZoneGaugeScript;
    private Coroutine balancier;

    private Vector3 gaugeStart;
    private Vector3 gaugeEnd;

    private bool isNeedleStopped = false;
    private bool canStop = true;

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
        needle.transform.position = gaugeStart;
        balancier = StartCoroutine(Balancier());
    }

    // Update is called once per frame
    void Update()
    {
        if (canStop && Input.GetKeyDown(KeyCode.Space) && !isNeedleStopped)
        {
            isNeedleStopped = true;
            canStop = false;

            StopCoroutine(balancier);
            if (IsIndicatorInRightZone())
            {
                Debug.Log("right");
            }
            else
            {
                Debug.Log("you loose");
            }
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
