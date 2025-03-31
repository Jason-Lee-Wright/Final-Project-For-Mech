using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject MenuScreen, GameScreen, game;

    public TextMeshProUGUI levelText; // UI Text to display the selected level
    public AudioSource downChime, upChime;

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
            downChime.Play();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            upChime.Play();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Make play chime audio
            StartGame();
        }
    }

    void StartGame()
    {
        game.SetActive(true);

        MenuScreen.SetActive(false);
        GameScreen.SetActive(true);
    }
}