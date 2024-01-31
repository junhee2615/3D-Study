using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement2 : MonoBehaviour
{
    public float moveSpeed = 2.0f;   // 구름 이동 속도
    public float x = 54;   // 화면 왼쪽 끝 x좌표
    public float y = 1.4f;   // 초기 y좌표
    public float z = 96;   // 초기 z좌표

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 구름을 이동시키는 로직
        // 여기에서는 구름을 오른쪽으로 이동시키지만, 원하는 방향과 속도로 수정할 수 있음
        Vector3 newPosition = transform.position + Vector3.right * moveSpeed * Time.deltaTime;
        transform.position = newPosition;

        // 만약 구름이 화면 밖으로 나가면 다시 시작점으로 이동하도록 할 수 있음
        // 예를 들어, 화면 오른쪽 끝에 도달하면 구름을 화면 왼쪽 끝으로 이동시키는 로직을 추가할 수 있음
        // if (transform.position.x > 화면 오른쪽 끝 x 좌표) {
        //     transform.position = new Vector3(화면 왼쪽 끝 x 좌표, 초기 y 좌표, 초기 z 좌표);
        // }
        if (transform.position.x > 200) {
            transform.position = new Vector3(x, y, z);
        }
    }
    }
