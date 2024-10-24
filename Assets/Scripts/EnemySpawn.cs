using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;      // ������ �����
    public Transform[] spawnPoints;     // ����� ��� ������ ������
    public float spawnInterval = 5.0f;  // �������� ������ ������
    public int maxEnemies = 10;         // ������������ ���������� ������ �� �����

    private int currentEnemyCount = 0;  // ������� ���������� ������

    void Start()
    {
        // ��������� ����� ������ � ����������
        InvokeRepeating("SpawnEnemy", 2.0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        // ���������, ���� ������� ���������� ������ ������, ��� ������������
        if (currentEnemyCount < maxEnemies)
        {
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemyPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);
            currentEnemyCount++;  // ����������� ������� ������
        }
    }

    // ����� ��� ���������� ���������� ������ (����� ���� �������)
    public void DecreaseEnemyCount()
    {
        currentEnemyCount--;
    }
}



