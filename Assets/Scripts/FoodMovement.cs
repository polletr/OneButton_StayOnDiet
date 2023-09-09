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
    #endregion

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(targetFood);
        }
    }
}

