using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject player;      // Ссылка на игрока
    public float fallLimit = -10f; // Высота, при которой персонаж считается "упавшим"

    private bool isGameOver = false;

    void Update()
    {
        if (!isGameOver)
        {
            // Проверяем, если персонаж упал ниже определенной высоты
            if (player.transform.position.y < fallLimit)
            {
                TriggerGameOver();
            }
        }
    }

    // Функция вызова гейм овер
    public void TriggerGameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;

            // Отключаем управление игроком и всеми врагами
            PlayerMove playerMove = player.GetComponent<PlayerMove>();
            if (playerMove != null)
            {
                playerMove.enabled = false; // Отключаем управление игроком
            }

            Enemy[] enemies = FindObjectsOfType<Enemy>();
            foreach (Enemy enemy in enemies)
            {
                enemy.enabled = false; // Отключаем всех врагов
            }

            // Показываем сообщение или экран Game Over (можно добавить UI или перезагрузку уровня)
            Debug.Log("Game Over!");

            // Перезапускаем сцену через несколько секунд (опционально)
            Invoke("RestartGame", 3f);
        }
    }

    // Перезапуск сцены (опционально)
    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

