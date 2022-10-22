using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class ScorecardScript : MonoBehaviour
{
    public Button retry, exit;
    public Label score;
    public void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        retry = root.Q<Button>("retry");
        exit = root.Q<Button>("exit");
        score = root.Q<Label>("score");
        score.text = CollectorScript.Score.ToString();
        retry.clicked += RetryGame;
        exit.clicked += ExitGame;
    }

    void RetryGame()
    {
        CollectorScript.Score = 0;
        SceneManager.LoadScene("Game");
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
