using System.Collections;
using UnityEngine;

public class BadSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // the object that spawns
    public Transform[] spawnLocations; // the marked locations where you want to spawn the object
    public float spawnInterval = 15f; // the interval at which you want to spawn the object
    public Transform collector; // the object where the gifts are collected and stored
    public bool isCarrying; // flag to track whether the player is carrying a gift or not

    GameObject spawnedObject; // the spawned object that the player can collect and store

    void Start()
    {
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        while (true)
        {
            // choose a random spawn location
            int randomIndex = Random.Range(0, spawnLocations.Length);
            Transform randomSpawnLocation = spawnLocations[randomIndex];

            // spawn the object at the random location
            spawnedObject = Instantiate(objectToSpawn, randomSpawnLocation.position, randomSpawnLocation.rotation);

            // wait for the specified interval before spawning the next object
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}