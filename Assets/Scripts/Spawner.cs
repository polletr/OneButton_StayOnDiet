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

    public GameObject[] prefabsLevel1 = new GameObject[4];
    public GameObject[] prefabsLevel2 = new GameObject[5];
    public GameObject[] prefabsLevel3 = new GameObject[7];
    public GameObject[] prefabsLevel4 = new GameObject[9];
    public GameObject[] prefabsLevel5 = new GameObject[13];
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
        int indiceAleatorio = Random.Range(0, prefabsLevel1.Length);
        //Instantiate the target food in the spawner original position
        GameObject prefabSelecionado = prefabsLevel1[indiceAleatorio];
        Instantiate(prefabSelecionado, transform.position, Quaternion.identity);
    }
}
