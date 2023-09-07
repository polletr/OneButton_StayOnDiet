using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] foodPrefabs;
    public float spawnInterval = 2.0f;
    private float spawnPosX = 0;
    private float spawnPosY = 6;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomFruits", 1, spawnInterval);
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
