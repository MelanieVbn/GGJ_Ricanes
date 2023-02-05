using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UIAnimations
{
   public static IEnumerator ChangeScale(this GameObject go, float duration, Vector3 from, Vector3 to)
    {
        float timeElapsed = 0;
        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime/duration;

            // Set our position as a fraction of the distance between the markers.
            go.transform.localScale = Vector3.Lerp(from, to, timeElapsed);
            yield return null;
        }
    }
}
