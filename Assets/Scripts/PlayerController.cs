using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    private Collider playerCollider;

    [SerializeField]
    private GameObject mouthClosed;

    [SerializeField]
    private GameObject tutorialText;

    [SerializeField]
    private Transform pointA;

    [SerializeField]
    private Transform pointB;

    [SerializeField]
    private float speed;

    Vector3 target;

    private Collider headCollider;

    private float closingMouthTimer = 0f;

    bool mouthOpen = false;

    private Animator mAnimator;

    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        playerCollider = GetComponent<Collider>();
        headCollider = mouthClosed.GetComponent<Collider>();
        mAnimator = GetComponent<Animator>();

        playerCollider.enabled = false;
        target = pointA.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime; // calculate distance to move

        if(Mathf.Abs((transform.position.x - target.x)) <= 1f && target == pointA.position)
        {
            target = pointB.transform.position;
        }
        else if(Mathf.Abs((transform.position.x - target.x)) <= 1f && target == pointB.position)
        {
            target = pointA.transform.position;
        }


        if (mouthOpen)
        {
            closingMouthTimer += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
                tutorialText.SetActive(false);
                playerCollider.enabled = true;
                headCollider.enabled = false;
                mAnimator.SetTrigger("Eating");
                mouthOpen = true;
        }



        if (Input.GetKey(KeyCode.Space) && !mouthOpen)
        {
            float direction = Mathf.Sign(target.x - transform.position.x);
            Vector2 MovePos = new Vector2(transform.position.x + direction * step, transform.position.y);
            transform.position = MovePos;
        }

        if (closingMouthTimer > 0.3f)
        {
            mouthOpen = false;
            closingMouthTimer = 0f;
            playerCollider.enabled = false;
            headCollider.enabled = true;
        }
    }
}
