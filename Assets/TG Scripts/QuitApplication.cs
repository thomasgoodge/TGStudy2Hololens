using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    // Start is called before the first frame update
     public void QuitGame()
    {
        //Method that quits the application to be used on the Quit Button
       
            Application.Quit();
            Debug.Log("Game quit");
        

    }

}
