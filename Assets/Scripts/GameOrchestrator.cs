using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOrchestrator : MonoBehaviour
{
    private static bool addedSpy = false;
    void Awake() {
        if (!addedSpy) {
            addedSpy = true;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        Debug.Log("OnSceneLoaded: " + scene.name);
    }
}
