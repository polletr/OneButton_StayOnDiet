using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Collider playerCollider;
    

    // Start is called before the first frame update
    void Start()
    {
        playerCollider = GetComponent<Collider>();
     
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            playerCollider.enabled = true;
            this.gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        else
        {
            playerCollider.enabled = false;
            this.gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }
}
