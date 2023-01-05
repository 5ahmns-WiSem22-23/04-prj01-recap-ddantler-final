using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn; // the object that spawns
    public Transform[] spawnLocations; // the marked locations where you want to spawn the object
    public float spawnInterval = 9f; // the interval at which you want to spawn the object
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
            int randomIndex = Random.Range(0, spawnLocations.Length);
            Transform randomSpawnLocation = spawnLocations[randomIndex];

            spawnedObject = Instantiate(objectToSpawn, randomSpawnLocation.position, randomSpawnLocation.rotation);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}