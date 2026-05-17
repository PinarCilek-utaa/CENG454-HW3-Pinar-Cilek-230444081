using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawner Ayarları")]
    public GameObject enemyPrefab;   
    public Transform coreTarget;     
    public float spawnRadius = 40f;  
    public float spawnInterval = 3f; 

    private float nextSpawnTime = 0f;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefab != null && coreTarget != null)
        {
            float randomAngle = Random.Range(0f, 360f);
            float spawnX = coreTarget.position.x + Mathf.Sin(randomAngle * Mathf.Deg2Rad) * spawnRadius;
            float spawnZ = coreTarget.position.z + Mathf.Cos(randomAngle * Mathf.Deg2Rad) * spawnRadius;

            Vector3 spawnPosition = new Vector3(spawnX, 5f, spawnZ);
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            AlienEnemy alienScript = newEnemy.GetComponent<AlienEnemy>();
            if (alienScript != null)
            {
                alienScript.coreTarget = coreTarget;
                alienScript.useZigZagStrategy = (Random.value > 0.5f); 
            }
        }
    }
}