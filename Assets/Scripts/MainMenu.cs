using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject MenuScreen, GameScreen, game;

    public TextMeshProUGUI levelText; // UI Text to display the selected level
    public AudioSource downChime, upChime;

    private string[] levels = { "Level 1", "Level2", "Level3", "Level4" }; // Each level in order
    private string[] levelInfo = { "The sock Puppet is dying. You should stop that. Lucky for you there are random drugs everywhere... \nthats the perfect thing to feed it!",
                                   "These pills are just allergies??? \nThat should work!!",
                                   "Drugs AND allergies....... \nWHAT A GOOD IDEA!!!!!",
                                   "These are just regular medicine.... \nfine I guess this can work.."};
    public int currentLevelIndex = 0;

    void Start()
    {
        GameScreen.SetActive(false);
        game.SetActive(false);
        MenuScreen.SetActive(true);
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