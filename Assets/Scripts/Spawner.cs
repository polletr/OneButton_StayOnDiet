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
    public NextFoodDisplay nextFoodDisplay;

    private AudioSource _audioSource;

    private GameObject nextPrefab;
    private float timerRange;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        timerRange = Random.Range(minInterval, maxInterval);
    }

    // Update is called once per frame
    void Update()
    {
        runningTime += Time.deltaTime;

        if (timer >= timerRange)
        {
            // Get the next food prefab without instantiating it
            nextPrefab = GetNextFoodPrefab();

            // Check if nextPrefab is not null before attempting to access its SpriteRenderer
            if (nextPrefab != null)
            {
                // Set the next food sprite in the UI using the nextPrefab
                nextFoodDisplay.SetNextFoodSprite(nextPrefab.GetComponent<SpriteRenderer>().sprite);

                // Call the FoodSpawn method with the nextPrefab
                FoodSpawn(nextPrefab);

                timer = 0;
                timerRange = Random.Range(minInterval, maxInterval);
            }
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    public void FoodSpawn(GameObject prefab)
    {
        _audioSource.Play();

        // Your existing spawning logic here
        // ...

        // Instantiate the target food in the spawner original position
        Instantiate(prefab, transform.position, Quaternion.identity);

        // Additional logic if needed
        // ...
    }

    private GameObject GetNextFoodPrefab()
    {
        GameObject prefabSelecionado = null;

        if (runningTime < 15.0f)
        {
            int indiceAleatorio = Random.Range(0, prefabsLevel1.Length);
            prefabSelecionado = prefabsLevel1[indiceAleatorio];
        }
        else if (runningTime < 30.0f)
        {
            int indiceAleatorio = Random.Range(0, prefabsLevel2.Length);
            prefabSelecionado = prefabsLevel2[indiceAleatorio];
        }
        else if (runningTime < 75.0f)
        {
            prefabSelecionado = GetPrefabAndIncreaseSpeed(prefabsLevel3, 2.5f, 2f);
        }
        else if (runningTime < 100.0f)
        {
            prefabSelecionado = GetPrefabAndIncreaseSpeed(prefabsLevel4, 3f, 1.5f);
        }
        else if (runningTime >= 100.0f)
        {
            prefabSelecionado = GetPrefabAndIncreaseSpeed(prefabsLevel5, 4f, 1f);
        }

        return prefabSelecionado;
    }

    private GameObject GetPrefabAndIncreaseSpeed(GameObject[] prefabs, float speedIncrease, float newMaxInterval)
    {
        onIncreaseSpeed?.Invoke(speedIncrease);
        maxInterval = newMaxInterval;
        int indiceAleatorio = Random.Range(0, prefabs.Length);
        return prefabs[indiceAleatorio];
    }
}
