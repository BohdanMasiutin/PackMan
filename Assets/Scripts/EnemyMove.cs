using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform player;  // ������ �� ������
    public float speed = 3.0f; // �������� �������� �����

    private GameOverManager gameOverManager; // ������ �� GameOverManager

    void Start()
    {
        // ������� ������ GameOverManager �� �����
        gameOverManager = FindObjectOfType<GameOverManager>();
    }

    void Update()
    {
        // ���� ����� ����������, ���� �������� � ����
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // ���� ���� ������������ � �������
        if (collision.gameObject.CompareTag("Player"))
        {
            // �������� ���� ����
            gameOverManager.TriggerGameOver();
        }
        // ���� ���� ������������ � �����
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);  // ���������� �����
        }
    }
}




