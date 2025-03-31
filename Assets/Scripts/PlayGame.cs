using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public AudioSource moveSound, eatSound;
    public TextMeshProUGUI timerText, scoreText;
    public GameObject GameOverScreen, GameScreen;
    public Image foodImage;
    public List<Sprite> foodSprites;
    public List<string> foodNames;

    public float gameTime = 60f;
    internal float currentTime;
    private bool isGameOver;
    private int score = 0, GoodINT = 0, BadINT = 0; // Score INTS
    private int GoodPassed = 0, BadPassed = 0; //To mark passed food of each type.
    private string currentFoodName;

    public void ResetGame()
    {
        score = 0;
        GoodINT = 0;
        BadINT = 0;

        GoodPassed = 0;
        BadPassed = 0;

        currentTime = gameTime;

        currentTime = gameTime;
        UpdateScoreText();
        SelectNewFood();
        GameOverScreen.SetActive(false);

        isGameOver = false;
    }

    void Update()
    {
        if (!isGameOver)
        {
            currentTime -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Ceil(currentTime).ToString();

            if (currentTime <= 0)
            {
                GameOver();
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow)) // Eat
            {
                EatFood();
                eatSound.Play();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow)) // Skip
            {
                SkipFood();
                moveSound.Play();
            }
        }
    }

    void SelectNewFood()
    {
        if (foodSprites.Count > 0 && foodNames.Count > 0)
        {
            int index = Random.Range(0, foodSprites.Count);
            foodImage.sprite = foodSprites[index];
            currentFoodName = foodNames[index];
        }
    }

    void EatFood()
    {
        if (currentFoodName.Contains("Good"))
        {
            GoodINT++;
        }
        else if (currentFoodName.Contains("Bad"))
        {
            BadINT++;
        }

        UpdateScoreText();
        //eatSound.Play();
        SelectNewFood();
    }

    void SkipFood()
    {
        if (currentFoodName.Contains("Good"))
        {
            GoodPassed++;
        }
        else if (currentFoodName.Contains("Bad"))
        {
            BadPassed++;
        }
        UpdateScoreText();
        //moveSound.Play();
        SelectNewFood();
    }

    void GameOver()
    {
        isGameOver = true;
        GameOverScreen.SetActive(true);
        GameScreen.SetActive(false);
    }

    void UpdateScoreText()
    {
        score = GoodINT - BadINT + BadPassed - GoodPassed;

        scoreText.text = "Proper Meals: " + GoodINT + "\n\nTRASH MEALS: " + BadINT + "\n\nGood Food Wasted: " + GoodPassed + "\n\nBad Food Thrown: " + BadPassed + "\n\nFinal Score: " + score;
    }
}