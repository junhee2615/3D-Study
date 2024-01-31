using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement2 : MonoBehaviour
{
    public float moveSpeed = 2.0f;   // ���� �̵� �ӵ�
    public float x = 54;   // ȭ�� ���� �� x��ǥ
    public float y = 1.4f;   // �ʱ� y��ǥ
    public float z = 96;   // �ʱ� z��ǥ

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ������ �̵���Ű�� ����
        // ���⿡���� ������ ���������� �̵���Ű����, ���ϴ� ����� �ӵ��� ������ �� ����
        Vector3 newPosition = transform.position + Vector3.right * moveSpeed * Time.deltaTime;
        transform.position = newPosition;

        // ���� ������ ȭ�� ������ ������ �ٽ� ���������� �̵��ϵ��� �� �� ����
        // ���� ���, ȭ�� ������ ���� �����ϸ� ������ ȭ�� ���� ������ �̵���Ű�� ������ �߰��� �� ����
        // if (transform.position.x > ȭ�� ������ �� x ��ǥ) {
        //     transform.position = new Vector3(ȭ�� ���� �� x ��ǥ, �ʱ� y ��ǥ, �ʱ� z ��ǥ);
        // }
        if (transform.position.x > 200) {
            transform.position = new Vector3(x, y, z);
        }
    }
    }
