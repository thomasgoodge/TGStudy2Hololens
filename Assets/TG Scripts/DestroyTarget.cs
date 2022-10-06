using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTarget : MonoBehaviour
{
   public void DestroyThisTarget()
    {

             //Method that destroys the current game object. Used as a method called when object is focused on in the Hololens
        Destroy(this.gameObject);
       
        
   


    }
}
