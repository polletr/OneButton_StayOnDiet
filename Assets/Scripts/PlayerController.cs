using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Collider playerCollider;

    [SerializeField]
    private GameObject mouthClosed;

    private Collider headCollider;

    // Start is called before the first frame update
    void Start()
    {
        playerCollider = GetComponent<Collider>();
        headCollider = mouthClosed.GetComponent<Collider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            playerCollider.enabled = true;
            headCollider.enabled = false;
            this.gameObject.transform.localScale = new Vector3(7.0f, 7.0f, 7.0f);
        }
        else
        {
            playerCollider.enabled = false;
            headCollider.enabled = true;
            this.gameObject.transform.localScale = new Vector3(6.0f, 6.0f, 6.0f);
        }
    }
}
