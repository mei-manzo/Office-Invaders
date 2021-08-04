using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBound = 125;
    private float xMaxBound = 36;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < -topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < -topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x > xMaxBound)
        {
            Destroy(gameObject);
        }
    }
}
