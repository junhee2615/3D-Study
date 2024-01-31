using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;   // �������� ������ ����
    public float spawnInterval = 2.0f;   // ��ֹ� ���� ����
    public float spawnHeight = 31.0f;   // ���� ����

    public float nextSpawnTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ���� �������� ��ֹ� ����
        if (Time.time > nextSpawnTime)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), spawnHeight, Random.Range(-6f, 6f));
            Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
            nextSpawnTime = Time.time + spawnInterval;
        }
    }
}
