using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace Microsoft.MixedReality.Toolkit.Examples.Demos.EyeTracking { 

public class DisplayGazeData : MonoBehaviour
    {
        //Debugging script to tell if an object is being focused on in the Unity editor
        // Update is called once per frame
        void Update()
        {
            Vector3 HitPos  = CoreServices.InputSystem.EyeGazeProvider.HitPosition;
            //Vector3 GazeCursor  = CoreServices.InputSystem.EyeGazeProvider.GazeCursor;
            Vector3 GazeDir = CoreServices.InputSystem.EyeGazeProvider.GazeDirection;


            Debug.Log("Hit Position is: " + HitPos);
           // Debug.Log("Gaze Cursor is: " + GazeCursor);
            Debug.Log("Gaze Direction is: " + GazeDir);



        }
    }


}
