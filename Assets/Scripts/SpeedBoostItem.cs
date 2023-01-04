using System.Collections;
using UnityEngine;

public class SpeedBoostItem : MonoBehaviour
{
    public float speedBoostDuration = 3f; // duration of the speed boost in seconds
    public float speedBoostFactor = 2f; // factor by which the speed is boosted

    // reference to the player's SpecialControl script
    private SpecialControl specialControl;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // get a reference to the player's SpecialControl script
            specialControl = other.GetComponent<SpecialControl>();

            // boost the player's speed
            specialControl.BoostSpeed(speedBoostFactor);

            // start the speed boost timer
            StartCoroutine(StartSpeedBoostTimer());

            // destroy the power-up game object
            Destroy(gameObject);
        }
    }

    private IEnumerator StartSpeedBoostTimer()
    {
        float timeRemaining = speedBoostDuration;
        while (timeRemaining > 0)
        {
            // decrease the time remaining by the amount of time that has passed since the last frame
            timeRemaining -= Time.deltaTime;

            yield return null;
        }

        // reset the player's speed
        specialControl.SetSpeed(specialControl.baseSpeed);
    }
}
