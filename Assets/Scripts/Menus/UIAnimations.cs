using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UIAnimations
{
   public static IEnumerator ChangeScale(this GameObject go, float duration, float speed, Vector3 from, Vector3 to, Action after = null )
    {
        float timeElapsed = 0;
        float x = 0;
        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;

            // Set our position as a fraction of the distance between the markers.
            go.transform.localScale = Vector3.Lerp(from, to, timeElapsed * speed);
            yield return null;
        }
        after?.Invoke();
    }
}
