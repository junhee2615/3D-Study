using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;   // 프리팹을 연결할 변수
    public float spawnInterval = 2.0f;   // 장애물 생성 간격
    public float spawnHeight = 31.0f;   // 생성 높이

    public float nextSpawnTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 일정 간격으로 장애물 생성
        if (Time.time > nextSpawnTime)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), spawnHeight, Random.Range(-6f, 6f));
            Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
            nextSpawnTime = Time.time + spawnInterval;
        }
    }
}
