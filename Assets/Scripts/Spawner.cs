using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Variables Declaration
    
    [SerializeField]
    private float minInterval = 1.0f;
    [SerializeField]
    private float maxInterval = 2.5f;

    public GameObject[] prefabs = new GameObject[10];
    #endregion
 
    // Start is called before the first frame update
    void Start()
    {
        //Creation of a execution in loop considering a specific delay
        InvokeRepeating("FoodSpawn", 1, Random.Range(minInterval, maxInterval));
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
