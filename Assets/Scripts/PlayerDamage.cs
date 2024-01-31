using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public float minHeight = 0f;   // 체력을 감소시킬 최저 높이
    private bool isHealthDecreased = false;   // 이미 체력이 감소되었는지를 나타내는 플래그
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 장애물에 맞았다면
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("장애물에 맞음");
            GameMng.inst.SubHealth(10);   // 플레이어의 체력 10 감소
        }

        if (collision.gameObject.tag == "Food")
        {
            Debug.Log("사과에 맞음");
            GameMng.inst.AddHealth(10);   // 플레이어의 체력 10 증가
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            Debug.Log("아이템 획득");
            GameMng.inst.CollectItem();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < minHeight && !isHealthDecreased)
        {
            isHealthDecreased = true; // 체력이 한 번만 감소하도록 플래그 설정
            GameMng.inst.SubHealth(100); // 플레이어의 체력 100 감소
        }
    }
}
