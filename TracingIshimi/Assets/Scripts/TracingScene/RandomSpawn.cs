using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public List<GameObject> obstaclePrefabs;
    public float spawnInterval = 1f; //리스폰 되는 간격 = range로 랜덤값 부여할 예정
    public float spawnDuration = 6f; // 삭제되기까지의 시간
    private float timeSinceLastSpew = 4f;//리스폰 되고 나서 얼마나 흘렀는지
    private Vector3 spawnPostion;
    private GameObject spawnedPrefabs;

    public GameObject falling;

    private bool isTimetoRespawn = true;
    private void Update()
    {
        timeSinceLastSpew += Time.deltaTime;

        if (isTimetoRespawn)
        {
            isTimetoRespawn = false;
            //obstacle initiaite하는 함수 
            spawnObstacle();
            timeSinceLastSpew = 0f;
        }
        else if (timeSinceLastSpew >= spawnInterval)
        {
            isTimetoRespawn = true;
        }
    }


    void spawnObstacle()
    {
        spawnInterval = Random.Range(0.9f, 2f);
        int randomIndex = Random.Range(0, obstaclePrefabs.Count);
        spawnPostion = (randomIndex == 1) ? new Vector3(12, -3, 0) : new Vector3(12, -2, 0);
        spawnedPrefabs = Instantiate(obstaclePrefabs[randomIndex], spawnPostion, Quaternion.identity);
    }
}