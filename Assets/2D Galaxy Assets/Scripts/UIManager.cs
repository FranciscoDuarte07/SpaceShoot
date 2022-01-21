using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Sprite[] lives;
    public Image livesImageDisplay;
    public Text scoreText, bestText;
    public int score, bestScore;
    public GameObject titleScreen;

    private void Start()
    {
        //load PlayerPref data
        bestScore = PlayerPrefs.GetInt("HighScore", 0);
        bestText.text = "Best: " + bestScore;
    }

    public void UpdateLives(int currentLives)
    {
        livesImageDisplay.sprite = lives[currentLives];
    }

    public void UpdateScore()
    {
        score += 10;
        scoreText.text = "Score: " + score;
    }

    public void CheckForBestScore()
    {
        if (score > bestScore)
        {
            bestScore = score;
            //Save Scoredata
            PlayerPrefs.SetInt("HighScore", bestScore);
            bestText.text = "Best; " + bestScore;
        }
    }

    //Show tittle screen
    public void ShowTitleScreen()
    {
        titleScreen.SetActive(true);
        score = 0;
    }

    public void HideTitleScreen()
    {
        titleScreen.SetActive(false);
        scoreText.text = "Score: ";
    }
    public void ResumeGame()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.ResumeGame();
    }
    public void BackToMainManu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
