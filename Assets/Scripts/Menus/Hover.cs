using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hover : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    private Vector3 initialScale;
    private Coroutine growCoroutine;
    private Coroutine shrinkCoroutine;

    private void Awake()
    {
        initialScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(shrinkCoroutine != null) StopCoroutine(shrinkCoroutine);
        growCoroutine = StartCoroutine(gameObject.ChangeScale(.5f, initialScale, initialScale * 1.1f));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(growCoroutine != null) StopCoroutine(growCoroutine);
        shrinkCoroutine = StartCoroutine(gameObject.ChangeScale(.5f, transform.localScale, initialScale));
    }

}
