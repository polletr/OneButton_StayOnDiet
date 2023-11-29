using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
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

    Vector2 positionA = new Vector2(-2.5f, 0f);
    Vector2 positionB = new Vector2(2.5f, 0f);

    [SerializeField]
    private float leftCurve = -1.3f;
    [SerializeField]
    private float rightCurve = 3.0f;

    float currentPosition = 0f;
    bool shooting = false;

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

    private float totalDistance;

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

    private ParticleSystem particleSys;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        float xA = positionA.x;
        float yA = positionA.y;

        float xB = positionB.x;
        float yB = positionB.y;

        particleSys = GetComponent<ParticleSystem>();
        background = GameObject.Find("Background");

        if (isJunkFood)
        {
            particleSys.startColor = Color.red;
        }
        else
        {
            particleSys.startColor = Color.green;
        }
        particleSys.Play();

        totalDistance = Random.Range(positionA.x, positionB.x);


        // Definir destino aleatório entre PointA e PointB
        //Vector3 randomDestination = new Vector3(Random.Range(xA, xB), Random.Range(yA, yB), 0f);
        // Calcular altura e distância total para o movimento parabólico
        //CalculateParabolicValues(randomDestination);
    }


    void Update()
    {


        if (headHit)
        {
            Debug.Log("Bateu na cabeca do personagem");
            RandomCurve();
        }
        else
        {
            Debug.Log("Movimento Parabolico iniciado");
            currentPosition += Time.deltaTime / 2.0f;
            this.transform.localPosition = new Vector3(totalDistance / 2.0f + currentPosition * totalDistance / 2.0f, 10f - Mathf.Pow(currentPosition, 2.0f) * 10f, 0.0f);
            Debug.LogFormat("Current position is {0}, {1}", currentPosition, this.transform.localPosition.y);
        }

        if (transform.position.y <= lowerBound)
        {
            background.GetComponent<AudioSource>().clip = splashClip;
            background.GetComponent<AudioSource>().Play();

            Destroy(gameObject);
            Debug.Log("Food Destroyed");
        }
    }

/*    void CalculateParabolicValues(Vector3 destination)
    {
        // Calcular altura e distância total para o movimento parabólico
        float deltaY = destination.y - 6f;
        float deltaX = destination.x - 4f;
        totalHeight = Mathf.Max(deltaY, 8.5f); // Maximum Height Peak
        Debug.Log(totalHeight);
        totalDistance = Mathf.Abs(deltaX);
    }
*/
    void OnTriggerEnter(Collider other)
    {
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
            randomChoice = Random.Range(0, 2);
            headHit = true;

            other.GetComponentInParent<AudioSource>().clip = hitHeadClip;
            other.GetComponentInParent<AudioSource>().Play();
        }
    }

    void RandomCurve()
    {
        switch (randomChoice)
        {
            case 0:
                if (transform.position.x >= leftCurve)
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
                if (transform.position.x <= rightCurve)
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