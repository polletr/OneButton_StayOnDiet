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
        

        //prefabs[0] = Resources.Load<GameObject>("Assets/Resources/Prefabs/Apple.prefab");
        //prefabs[1] = Resources.Load<GameObject>("Assets/Resources/Prefabs/Avocado.prefab");
        //prefabs[2] = Resources.Load<GameObject>("Assets/Resources/Prefabs/Cherry.prefab");
        //prefabs[3] = Resources.Load<GameObject>("Assets/Resources/Prefabs/PieApple.prefab");
        //prefabs[4] = Resources.Load<GameObject>("Assets/Resources/Prefabs/EggPlant.prefab");
        //prefabs[5] = Resources.Load<GameObject>("Assets/Resources/Prefabs/Whiskey.prefab");
        //prefabs[6] = Resources.Load<GameObject>("Assets/Resources/Prefabs/Sausages.prefab");
        //prefabs[7] = Resources.Load<GameObject>("Assets/Resources/Prefabs/DragonFruit.prefab");
        //prefabs[8] = Resources.Load<GameObject>("Assets/Resources/Prefabs/Beer.prefab");
        //prefabs[9] = Resources.Load<GameObject>("Assets/Resources/Prefabs/Roll.prefab");

        
        //Creation of a execution in loop considering a specific delay
        InvokeRepeating("FoodSpawn", 1, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FoodSpawn()
    {
        int indiceAleatorio = Random.Range(0, prefabs.Length);
        //Instantiate the target food in the spawner original position
        GameObject prefabSelecionado = prefabs[indiceAleatorio];
        Instantiate(prefabSelecionado, transform.position, Quaternion.identity);
    }
}
