using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MathGameManager : MonoBehaviour
{
    List<Button> buttons;
    [SerializeField]
    public List<string> buttonNames;
    [SerializeField]
    List<string> possibleWrongAnswers;
    [SerializeField]
    List<int> possibleSquareRoots;
    Label label;

    int goodResponseIndex;
    void Start()
    {
        CreateButtons();
        ChooseAnswers();
    }

    void CreateButtons() {
        for (int i = 0; i < buttonNames.Count; i++)
        {
            Button button = GameObject.Find(buttonNames[i]).GetComponent<Button>();
            buttons.Add(button);
        }
    }

    void ChooseAnswers() {
        var squareRoot = Random.Range(0, possibleSquareRoots.Count);
        var labelText = Mathf.Pow(possibleSquareRoots[squareRoot], 2).ToString();
        label.text = labelText;
        goodResponseIndex = Random.Range(0, 4);
        buttons[goodResponseIndex].text = possibleSquareRoots[squareRoot].ToString();
        buttons.RemoveAt(goodResponseIndex);
        foreach(Button button in buttons) {
            int wrongAnswer = Random.Range(0, possibleWrongAnswers.Count);
            button.text = possibleWrongAnswers[wrongAnswer];
            possibleWrongAnswers.RemoveAt(wrongAnswer);
        }
    }

    public void OnClickButton(int buttonId) {
        Debug.Log("eee");
        if (buttonId == goodResponseIndex) {
            GetComponent<LoseManager>().Win();
        }
        else {
            GetComponent<LoseManager>().Lose();
        }
    }
}
