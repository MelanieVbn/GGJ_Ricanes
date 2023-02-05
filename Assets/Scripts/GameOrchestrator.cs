using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOrchestrator : MonoBehaviour
{
    public List<string> minijeux;
    public int gameIndex = 0;
    public int miniGameCount = 10;
    public int score = 0;

    void Start() {
            Debug.Log("START");
            NextMiniGame();
    }

    void NextMiniGame()
    {
        if(miniGameCount > 0)
        { 
            miniGameCount--;
            SceneManager.sceneLoaded += OnSceneLoaded;
            int randomIndex = Random.Range(0, minijeux.Count);
            while (randomIndex == gameIndex)
            {
                randomIndex = Random.Range(0, minijeux.Count);
                Debug.Log(randomIndex);
            }
            gameIndex = randomIndex;
            this.GetComponent<LevelLoader>().LoadNextScene(minijeux[gameIndex]);
        }
        else
        {
            LoadEndScreen();
        }
        
    }

    void LoadEndScreen()
    {
        Debug.Log("TOTAL : " + score);
        SceneManager.LoadScene("Start Menu");
        //TextMeshProUGUI text = transition.GetComponentInChildren<TextMeshProUGUI>();
        //text.color = Random.ColorHSV();
        //transition.SetActive(true);
        //StartCoroutine(transition.ChangeScale(.5f, 8f, Vector3.zero, initialTransitionScale, () => {
        //    SceneManager.LoadScene("Start Menu");
        //}));
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

    public void MiniGameEnded(int score)
    {
        SetScore(score);
        NextMiniGame();
    }

    void SetScore(int score)
    {
        this.score += score;
    }
}
