using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOrchestrator : MonoBehaviour
{
    public List<string> minijeux;
    List<string> ordreJeux;
    private static bool addedSpy = false;
    private static int gameIndex = 0;
    void Start() {
        if (!addedSpy) {
            addedSpy = true;
            SceneManager.sceneLoaded += OnSceneLoaded;
            ordreJeux = minijeux;
            Shuffle(ordreJeux);
            this.GetComponent<LevelLoader>().LoadNextScene(ordreJeux[gameIndex]);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        Debug.Log("OnSceneLoaded: " + scene.name);
    }

        private void Shuffle(List<string> scenes)
    {
        System.Random random = new System.Random();
        for (int i = 0; i < scenes.Count; i++)
        {
            int randomIndex = random.Next(i, scenes.Count);
            string temp = scenes[i];
            scenes[i] = scenes[randomIndex];
            scenes[randomIndex] = temp;
        }
    }
}
