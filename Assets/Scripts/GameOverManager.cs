using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject player;      // ������ �� ������
    public float fallLimit = -10f; // ������, ��� ������� �������� ��������� "�������"

    private bool isGameOver = false;

    void Update()
    {
        if (!isGameOver)
        {
            // ���������, ���� �������� ���� ���� ������������ ������
            if (player.transform.position.y < fallLimit)
            {
                TriggerGameOver();
            }
        }
    }

    // ������� ������ ���� ����
    public void TriggerGameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;

            // ��������� ���������� ������� � ����� �������
            PlayerMove playerMove = player.GetComponent<PlayerMove>();
            if (playerMove != null)
            {
                playerMove.enabled = false; // ��������� ���������� �������
            }

            Enemy[] enemies = FindObjectsOfType<Enemy>();
            foreach (Enemy enemy in enemies)
            {
                enemy.enabled = false; // ��������� ���� ������
            }

            // ���������� ��������� ��� ����� Game Over (����� �������� UI ��� ������������ ������)
            Debug.Log("Game Over!");

            // ������������� ����� ����� ��������� ������ (�����������)
            Invoke("RestartGame", 3f);
        }
    }

    // ���������� ����� (�����������)
    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

