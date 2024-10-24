using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
    float rotationX = 0f;
    float rotationY = 0f;

    public float sensitivity = 15f;

    void Update()
    {
        // ��������� ���� ���� � ����������� ������� ����
        rotationY += Input.GetAxis("Mouse X") * sensitivity;  // ���������� �� ��� Y (�����-������)
        rotationX -= Input.GetAxis("Mouse Y") * sensitivity;  // ���������� �� ��� X (�����-����)

        // ������������ ������������ �������� ������ (����� ������ �� ����������������)
        rotationX = Mathf.Clamp(rotationX, 0f, 90f);

        // ��������� �������� ������
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0f);
    }
}
