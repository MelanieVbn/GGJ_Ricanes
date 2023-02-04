using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootingZoneGauge : MonoBehaviour
{
    private bool _isInZone;
    public bool isInZone { get { return _isInZone; } }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _isInZone = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _isInZone = false;
    }
}
