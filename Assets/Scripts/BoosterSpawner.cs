using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterSpawner : MonoBehaviour
{
    public GameObject itemPrefab; // drag the prefab for the item you want to spawn into this field in the Inspector
    public List<Transform> spawnPoints; // drag the empty GameObjects that you want to use as spawn points into this list in the Inspector
    public float spawnInterval = 20f; // interval between each spawn in seconds
    private float timeSinceLastSpawn = 0f; // time elapsed since the last spawn

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime; // increase time elapsed since last spawn by the amount of time that has passed since the last frame

        // check if it's time to spawn an item
        if (timeSinceLastSpawn >= spawnInterval)
        {
            timeSinceLastSpawn = 0f; // reset time since last spawn

            // choose a random spawn point
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];

            // spawn an item at the chosen spawn point
            Instantiate(itemPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
