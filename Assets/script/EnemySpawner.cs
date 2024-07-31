using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab del enemigo
    public Transform[] spawnPoints; // Puntos de aparición
    public float spawnInterval = 2f; // Intervalo de aparición en segundos

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnInterval, spawnInterval);
    }

    void SpawnEnemy()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
