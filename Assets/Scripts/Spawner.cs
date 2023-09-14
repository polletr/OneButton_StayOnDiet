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

    float runningTime = 0.0f;

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
        runningTime += Time.deltaTime;
    }

    public void FoodSpawn()
    {
        if (runningTime < 30.0f)
        {
            int indiceAleatorio = Random.Range(0, prefabsLevel1.Length);
            //Instantiate the target food in the spawner original position
            GameObject prefabSelecionado = prefabsLevel1[indiceAleatorio];
            Instantiate(prefabSelecionado, transform.position, Quaternion.identity);
            Debug.Log("Spawnando Array 1");
        }
        else if (runningTime < 90.0f)
        {
            int indiceAleatorio = Random.Range(0, prefabsLevel2.Length);
            //Instantiate the target food in the spawner original position
            GameObject prefabSelecionado = prefabsLevel2[indiceAleatorio];
            Instantiate(prefabSelecionado, transform.position, Quaternion.identity);
            Debug.Log("Spawnando Array 2");
        }
        else if (runningTime < 150.0f)
        {
            int indiceAleatorio = Random.Range(0, prefabsLevel3.Length);
            //Instantiate the target food in the spawner original position
            GameObject prefabSelecionado = prefabsLevel3[indiceAleatorio];
            Instantiate(prefabSelecionado, transform.position, Quaternion.identity);
            Debug.Log("Spawnando Array 3");
        }
        else if (runningTime < 210.0f)
        {
            speed = 1.5f;
            int indiceAleatorio = Random.Range(0, prefabsLevel4.Length);
            //Instantiate the target food in the spawner original position
            GameObject prefabSelecionado = prefabsLevel4[indiceAleatorio];
            Instantiate(prefabSelecionado, transform.position, Quaternion.identity);
            Debug.Log("Spawnando Array 4");
        }
        else if (runningTime > 210.0f)
        {
            speed = 2.0f
            int indiceAleatorio = Random.Range(0, prefabsLevel5.Length);
            //Instantiate the target food in the spawner original position
            GameObject prefabSelecionado = prefabsLevel5[indiceAleatorio];
            Instantiate(prefabSelecionado, transform.position, Quaternion.identity);
            Debug.Log("Spawnando Array 5");
        }
    }
}
