using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public static int highScore; // static variable to hold the high score
    public TextMeshProUGUI timerText; // TextMesh Pro UI element to display the timer
    public GameObject gameOverPanel; // reference to the game over panel game object
    public Button retryButton; // reference to the retry button
    public SpecialControl playerController; // reference to the player's SpecialControl script

    private float timer; // variable to track the time remaining

    void Start()
    {
        timer = 120f; 
        gameOverPanel.SetActive(false); 
        retryButton.gameObject.SetActive(false);
        retryButton.onClick.AddListener(Retry); 
    }

    void Update()
    {
        if (timer > 0) 
        {
            timer -= Time.deltaTime; 
            timerText.text = "Time: " + Mathf.RoundToInt(timer); 
        }
        else if (timer <= 0) // check if the timer has run out
        {
            gameOverPanel.SetActive(true);
            retryButton.gameObject.SetActive(true); 
            playerController.enabled = false; 

            if (PlayerScore.score > highScore) 
            {
                highScore = PlayerScore.score; 
                PlayerPrefs.SetInt("highScore", highScore); 
            }
        }
    }

    public void Retry() // method to reset the game
    {
        PlayerScore.score = 0; // reset the score
        Time.timeScale = 1; // reset the time scale
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}
