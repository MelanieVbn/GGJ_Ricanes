using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject[] panels;
    [SerializeField] GameObject transition;
    [SerializeField] List<AudioSource> musiques;
    [SerializeField] AudioSource mainAS;
    [SerializeField] AudioClip ericContent;
    Vector3 initialTransitionScale;

    private void Start()
    {
        initialTransitionScale = transition.transform.localScale;
        ActivatePanel("MainMenuPanel");
        transition.SetActive(false);
        musiques[1].PlayDelayed(musiques[0].clip.length - 0.5f);
    }
    public void OnPlayButtonClicked()
    {
        TextMeshProUGUI text = transition.GetComponentInChildren<TextMeshProUGUI>();
        text.color = Random.ColorHSV();
        transition.SetActive(true);
        mainAS.clip = ericContent;
        mainAS.Play();
        StartCoroutine(transition.ChangeScale(.5f, 8f, Vector3.zero, initialTransitionScale, () => {
            SceneManager.LoadScene("Game");
        }));
    }

    public void OnSelectGameButtonClicked()
    {
        PanelTransition("GameSelectionPanel");
    }

    public void OnSeeScoresButtonClicked()
    {
        PanelTransition("ScoresPanel");
    }

    public void OnCreditsPanelButtonClicked()
    {
        PanelTransition("CreditsPanel");
    }

    public void OnMainMenuButtonClicked()
    {
        PanelTransition("MainMenuPanel");
    }

    public void OnQuitButtonClicked()
    {
        Application.Quit();
    }
    void PanelTransition(string panelName)
    {
        TextMeshProUGUI text = transition.GetComponentInChildren<TextMeshProUGUI>();
        text.color = Random.ColorHSV();
        transition.SetActive(true);
        StartCoroutine(transition.ChangeScale(.5f, 8f, Vector3.zero, initialTransitionScale, () => { ActivatePanel(panelName); StartCoroutine(transition.ChangeScale(.5f, 8f, initialTransitionScale, Vector3.zero,
            () => transition.SetActive(false)
            )); 
        }));
    }

    void ActivatePanel(string panelName)
    {
        foreach (var panel in panels)
        {
            panel.SetActive(panel.name == panelName);
        }
    }

}
