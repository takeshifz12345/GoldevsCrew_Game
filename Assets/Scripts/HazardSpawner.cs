using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
    public GameObject hazardPrefab;
    public float spawnTime;
    public float spawnAreaA;
    public float spawnAreaB;
    public float spawnY;
    public float timer;

    public void SpawnHazard()
    {
        // Generar posición aleatoria entre los dos límites
        float randomX = Random.Range(spawnAreaA, spawnAreaB);
        Vector2 spawnPos = new Vector2(randomX, spawnY);

        // Instanciar el prefab en esa posición
        Instantiate(hazardPrefab, spawnPos, Quaternion.identity);

        Debug.Log($"Hazard generado en X: {randomX}");
    }

    void Start()
    {
        
    }

    void Update()
    {
        // Contador simple para controlar el tiempo entre spawns
        timer += Time.deltaTime;

        if (timer >= spawnTime)
        {
            SpawnHazard();
            timer = 0f;
        }
    }
}