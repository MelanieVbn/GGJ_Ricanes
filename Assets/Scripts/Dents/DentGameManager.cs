using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DentGameManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> dents;
    [SerializeField]
    Image dentIcone;
    [SerializeField]
    Image dentIconeDiv;
    [SerializeField]
    TMP_Text startTime;
    float timePassed = 0f;
    bool startedGame = false;
    void Awake()
    {
        int randomDent = Random.Range(0, dents.Count);
        dents[randomDent].GetComponent<ToothBehaviour>().isBad = true;
        dentIcone.sprite = dents[randomDent].GetComponent<SpriteRenderer>().sprite;
        Invoke("ClearIcon", 2.6f);
    }

    void FixedUpdate() {
        timePassed += Time.deltaTime;
        if (!startedGame) {
            startTime.text = Mathf.RoundToInt(2.5f - timePassed).ToString();
        }
    }

    void ClearIcon() {
        dentIconeDiv.GetComponent<Animator>().SetTrigger("Start");
        startedGame = true;
    }
}
