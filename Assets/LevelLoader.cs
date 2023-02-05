using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transition_time = 5f;
    public void LoadNextScene(string scene_name, string old_scene = null) {
        //Lance l'animation
        StartCoroutine(LoadLevel(scene_name));
        if (old_scene != null) {
            SceneManager.UnloadSceneAsync(old_scene);
        }
        //Unload l'ancienne scène s'il y a
        //Lance l'animation reverse
    }

    IEnumerator LoadLevel(string scene_name) {
        transition.SetTrigger("StartFade");
        yield return new WaitForSeconds(transition_time);
        SceneManager.LoadScene(scene_name, LoadSceneMode.Additive);
        transition.SetTrigger("EndFade");
    }
}
