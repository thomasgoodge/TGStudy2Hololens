using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] float timeToDestroy; //Parameter defining when the object should be destroyed in milliseconds
    public Stopwatch timeAlive = new Stopwatch();
      
    void Start()
    {
        //Create a timer from when the Game OBject is instantiated
        timeAlive.Start();
    }
  
    void Update()
    {
        if (timeAlive.ElapsedMilliseconds>timeToDestroy)
     {
        // Checks to see if the timeAlive stopwatch is greater than the timeToDestroy variable, and destroys object if so
         timeAlive.Stop();
        
         Destroy(this.gameObject);
     }
    }

    
}
