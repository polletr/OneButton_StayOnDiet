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

    [SerializeField]
    private int maxLives;

    private int currentLives;

    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Start is called before the first frame update
    void Start()
    {
        currentCal = maxCal * 0.5f;
        currentLives = maxLives;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        currentCal -= drainRatio * Time.deltaTime;
        slider.value = currentCal;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        
        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < currentLives; i++)
        {
            hearts[i].sprite = fullHeart;
        }
        
        if (currentCal <= 0 || currentLives <= 0)
        {
            SceneManager.LoadSceneAsync("GameOver");
        }
    }

    public void AddCalorie(float foodCal)
    {
        currentCal += foodCal;
        if (currentCal >= maxCal)
            currentCal = maxCal;
    }

    public void IncreaseHunger(float multiplier)
    {
        drainRatio *= (1+multiplier/1000f);
    }

    public void DepleteLife()
    {
        currentLives--;
    }

}
