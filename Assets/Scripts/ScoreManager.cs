using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : Singleton<ScoreManager>
{
    [SerializeField]
    private int pointsOverTime;

    private int points;
    private int highScore;
    private float fractionalPoints;

    [SerializeField]
    private TMP_Text PointsText;

    [SerializeField]
    private TMP_Text HighScoreText;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        fractionalPoints = 0f;
        UpdateHighScoreText();
    }

   

    // Update is called once per frame
    void Update()
    {
        // Increase points over time with fractional accumulation
        fractionalPoints += pointsOverTime * Time.deltaTime;

        // Check if fractionalPoints reached a whole number
        if (fractionalPoints >= 1f)
        {
            int wholePoints = Mathf.FloorToInt(fractionalPoints);
            points += wholePoints;
            fractionalPoints -= wholePoints; // Remove the added whole points
        }

        // Update points text
        UpdatePoints();

        // Store HighScore on the local machine;
        PlayerPrefs.SetInt("HighScore", points);
        PlayerPrefs.GetInt("HighScore");

        // Check and update high score
        CheckHighScore();
    }

    public void AddPoints(int foodPoints)
    {
        points += foodPoints;
        UpdatePoints();
    }

    public void UpdatePoints()
    {
        PointsText.text = "Score : " + points;
    }

    void CheckHighScore()
    {
        if(points > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", points);
            UpdateHighScoreText();
        }
    }

    void UpdateHighScoreText()
    {
        HighScoreText.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", 0)}";
    }

}
