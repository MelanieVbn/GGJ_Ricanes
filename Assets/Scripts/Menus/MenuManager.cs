using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject[] panels;

    private void Start()
    {
        ActivatePanel("MainMenuPanel");
    }
    public void OnPlayButtonClicked()
    {
        Debug.Log("Start game");
    }

    public void OnSelectGameButtonClicked()
    {
        ActivatePanel("GameSelectionPanel");
    }

    public void OnSeeScoresButtonClicked()
    {
        ActivatePanel("ScoresPanel");
    }

    public void OnCreditsPanelButtonClicked()
    {
        ActivatePanel("CreditsPanel");
    }

    public void OnMainMenuButtonClicked()
    {
        ActivatePanel("MainMenuPanel");
    }

    public void OnQuitButtonClicked()
    {
        Application.Quit();
    }
    void ActivatePanel(string panelName)
    {
        foreach (var panel in panels)
        {
            panel.SetActive(panel.name == panelName);
        }
    }

}
