using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotAirBalloon : MonoBehaviour
{
    public float floatForce = 10.0f; // 상승하는 힘
    public float maxFloatHeight = 20.0f; // 최대 높이

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent <Rigidbody>();
        rb.useGravity = false; // 중력 비활성화
    }

    void Update()
    {
        // 열기구가 최대 높이에 도달하지 않았을 때만 상승
        if (transform.position.y < maxFloatHeight)
        {
            rb.AddForce(Vector3.up * floatForce);
        }
    }
}
