using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;      // Префаб врага
    public Transform[] spawnPoints;     // Точки для спавна врагов
    public float spawnInterval = 5.0f;  // Интервал спавна врагов
    public int maxEnemies = 10;         // Максимальное количество врагов на сцене

    private int currentEnemyCount = 0;  // Текущее количество врагов

    void Start()
    {
        // Запускаем спавн врагов с интервалом
        InvokeRepeating("SpawnEnemy", 2.0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        // Проверяем, если текущее количество врагов меньше, чем максимальное
        if (currentEnemyCount < maxEnemies)
        {
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemyPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);
            currentEnemyCount++;  // Увеличиваем счетчик врагов
        }
    }

    // Метод для уменьшения количества врагов (когда враг умирает)
    public void DecreaseEnemyCount()
    {
        currentEnemyCount--;
    }
}



