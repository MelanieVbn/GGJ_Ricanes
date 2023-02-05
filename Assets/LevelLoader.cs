using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transition_time = 5f;


    [SerializeField] GameObject transitionPanel;
    Vector3 initialTransitionScale;
    private string current_scene;

    private void Awake()
    {
        initialTransitionScale = transitionPanel.transform.localScale;
        transitionPanel.SetActive(true);
    }

    public void LoadNextScene(string scene_name, string old_scene = null) {


        Debug.Log("LA SCENE : "+scene_name);
        GameTransition(scene_name, current_scene);
        //Lance l'animation
        //StartCoroutine(LoadLevel(scene_name));
        //if (old_scene != null) {
        //    SceneManager.UnloadSceneAsync(old_scene);
        //}
        //Unload l'ancienne scène s'il y a
        //Lance l'animation reverse
    }

    IEnumerator LoadLevel(string scene_name) {
        transition.SetTrigger("StartFade");
        yield return new WaitForSeconds(transition_time);
        SceneManager.LoadScene(scene_name, LoadSceneMode.Additive);
        transition.SetTrigger("EndFade");
    }

    void GameTransition(string scene_name, string old_scene)
    {
        TextMeshProUGUI text = transitionPanel.GetComponentInChildren<TextMeshProUGUI>();
        text.text = scene_name;
        text.color = UnityEngine.Random.ColorHSV();
        transitionPanel.SetActive(true);
        IEnumerator afterScaleGrow = AfterScaleGrow(scene_name, old_scene, () => StartCoroutine(transitionPanel.ChangeScale(1f, 4f, initialTransitionScale, Vector3.zero,
 () => transitionPanel.SetActive(false)
 )));

        if(transitionPanel.transform.localScale == initialTransitionScale)
        {
            StartCoroutine(afterScaleGrow);
        }
        else
        {
            StartCoroutine(transitionPanel.ChangeScale(1f, 4f, Vector3.zero, initialTransitionScale, () => {
                StartCoroutine(afterScaleGrow);
            }));
        }
    }

    IEnumerator AfterScaleGrow(string scene_name, string old_scene, Action after)
    {
        if (old_scene != null)
        {
            SceneManager.UnloadSceneAsync(old_scene);
        }
        yield return new WaitForSeconds(transition_time);
        SceneManager.LoadScene(scene_name, LoadSceneMode.Additive);
        current_scene = scene_name;
        after();
    }
}
