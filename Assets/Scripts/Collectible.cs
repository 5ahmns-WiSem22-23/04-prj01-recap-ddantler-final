using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameObject player; // Drag the player object into this field in the inspector
    public GameObject collector; // Drag the collector object into this field in the inspector
    public GameObject desiredCollectible; // Drag the desired collectible object into this field in the inspector
    public bool isCarried; // flag to track whether the item is being carried or not

    void Update()
    {
        // if the item is being carried, follow the player
        if (isCarried)
        {
            transform.position = player.transform.position;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // if the player collides with the item
        if (other.gameObject == player)
        {
            // if the player is not already carrying an item
            if (!player.GetComponent<Player>().isCarrying)
            {
                // if the player is picking up a different collectible than the desired one
                if (gameObject != desiredCollectible)
                {
                    // destroy the collectible
                    Destroy(gameObject);

                    // subtract 2 points from the player's score
                    PlayerScore.score -= 2;
                }
                else
                {
                    // make the item follow the player
                    transform.parent = other.transform;
                    isCarried = true; // set the isCarried flag to true
                    player.GetComponent<Player>().isCarrying = true; // set the player's isCarrying flag to true
                }
            }
        }
        // if the player collides with the collector
        else if (other.gameObject == collector)
        {
            // if the player is carrying an item
            if (player.GetComponent<Player>().isCarrying)

                
                if (gameObject == desiredCollectible)
            {
                // add 1 point to the player's score
                PlayerScore.score++;
            }

            
            {
                // if the player is carrying a different collectible than the desired one
                if (gameObject != desiredCollectible)
                {
                    // add 1 point to the player's score
                    PlayerScore.score++;
                }

                // destroy the item
                Destroy(gameObject);

                // set the player's isCarrying flag to false
                player.GetComponent<Player>().isCarrying = false;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // if the item is being carried by the player and they are colliding with it
        if (isCarried && other.gameObject == player)
        {
            // set the isCarried flag to false
            isCarried = false;
        }
    }
}
