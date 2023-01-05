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
        timer = 120f; // set the timer to 30 seconds
        gameOverPanel.SetActive(false); // hide the game over panel and the retry button at the start of the game
        retryButton.gameObject.SetActive(false);
        retryButton.onClick.AddListener(Retry); // add a listener to the retry button's onClick event
    }

    void Update()
    {
        if (timer > 0) // check if the timer has not run out
        {
            timer -= Time.deltaTime; // decrease the timer by the time elapsed since the last frame
            timerText.text = "Time: " + Mathf.RoundToInt(timer); // display the time remaining
        }
        else if (timer <= 0) // check if the timer has run out
        {
            gameOverPanel.SetActive(true); // show the game over panel
            retryButton.gameObject.SetActive(true); // show the retry button
            playerController.enabled = false; // disable the player's movement

            if (PlayerScore.score > highScore) // check if the final score is a new high score
            {
                highScore = PlayerScore.score; // set the high score to the final score
                PlayerPrefs.SetInt("highScore", highScore); // save the high score to PlayerPrefs
            }
        }
    }

    public void Retry() // method to reset the game
    {
        PlayerScore.score = 0; // reset the score
        Time.timeScale = 1; // reset the time scale
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // reload the current scene
    }
}
