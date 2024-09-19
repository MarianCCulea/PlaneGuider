using System.Collections;
using UnityEngine;

public class SpawnThunder : MonoBehaviour
{
    [SerializeField] GameObject spawnThunderPrefab;
    [SerializeField] Vector2[] spawnPoints;
    [SerializeField] float timeBetweenSpawns;
    
    // Total number of objects to spawn
    public int totalObjectsToSpawn = 10;
    
    // A seed for the noise function to ensure different results
    public float noiseOffset = 0.5f;
    
    // [{x:23,y:32},{}] Locations
    // Random number / Noise -> pick location -> spawn thunder
    
    void Start()
    {
        StartCoroutine(SpawnThunderWithNoise());
    }

    IEnumerator SpawnThunderWithNoise()
    {
        for (int i = 0; i < totalObjectsToSpawn; i++)
        {
            
            // Use Perlin noise to smoothly transition between locations
            float noiseValue = Mathf.PerlinNoise(i * noiseOffset, 0);

            // Scale the noise value to the range of the spawnPoints array
            int index = Mathf.FloorToInt(noiseValue * spawnPoints.Length);

            // Ensure index doesn't go out of bounds
            index = Mathf.Clamp(index, 0, spawnPoints.Length - 1);
            
            int wanted = Random.Range(0, spawnPoints.Length - 1);
            
            GameObject spawnedObject = Instantiate(spawnThunderPrefab, spawnPoints[wanted], Quaternion.Euler(new Vector3(90f, 90f, -90f)));

            Instantiate(spawnThunderPrefab, spawnPoints[wanted], Quaternion.identity);
            
            // Destroy the object after 10 seconds
            Destroy(spawnedObject, 5);

            // Wait for the specified delay before spawning the next object
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }
}
