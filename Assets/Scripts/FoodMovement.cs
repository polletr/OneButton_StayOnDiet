using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMovement : MonoBehaviour
{
    #region Variable Declarations
    //food speed movement
    [SerializeField]
    private float speed = 1.0f;

    /*initialDecline = I will call in this variables the curve's heighest points
      finalDecline = I will call in this variables the curve's end point
    There are 4 possible curves:

    The first one is between the spawner and the player
    The other 3 are possibilities of curve after the food hits the player's head after be rejected of him
     */
    [SerializeField]
    private float initialDecline = 2.25f;
    [SerializeField]
    private float finalDecline = 0f;
    [SerializeField]
    private float initialDecline2 = -1.65f;
    [SerializeField]
    private float finalDecline2 = -3.3f;
    [SerializeField]
    private float initialDecline3 = 1.25f;
    [SerializeField]
    private float finalDecline3 = 2.5f;
    [SerializeField]
    private float initialDecline4 = -3.0f;
    [SerializeField]
    private float finalDecline4 = -6.0f;

    public bool foodWasAccepted = false;

    //calories that will be added or subtracted from the player calories points
    [SerializeField]
    private float calories;
    //lowest scene height point, where the food will drop if the player don't eat it
    [SerializeField]
    private float lowerBound = 0.6f;
    //player's scorepoints
    [SerializeField]
    private int foodPoints;

    private int randomChoice;

    private bool headHit = false;

    private AudioSource _audioSource;

    [SerializeField]
    private AudioClip chewingClip;

    [SerializeField]
    private AudioClip splashClip;

    public GameObject targetFood;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
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
            Debug.Log("VAI AIR NO CHAO");
/*            _audioSource.clip = splashClip;
            _audioSource.Play();
*/
            Destroy(gameObject);
        }
    }

    private void InitialCurve()
    {
        #region If statement to determine the movement between the spawner and the player
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
        #endregion
    }

    private void OnTriggerEnter(Collider other)
    {
        foodWasAccepted = true;
        if (other.CompareTag("Player"))
        {
           
            CalorieManager.Instance.AddCalorie(calories);
            ScoreManager.Instance.AddPoints(foodPoints);
            Destroy(gameObject);
             _audioSource.clip = chewingClip;
             _audioSource.Play();
        }

        if (other.CompareTag("MouthClosed"))
        {
            randomChoice = Random.Range(0,3); //This variable will chose between the tree possibilities of curve movement
            headHit = true;
            Debug.Log("atingiu");
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
                    transform.Translate(Vector3.up * Time.deltaTime * speed);
                    transform.Translate(Vector3.left * Time.deltaTime * speed);
                }
                else if (transform.position.x > finalDecline2)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * speed);
                    transform.Translate(Vector3.down * Time.deltaTime * speed);
                }
                else
                {
                    transform.Translate(Vector3.down * Time.deltaTime * speed);
                }
                Debug.Log("Case 0");
                break;

            case 1:
                //Randomic movement two
                if (transform.position.x <= -initialDecline3)
                {
                    transform.Translate(Vector3.up * Time.deltaTime * speed);
                    transform.Translate(Vector3.right * Time.deltaTime * speed);  
                }
                else if (transform.position.x < -finalDecline3)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * speed);
                    transform.Translate(Vector3.down * Time.deltaTime * speed);
                }
                else
                {
                    transform.Translate(Vector3.down * Time.deltaTime * speed);
                }
                Debug.Log("Case 1");
                break;

            case 2:
                //Randomic movement tree
                if (transform.position.x <= -initialDecline4)
                {
                    transform.Translate(Vector3.up * Time.deltaTime * speed);
                    transform.Translate(Vector3.right * Time.deltaTime * speed);
                    
                }
                else if (transform.position.x < -finalDecline4)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * speed);
                    transform.Translate(Vector3.down * Time.deltaTime * speed);
                }
                else
                {
                    transform.Translate(Vector3.down * Time.deltaTime * speed);
                }
                Debug.Log("Case 2");
                break;
        }
    }
    
}

