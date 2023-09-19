using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    #region Variables Declaration

    private float timer = 0f;

    [SerializeField]
    private float minInterval = 0.3f;
    [SerializeField]
    private float maxInterval = 4f;

    float runningTime = 0.0f;

    public GameObject[] prefabsLevel1 = new GameObject[4];
    public GameObject[] prefabsLevel2 = new GameObject[5];
    public GameObject[] prefabsLevel3 = new GameObject[7];
    public GameObject[] prefabsLevel4 = new GameObject[9];
    public GameObject[] prefabsLevel5 = new GameObject[13];
    #endregion

    public UnityEvent<float> onIncreaseSpeed;

    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {

        _audioSource = GetComponent<AudioSource>();
        //Creation of a execution in loop considering a specific delay
        //Invoke("FoodSpawn", 1);
    }

    // Update is called once per frame
    void Update()
    {
        runningTime += Time.deltaTime;

        if (timer >= Random.Range(minInterval, maxInterval))
        {
            Invoke("FoodSpawn",0);
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    public void FoodSpawn()
    {
        _audioSource.Play();

        if (runningTime < 15.0f)
        {
            int indiceAleatorio = Random.Range(0, prefabsLevel1.Length);
            //Instantiate the target food in the spawner original position
            GameObject prefabSelecionado = prefabsLevel1[indiceAleatorio];
            Instantiate(prefabSelecionado, transform.position, Quaternion.identity);
            Debug.Log("Spawnando Array 1");
        }
        else if (runningTime < 30.0f)
        {
            int indiceAleatorio = Random.Range(0, prefabsLevel2.Length);
            //Instantiate the target food in the spawner original position
            GameObject prefabSelecionado = prefabsLevel2[indiceAleatorio];
            Instantiate(prefabSelecionado, transform.position, Quaternion.identity);
            Debug.Log("Spawnando Array 2");
        }
        else if (runningTime < 75.0f)
        {
            onIncreaseSpeed?.Invoke(2.5f);
            maxInterval = 2f;
            int indiceAleatorio = Random.Range(0, prefabsLevel3.Length);
            //Instantiate the target food in the spawner original position
            GameObject prefabSelecionado = prefabsLevel3[indiceAleatorio];
            Instantiate(prefabSelecionado, transform.position, Quaternion.identity);
            Debug.Log("Spawnando Array 3");
        }
        else if (runningTime < 100.0f)
        {
            onIncreaseSpeed?.Invoke(3f);
            maxInterval = 1.5f;
            int indiceAleatorio = Random.Range(0, prefabsLevel4.Length);
            //Instantiate the target food in the spawner original position
            GameObject prefabSelecionado = prefabsLevel4[indiceAleatorio];
            Instantiate(prefabSelecionado, transform.position, Quaternion.identity);
            Debug.Log("Spawnando Array 4");
        }
        else if (runningTime >= 100.0f)
        {
            onIncreaseSpeed?.Invoke(4f);
            maxInterval = 1f;
            int indiceAleatorio = Random.Range(0, prefabsLevel5.Length);
            //Instantiate the target food in the spawner original position
            GameObject prefabSelecionado = prefabsLevel5[indiceAleatorio];
            Instantiate(prefabSelecionado, transform.position, Quaternion.identity);
            Debug.Log("Spawnando Array 5");
        }
    }
}
