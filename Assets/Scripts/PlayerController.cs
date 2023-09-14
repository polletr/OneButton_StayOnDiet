using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Collider playerCollider;

    [SerializeField]
    private GameObject mouthClosed;

    private Collider headCollider;

    private float closingMouthTimer = 0f;

    bool mouthOpen = false;


    // Start is called before the first frame update
    void Start()
    {
        playerCollider = GetComponent<Collider>();
        headCollider = mouthClosed.GetComponent<Collider>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerCollider.enabled = true;
            headCollider.enabled = false;
            this.gameObject.transform.localScale = new Vector3(7.0f, 7.0f, 7.0f);
            mouthOpen = true;
        }

        if (mouthOpen)
        {
            closingMouthTimer += Time.deltaTime;
        }

        if (closingMouthTimer > 0.3f)
        {
            mouthOpen = false;
            closingMouthTimer = 0f;
            playerCollider.enabled = false;
            headCollider.enabled = true;
            this.gameObject.transform.localScale = new Vector3(6.0f, 6.0f, 6.0f);
        }
    }
}
