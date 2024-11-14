using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycarcontroller : MonoBehaviour
{
    public float speedFactor = 0.5f;
    public float baseSpeed = 3f;
    public int scoreFactor = 1;
    public float lowerConstraint = -8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position - new Vector3(0f,speedFactor * baseSpeed *scoreFactor * Time.deltaTime,0f);
       

        // Set the new position
        transform.position = newPosition;

        if(transform.position.y< lowerConstraint)
        {
            Destroy(gameObject);
        }
    }
}
