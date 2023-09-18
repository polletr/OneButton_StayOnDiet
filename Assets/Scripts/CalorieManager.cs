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

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    // Start is called before the first frame update
    void Start()
    {
        currentCal = maxCal * 0.5f;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        currentCal -= drainRatio * Time.deltaTime;
        slider.value = currentCal;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        
        
        if (currentCal >= maxCal || currentCal <= minCal)
        {
            SceneManager.LoadSceneAsync(2);
        }
    }

    public void AddCalorie(float foodCal)
    {
        currentCal += foodCal;
    }

    public void IncreaseHunger(float multiplier)
    {
        drainRatio *= (1+multiplier/1000f);
    }
        
}
