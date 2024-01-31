using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject ItemPrefab;   // 프리팹을 연결할 변수
    public float spawnInterval = 2.0f;   // 아이템 생성 간격
    public float spawnHeight = 31.0f;   // 생성 높이
    public float itemLifetime = 2.0f;   // 아이템의 수명(2초로 설정)

    public float nextSpawnTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 일정 간격으로 아이템 생성
        if (Time.time > nextSpawnTime)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), spawnHeight, Random.Range(-6f, 6f));
            GameObject spawnedItem = Instantiate(ItemPrefab, spawnPosition, Quaternion.identity);
            // 아이템 생성 후 일정 시간(아이템 수명)이 지나면 자동으로 제거
            Destroy(spawnedItem, itemLifetime);
            nextSpawnTime = Time.time + spawnInterval;
        }
    }
}
