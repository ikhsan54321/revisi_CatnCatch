using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] itemPrefab;
    public float spawnInterval = 1f;

    public float minX = 6f;
    public float maxX = 41f;
    public float minY = 25f;
    public float maxY = 30f;

    private int itemsPerSpawn = 1; // Jumlah awal item per spawn
    public float increaseRate = 10f; // Setiap berapa detik jumlah spawn ditambah
    public int maxItemsPerSpawn = 10; // Batas maksimum spawn per siklus

    private void Start()
    {
        InvokeRepeating("SpawnItem", 1f, spawnInterval);
        InvokeRepeating("IncreaseSpawnCount", increaseRate, increaseRate);
    }

    void SpawnItem()
    {
        for (int i = 0; i < itemsPerSpawn; i++)
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);
            int randomIndex = Random.Range(0, itemPrefab.Length);

            Instantiate(itemPrefab[randomIndex], spawnPosition, Quaternion.identity);
        }
    }

    void IncreaseSpawnCount()
    {
        if (itemsPerSpawn < maxItemsPerSpawn)
        {
            itemsPerSpawn++;
        }
    }
}
