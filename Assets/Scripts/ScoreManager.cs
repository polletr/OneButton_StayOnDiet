using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : Singleton<ScoreManager>
{
    [SerializeField]
    private int pointsOverTime;

    private float points;

    [SerializeField]
    private TMP_Text PointsText;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
    }

   

    // Update is called once per frame
    void Update()
    {
        points += pointsOverTime * Time.deltaTime;
        UpdatePoints();

    }

    public void AddPoints(int foodPoints)
    {
        points += foodPoints;
        UpdatePoints();
    }

    public void UpdatePoints()
    {
        PointsText.text = "    Score : " + Mathf.FloorToInt(points);
    }


}
