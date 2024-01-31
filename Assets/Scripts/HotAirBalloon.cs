using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotAirBalloon : MonoBehaviour
{
    public float floatForce = 10.0f; // ����ϴ� ��
    public float maxFloatHeight = 20.0f; // �ִ� ����

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent <Rigidbody>();
        rb.useGravity = false; // �߷� ��Ȱ��ȭ
    }

    void Update()
    {
        // ���ⱸ�� �ִ� ���̿� �������� �ʾ��� ���� ���
        if (transform.position.y < maxFloatHeight)
        {
            rb.AddForce(Vector3.up * floatForce);
        }
    }
}
