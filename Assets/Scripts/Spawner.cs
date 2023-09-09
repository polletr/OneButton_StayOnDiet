using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Variables Declaration
    public GameObject[] prefabs = new GameObject[10];
    public float spawnDelay = 2.0f;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        //Creation of a execution in loop considering a specific delay
        InvokeRepeating("FoodSpawn", 1, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FoodSpawn()
    {
        //Chose
        int indiceAleatorio = Random.Range(0, prefabs.Length);
        //Instantiate the target food in the spawner original position
        GameObject prefabSelecionado = prefabs[indiceAleatorio];
        Instantiate(prefabSelecionado, transform.position, Quaternion.identity);
    }
}
