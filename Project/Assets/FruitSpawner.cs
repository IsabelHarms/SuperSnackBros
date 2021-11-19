using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject[] fruitPrefabs;
    public float spawnRangeX = 40.0f;
    public float spawnHeight = 25.0f;
    public int spawnWaitTime = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnPrefabAtRandomPos");
    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator SpawnPrefabAtRandomPos()
    {
        while (true)
        {

            var randomFruit = fruitPrefabs[Random.Range(0, fruitPrefabs.Length)];
            var randomSpawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnHeight, 0);
            Instantiate(randomFruit, randomSpawnPos, Quaternion.identity);
            yield return new WaitForSeconds(spawnWaitTime);
        }
    }
}
