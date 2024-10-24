using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove1 : MonoBehaviour
{
    public CharacterController controller;  // Ссылка на компонент CharacterController
    public float speed = 6f;  // Скорость движения
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    public float jumpHeight = 2.0f;
    private float gravity = 9.81f;
    private Vector3 moveDirection = Vector3.zero;  // Вектор направления движения
    private float verticalVelocity = 0f;  // Скорость по вертикали (для прыжков и гравитации)

    void Update()
    {
        // Получаем ввод от пользователя
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Определяем направление движения по горизонтали (X, Z)
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // Если есть направление движения
        if (direction.magnitude >= 0.1f)
        {
            // Рассчитываем угол поворота персонажа в зависимости от направления движения
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Применяем движение по оси X и Z
            moveDirection = direction * speed;
        }
        else
        {
            // Если ввода нет, то обнуляем горизонтальное движение
            moveDirection.x = 0f;
            moveDirection.z = 0f;
        }

        // Проверяем, на земле ли персонаж
        if (controller.isGrounded)
        {
            verticalVelocity = -2f;  // Устанавливаем небольшое отрицательное значение для устойчивого контакта с землей

            // Прыжок, если персонаж на земле и нажата клавиша "Jump"
            if (Input.GetButton("Jump"))
            {
                verticalVelocity = Mathf.Sqrt(jumpHeight * 2f * gravity);  // Рассчитываем скорость прыжка
            }
        }
        else
        {
            // Если персонаж не на земле, применяем гравитацию
            verticalVelocity -= gravity * Time.deltaTime;
        }

        // Применяем вертикальное движение (гравитация и прыжок)
        moveDirection.y = verticalVelocity;

        // Двигаем персонажа с учетом всех осей (X, Y, Z)
        controller.Move(moveDirection * Time.deltaTime);
    }
}




