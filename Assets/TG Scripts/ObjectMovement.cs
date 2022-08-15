using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ObjectMovement : MonoBehaviour
{
    //Initiliase Variables that define the object movement
    [SerializeField] private float spawnSpeed = 1.0f;
    //[SerializeField] private float resetPosition = -1f;
    //private float spawnTime = 0.0f;
    //Set the destination as slightly below the Player's viewpoint
    private Vector3 destination = new Vector3(0,-0.1f,-0.15f);
    private Vector3 leftDestination = new Vector3(0.5f, -0.1f, -0.15f);
    private Vector3 rightDestination = new Vector3(-0.5f, -0.1f, -0.15f);
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Update the spawnSpeed variable to a different speed every frame
        spawnSpeed = Random.Range(0.5f, 2.5f);
        //Move the object towards the destination position 
        transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * spawnSpeed);

        /*
        if (transform.position.x >= 0.3f)
        {
            transform.position = Vector3.MoveTowards(transform.position, leftDestination, Time.deltaTime * spawnSpeed);
            Debug.Log( GameObject + "Turning left")
        }
        else if(transform.position.x <= -0.3f)
        {
            transform.position = Vector3.MoveTowards(transform.postiion, rightDestination, Time.deltaTime * spawnSpeed);
            Debug.Log( GameObject + "Turning right")
        }
        */

    }


}


        
    