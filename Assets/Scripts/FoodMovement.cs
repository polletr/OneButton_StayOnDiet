using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class FoodMovement : MonoBehaviour
{
    #region Variable Declarations
    //food speed movement
    private float speed = 1.5f;

    /*initialDecline = I will call in this variables the curve's heighest points
      finalDecline = I will call in this variables the curve's end point
    There are 4 possible curves:

    The first one is between the spawner and the player
    The other 2 are possibilities of curve after the food hits the player's head after be rejected of him
     */
    [SerializeField]
    private float initialDecline = 2.25f;
    [SerializeField]
    private float finalDecline = 0f;

    [SerializeField]
    private float initialDeclineAlt = 3.25f;
    [SerializeField]
    private float finalDeclineAlt = 1.15f;

    [SerializeField]
    private float initialDeclineAlt2 = 0f;
    [SerializeField]
    private float finalDeclineAlt2 = -2.25f;

    [SerializeField]
    private float initialDecline2 = -1.65f;
    [SerializeField]
    private float finalDecline2 = -3.3f;
    [SerializeField]
    private float initialDecline3 = 3.0f;
    [SerializeField]
    private float finalDecline3 = 6.0f;

    public bool foodWasAccepted = false;

    //calories that will be added or subtracted from the player calories points
    [SerializeField]
    private float calories;
    //lowest scene height point, where the food will drop if the player don't eat it
    private float lowerBound = 0.2f;
    //player's scorepoints
    [SerializeField]
    private int foodPoints;

    private int randomChoice;

    private bool headHit = false;

    [SerializeField]
    private bool isJunkFood;

    private AudioSource _audioSource;

    [SerializeField]
    private AudioClip chewingClip;

    [SerializeField]
    private AudioClip splashClip;

    [SerializeField]
    private AudioClip hitHeadClip;

    public GameObject targetFood;

    private GameObject background;
    private int randomChoice2;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        background = GameObject.Find("Background");
        randomChoice2 = Random.Range(0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (headHit)
        {
            RandomCurve();
        }
        else
        {
            InitialCurve();
        }
        //When the food hit the floor
        if (transform.position.y <= lowerBound)
        {
            background.GetComponent<AudioSource>().clip = splashClip;
            background.GetComponent<AudioSource>().Play();

            Destroy(gameObject);
        }
    }

    private void InitialCurve()
    {
        Debug.Log("RandomChoice2: " + randomChoice2);
        #region If statement to determine the movement between the spawner and the player
        switch (randomChoice2)
        {
            case 0:
                if (transform.position.x >= initialDecline)
                {
                    //Start the movement to the up and left side (curve movement)
                    transform.Translate(Vector3.up * Time.deltaTime * speed);
                    transform.Translate(Vector3.left * Time.deltaTime * speed);
                }
                else if (transform.position.x > finalDecline)
                {
                    //Start the movement to down and left side (curve movement)
                    transform.Translate(Vector3.left * Time.deltaTime * speed);
                    transform.Translate(Vector3.down * Time.deltaTime * speed);
                }
                else
                {
                    //Start the movement directly to the player's head (decline movement)
                    transform.Translate(Vector3.down * Time.deltaTime * speed);
                }
                break;
            case 1:
                if (transform.position.x >= initialDeclineAlt)
                {
                    //Start the movement to the up and left side (curve movement)
                    transform.Translate(Vector3.up * Time.deltaTime * speed);
                    transform.Translate(Vector3.left * Time.deltaTime * speed);
                }
                else if (transform.position.x > finalDeclineAlt)
                {
                    //Start the movement to down and left side (curve movement)
                    transform.Translate(Vector3.left * Time.deltaTime * speed);
                    transform.Translate(Vector3.down * Time.deltaTime * speed);
                }
                else
                {
                    //Start the movement directly to the player's head (decline movement)
                    transform.Translate(Vector3.down * Time.deltaTime * speed);
                }
                break;
            case 2:
                if (transform.position.x >= initialDeclineAlt2)
                {
                    //Start the movement to the up and left side (curve movement)
                    transform.Translate(Vector3.up * Time.deltaTime * speed);
                    transform.Translate(Vector3.left * Time.deltaTime * speed);
                }
                else if (transform.position.x > finalDeclineAlt2)
                {
                    //Start the movement to down and left side (curve movement)
                    transform.Translate(Vector3.left * Time.deltaTime * speed);
                    transform.Translate(Vector3.down * Time.deltaTime * speed);
                }
                else
                {
                    //Start the movement directly to the player's head (decline movement)
                    transform.Translate(Vector3.down * Time.deltaTime * speed);
                }
                break;
                #endregion
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Funcao chamada");
        foodWasAccepted = true;
        if (other.CompareTag("Player"))
        {

            CalorieManager.Instance.AddCalorie(calories);
            ScoreManager.Instance.AddPoints(foodPoints);

            if (isJunkFood)
            {
                CalorieManager.Instance.DepleteLife();
            }

            other.GetComponentInParent<AudioSource>().clip = chewingClip;
            other.GetComponentInParent<AudioSource>().Play();
            Destroy(gameObject);
        }

        if (other.CompareTag("MouthClosed"))
        {
            randomChoice = Random.Range(0, 2); //This variable will chose between the tree possibilities of curve movement
            headHit = true;

            other.GetComponentInParent<AudioSource>().clip = hitHeadClip;
            other.GetComponentInParent<AudioSource>().Play();


        }

    }
    private void RandomCurve()
    {
        switch (randomChoice)
        {
            case 0:
                //Randomic movement one
                if (transform.position.x >= initialDecline2)
                {
                    transform.Translate(Vector3.down * Time.deltaTime * speed);
                    transform.Translate(Vector3.left * Time.deltaTime * speed);
                }
                else
                {
                    transform.Translate(Vector3.down * Time.deltaTime * speed);
                }
                break;

            case 1:
                //Randomic movement two
                if (transform.position.x <= initialDecline3)
                {
                    transform.Translate(Vector3.down * Time.deltaTime * speed);
                    transform.Translate(Vector3.right * Time.deltaTime * speed);
                }
                else
                {
                    transform.Translate(Vector3.down * Time.deltaTime * speed);
                }
                break;

        }
    }

    public void IncreaseSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

}