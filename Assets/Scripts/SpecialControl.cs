using UnityEngine;

public class SpecialControl : MonoBehaviour
{
    public float baseSpeed = 5f; // base speed of the player
    public float rotationSpeed = 180f;
    public Camera mainCamera;

    private float speed; // current speed of the player (can be boosted)
    private float speedBoostFactor = 1f; // factor by which the speed is boosted (initially 1)

    private void Start()
    {
        speed = baseSpeed; // initialize the current speed to the base speed
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Rotate(0f, 0f, -horizontal * rotationSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.up * speed * Time.deltaTime;
        }

        // Locks the Camera to the Player
        mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z);
    }

    // Method to set the speed of the player
    public void SetSpeed(float newSpeed)
    {
        speed = baseSpeed * speedBoostFactor;
    }

    // Method to boost the speed of the player
    public void BoostSpeed(float boostFactor)
    {
        speedBoostFactor = boostFactor;
        speed = baseSpeed * speedBoostFactor;
    }
}
