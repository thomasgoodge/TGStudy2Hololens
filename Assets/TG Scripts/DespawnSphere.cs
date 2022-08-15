using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnSphere : MonoBehaviour
{
    // Start is called before the first frame update
 void OnCollisionEnter(Collision collision)
    {
        //Register collisions depending on the tags for the objects.
        //Play audio clip for each type of sphere. (AtPoint instead of OneShot because there are multiple different types of audio clips to play)
        if (collision.collider.tag == "Enemy")
        {
          Destroy(collision.gameObject);
        }
        else if (collision.collider.tag == "Target Sphere")
        {
            Destroy(collision.gameObject);
            //Debug.Log("Hit!");
        }

        else if (collision.collider.tag ==  "Hazard Sphere")
        {
            Destroy(collision.gameObject);
            //Debug.Log("Hit!");
        }
        // If the object hits the Wall object, destroy it    
    }
}
