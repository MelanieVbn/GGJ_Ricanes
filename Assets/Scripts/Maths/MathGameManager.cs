using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
// using UnityEngine.UIElements;

public class MathGameManager : MonoBehaviour
{
    [SerializeField]
    List<string> possibleWrongAnswers;
    [SerializeField]
    List<int> possibleSquareRoots;
    [SerializeField]
    List<TMP_Text> buttons;
    [SerializeField]
    TMP_Text question;

    int goodResponseIndex;
    void Start()
    {
        ChooseAnswers();
    }

    void ChooseAnswers() {
        var squareRoot = Random.Range(0, possibleSquareRoots.Count);
        var labelText = Mathf.Pow(possibleSquareRoots[squareRoot], 2).ToString();
        question.text = labelText;
        goodResponseIndex = Random.Range(0, 4);
        // AssignText(buttons[goodResponseIndex],  possibleSquareRoots[squareRoot].ToString());
        buttons[goodResponseIndex].text = possibleSquareRoots[squareRoot].ToString();
        buttons.RemoveAt(goodResponseIndex);
        foreach(TMP_Text button in buttons) {
            int wrongAnswer = Random.Range(0, possibleWrongAnswers.Count);
            // button.text = possibleWrongAnswers[wrongAnswer];
            button.text = possibleWrongAnswers[wrongAnswer];
            // AssignText(button, possibleWrongAnswers[wrongAnswer]);
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
