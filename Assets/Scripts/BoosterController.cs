using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterController : MonoBehaviour
{
    public float speed = 5.0f; // the speed at which the player moves

    // Update is called once per frame
    void Update()
    {
        // get the horizontal and vertical input values
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // calculate the movement vector
        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);

        // move the player
        transform.position += movement * speed * Time.deltaTime;
    }
}
