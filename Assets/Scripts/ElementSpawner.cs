using System.Collections;
using UnityEngine;

public class ElementSpawner : MonoBehaviour
{
    public GameObject greenElementPrefab;  // Reference to the green element prefab
    public GameObject redElementPrefab;    // Reference to the red element prefab
    public Vector2 spawnAreaMin;           // Min X and Z coordinates for spawning
    public Vector2 spawnAreaMax;           // Max X and Z coordinates for spawning
    public float spawnInterval = 2f;       // Time between spawns

    void Start()
    {
        // Start spawning elements continuously
        StartCoroutine(SpawnElements());
    }

    IEnumerator SpawnElements()
    {
        while (true)
        {
            // Wait for the specified spawn interval
            yield return new WaitForSeconds(spawnInterval);

            // Randomly choose to spawn a green or red element
            GameObject elementToSpawn = Random.value > 0.5f ? greenElementPrefab : redElementPrefab;

            // Randomly choose a spawn position within the defined area
            Vector3 spawnPosition = new Vector3(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                1f,  // Adjust Y position based on the height of the element (set to the board level)
                Random.Range(spawnAreaMin.y, spawnAreaMax.y)
            );

            // Spawn the element at the chosen position
            Instantiate(elementToSpawn, spawnPosition, Quaternion.identity);
        }
    }
}
