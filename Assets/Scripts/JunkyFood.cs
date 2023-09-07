using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkyFood : MonoBehaviour
{
    public float speed = 10.0f;
    public float lowerBound = -10;

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

        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("GameOver");
        Destroy(gameObject);
    }
}
