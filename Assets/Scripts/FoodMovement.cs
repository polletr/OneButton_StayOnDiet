using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMovement : MonoBehaviour
{
    #region Variable Declarations
    public float speed = 2.0f;
    public GameObject targetFood;
    public float initialDecline = 2.25f;
    public float finalDecline = 0f;
    public bool isCurving = true;
    public int calories = 0;
    public float lowerBound = -10;
    [SerializeField]
    private int foodPoints;
    #endregion

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < lowerBound)
        {

            Destroy(gameObject);
        }
        #region If statement to determine the movement between the spawner and the player
        if (transform.position.x >= initialDecline)
        {
            //Start the movement to the up and left side (curve movement)
            transform.Translate(Vector3.up * Time.deltaTime * speed);
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            isCurving = true;
        }
        else if (transform.position.x > finalDecline)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
        else
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
            isCurving = false;
        }
        #endregion
    }
    private void OnTriggerEnter(Collider other)
    {
        CalorieManager.Instance.AddCalorie(calories);
        ScoreManager.Instance.AddPoints(foodPoints);
        Destroy(gameObject);
    }
}

