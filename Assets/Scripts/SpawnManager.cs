using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] foodPrefabs;
    public float minInterval = 1.0f;
    public float maxInterval = 2.5f;
    private float spawnPosX = 0;
    private float spawnPosY = 10;

    // Start is called before the first frame update
    void Start()
    {
        // Invoke the SpawnRandomFruits method with a random initial interval
        InvokeRepeating("SpawnRandomFruits", 1, Random.Range(minInterval, maxInterval));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomFruits()
    {

        int fruitIndex = Random.Range(0, foodPrefabs.Length);
        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, 0);

        Instantiate(foodPrefabs[fruitIndex], spawnPos, foodPrefabs[fruitIndex].transform.rotation);
    }
}
