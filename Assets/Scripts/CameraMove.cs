using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
    float rotationX = 0f;
    float rotationY = 0f;

    public float sensitivity = 15f;

    void Update()
    {
        // Считываем ввод мыши с правильными именами осей
        rotationY += Input.GetAxis("Mouse X") * sensitivity;  // Управление по оси Y (влево-вправо)
        rotationX -= Input.GetAxis("Mouse Y") * sensitivity;  // Управление по оси X (вверх-вниз)

        // Ограничиваем вертикальное вращение камеры (чтобы камера не переворачивалась)
        rotationX = Mathf.Clamp(rotationX, 0f, 90f);

        // Применяем вращение камеры
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0f);
    }
}
