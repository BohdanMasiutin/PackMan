using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove1 : MonoBehaviour
{
    public CharacterController controller;  // ������ �� ��������� CharacterController
    public float speed = 6f;  // �������� ��������
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    public float jumpHeight = 2.0f;
    private float gravity = 9.81f;
    private Vector3 moveDirection = Vector3.zero;  // ������ ����������� ��������
    private float verticalVelocity = 0f;  // �������� �� ��������� (��� ������� � ����������)

    void Update()
    {
        // �������� ���� �� ������������
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // ���������� ����������� �������� �� ����������� (X, Z)
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // ���� ���� ����������� ��������
        if (direction.magnitude >= 0.1f)
        {
            // ������������ ���� �������� ��������� � ����������� �� ����������� ��������
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // ��������� �������� �� ��� X � Z
            moveDirection = direction * speed;
        }
        else
        {
            // ���� ����� ���, �� �������� �������������� ��������
            moveDirection.x = 0f;
            moveDirection.z = 0f;
        }

        // ���������, �� ����� �� ��������
        if (controller.isGrounded)
        {
            verticalVelocity = -2f;  // ������������� ��������� ������������� �������� ��� ����������� �������� � ������

            // ������, ���� �������� �� ����� � ������ ������� "Jump"
            if (Input.GetButton("Jump"))
            {
                verticalVelocity = Mathf.Sqrt(jumpHeight * 2f * gravity);  // ������������ �������� ������
            }
        }
        else
        {
            // ���� �������� �� �� �����, ��������� ����������
            verticalVelocity -= gravity * Time.deltaTime;
        }

        // ��������� ������������ �������� (���������� � ������)
        moveDirection.y = verticalVelocity;

        // ������� ��������� � ������ ���� ���� (X, Y, Z)
        controller.Move(moveDirection * Time.deltaTime);
    }
}




