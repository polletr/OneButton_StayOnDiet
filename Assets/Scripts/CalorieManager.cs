using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CalorieManager : Singleton<CalorieManager>
{
    [SerializeField]
    private float maxCal = 1000.0f;
    [SerializeField]
    private float minCal = 0f;
    private float currentCal;
    [SerializeField]
    private float drainRatio = 50.0f;
    private float highWarning;
    private float lowWarning;
    
    

    // Start is called before the first frame update
    void Start()
    {
        currentCal = maxCal * 0.5f;
        highWarning = maxCal * 0.8f;
        lowWarning = lowWarning * 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        currentCal -= drainRatio * Time.deltaTime;
        
        Debug.Log(currentCal);

        if (currentCal >= maxCal || currentCal <= minCal)
        {
            SceneManager.LoadSceneAsync(0);
        }
    }

    public void AddCalorie(float foodCal)
    {
        currentCal += foodCal;
    }
}
