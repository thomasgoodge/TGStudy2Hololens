using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    //Define the initial properties of the sphere, 
    public float speed = Random.Range(0.5f, 2.5f);
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        //Give the Sphere a Rigidbody that allows for collisions
        rb = this.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, -speed);
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
