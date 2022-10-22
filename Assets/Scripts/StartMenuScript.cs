using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class StartMenuScript : MonoBehaviour
{
    public Button start, exit;
    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        start = root.Q<Button>("start");
        exit = root.Q<Button>("exit");
        start.clicked += StartGame;
        exit.clicked += ExitGame;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
