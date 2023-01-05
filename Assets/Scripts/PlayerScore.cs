using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    public static int score; // static variable to hold the player's score
    public TextMeshProUGUI scoreText; // TextMesh Pro UI element to display the score

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        scoreText.text = "Score: " + score;
    }
}
