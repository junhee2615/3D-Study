using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public float minHeight = 0f;   // ü���� ���ҽ�ų ���� ����
    private bool isHealthDecreased = false;   // �̹� ü���� ���ҵǾ������� ��Ÿ���� �÷���
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // ��ֹ��� �¾Ҵٸ�
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("��ֹ��� ����");
            GameMng.inst.SubHealth(10);   // �÷��̾��� ü�� 10 ����
        }

        if (collision.gameObject.tag == "Food")
        {
            Debug.Log("����� ����");
            GameMng.inst.AddHealth(10);   // �÷��̾��� ü�� 10 ����
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            Debug.Log("������ ȹ��");
            GameMng.inst.CollectItem();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < minHeight && !isHealthDecreased)
        {
            isHealthDecreased = true; // ü���� �� ���� �����ϵ��� �÷��� ����
            GameMng.inst.SubHealth(100); // �÷��̾��� ü�� 100 ����
        }
    }
}
