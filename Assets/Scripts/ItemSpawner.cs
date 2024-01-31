using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject ItemPrefab;   // �������� ������ ����
    public float spawnInterval = 2.0f;   // ������ ���� ����
    public float spawnHeight = 31.0f;   // ���� ����
    public float itemLifetime = 2.0f;   // �������� ����(2�ʷ� ����)

    public float nextSpawnTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ���� �������� ������ ����
        if (Time.time > nextSpawnTime)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), spawnHeight, Random.Range(-6f, 6f));
            GameObject spawnedItem = Instantiate(ItemPrefab, spawnPosition, Quaternion.identity);
            // ������ ���� �� ���� �ð�(������ ����)�� ������ �ڵ����� ����
            Destroy(spawnedItem, itemLifetime);
            nextSpawnTime = Time.time + spawnInterval;
        }
    }
}
