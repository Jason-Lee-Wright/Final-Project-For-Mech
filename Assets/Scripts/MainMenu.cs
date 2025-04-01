using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject MenuScreen, GameScreen, game;

    public TextMeshProUGUI levelText; // UI Text to display the selected level

    public GameController gameController;

    [TextArea] public string levelInfo;

    void Start()
    {
        GameScreen.SetActive(false);
        game.SetActive(false);
        MenuScreen.SetActive(true);

        levelText.text = levelInfo;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGameXX();
        }
    }

    void StartGame()
    {
        game.SetActive(true);

        gameController.ResetGame();

        MenuScreen.SetActive(false);
        GameScreen.SetActive(true);
    }

    void QuitGameXX()
    {
        Application.Quit();
    }
}