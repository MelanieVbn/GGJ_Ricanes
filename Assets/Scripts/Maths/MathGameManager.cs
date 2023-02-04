using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MathGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    VisualElement root;
    List<Button> buttons;
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
        root = GetComponent<UIDocument>().rootVisualElement;
        Button button1 = root.Q<Button>("Button1");
        Button button2 = root.Q<Button>("Button2");
        Button button3 = root.Q<Button>("Button3");
        Button button4 = root.Q<Button>("Button4");
        label = root.Q<Label>("Question");
        buttons = new List<Button> { button1, button2, button3, button4 };
        button1.clicked += () => OnClickButton(0);
        button2.clicked += () => OnClickButton(1);
        button3.clicked += () => OnClickButton(2);
        button4.clicked += () => OnClickButton(3);
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

    void OnClickButton(int buttonId) {
        if (buttonId == goodResponseIndex) {
            GetComponent<LoseManager>().Win();
        }
        else {
            GetComponent<LoseManager>().Lose();
        }
    }
}
