using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegativeObject : MonoBehaviour
{
    public GameObject player; // Drag the player object into this field in the inspector
    public bool isCarried; // flag to track whether the item is being carried or not

    void Update()
    {
        // if the item is being carried, follow the player
        if (isCarried)
        {
            transform.position = player.transform.position;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // if the player collides with the item
        if (other.gameObject == player)
        {
            // if the player is not already carrying an item
            if (!player.GetComponent<Player>().isCarrying)
            {
                // make the item follow the player
                transform.parent = other.transform;
                isCarried = true; // set the isCarried flag to true
                player.GetComponent<Player>().isCarrying = true; // set the player's isCarrying flag to true
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // if the item is being carried by the player and they are colliding with it
        if (isCarried && other.gameObject == player)
        {
            // set the isCarried flag to false
            isCarried = false;

            // decrement the player's score by 2
            PlayerScore.score -= 2;
        }
    }
}
