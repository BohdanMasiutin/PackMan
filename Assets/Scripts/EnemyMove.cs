using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform player;  // Ссылка на игрока
    public float speed = 3.0f; // Скорость движения врага

    private GameOverManager gameOverManager; // Ссылка на GameOverManager

    void Start()
    {
        // Находим объект GameOverManager на сцене
        gameOverManager = FindObjectOfType<GameOverManager>();
    }

    void Update()
    {
        // Если игрок существует, враг движется к нему
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Если враг сталкивается с игроком
        if (collision.gameObject.CompareTag("Player"))
        {
            // Вызываем гейм овер
            gameOverManager.TriggerGameOver();
        }
        // Если враг сталкивается с пулей
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);  // Уничтожаем врага
        }
    }
}




