using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetMesh : MonoBehaviour
{
    //Define the default position for the Player cube to be reset to
    Vector3 defaultPosition = new Vector3(0f, -0.05f, 0.5f);
    // Start is called before the first frame update


    public void resetCubePosition()
    {
        //A method that when triggered changes the transform of the object to the default position
        transform.position = defaultPosition;
        Debug.Log("Cube position reset");
    }

    public void DisableMesh()
    {
            //renderer.enabled = true; //(to show the game object)

            GetComponent<Renderer>().enabled = false; //(to hide the game object)
            GetComponent<CapsuleCollider>().enabled = false;
            Debug.Log("Cube hidden");

    }
}
