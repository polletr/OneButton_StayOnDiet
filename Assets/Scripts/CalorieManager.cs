using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CalorieManager : Singleton<CalorieManager>
{
    [SerializeField]
    private float maxCal = 1000.0f;
    [SerializeField]
    private float minCal = 0f;
    [SerializeField]
    private float currentCal;
    [SerializeField]
    private float drainRatio = 50.0f;
    private float highWarning;
    private float lowWarning;

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    // Start is called before the first frame update
    void Start()
    {
        currentCal = maxCal * 0.5f;
        highWarning = maxCal * 0.8f;
        lowWarning = maxCal * 0.2f;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        currentCal -= drainRatio * Time.deltaTime;
        slider.value = currentCal;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        
        
        Debug.Log(currentCal);

        if (currentCal >= maxCal || currentCal <= minCal)
        {
            Debug.Log("GameOver");
            SceneManager.LoadSceneAsync(0);
        }
    }

    public void AddCalorie(float foodCal)
    {
        currentCal += foodCal;
    }

    //public void SetHunger(float currentCal)
   // {

        //slider.value = currentCal;
    //}
        
}
