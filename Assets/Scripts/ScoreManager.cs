using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : Singleton<ScoreManager>
{

    [SerializeField]
    TMP_Text text;

    [SerializeField]
    private int pointsOverTime;

    private int points;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        points += Mathf.RoundToInt(pointsOverTime * Time.deltaTime);
        Debug.Log(points);

    }

    public void AddPoints(int foodPoints)
    {
        points += foodPoints;
    }
}
