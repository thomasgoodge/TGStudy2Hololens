using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    
   MeshRenderer startButton;
    // Update is called once per frame
   void Start()
   {
       gameObject.SetActive(false);
   }

    void Update()
    {
        Debug.Log(Time.deltaTime);
        if(Time.deltaTime > 5f)
        {
            gameObject.SetActive(true);
        }
    }
}
