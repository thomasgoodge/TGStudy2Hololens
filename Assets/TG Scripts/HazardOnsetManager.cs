using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class HazardOnsetManager : MonoBehaviour
{
    // Create counters for time and number of gems, as well as initialising a respawn time
    public bool hazard;
    public bool currentState;

    public Stopwatch hazardTimeCounter = new Stopwatch();

    public GameObject HazardSpawnerScript;
    public GameObject HazardListScript;

    public string clipName;
    public string hazardLocation;
    public float onset;
    public float offset;
    public int clipRef;

    // Start is called before the first frame update
    void Start()
    {
        hazard = false;
        offset = 10;
        clipName = GetClipName();
        hazardLocation = GetHazardLocation();
        clipRef = 0;
    }

    // Update is called once per frame      
    void Update()
    {
        hazard = CheckHazard();
        currentState = CheckSpawn();

    if (hazardTimeCounter.ElapsedMilliseconds >= offset)
        {
            //if the timer exceeds the hazard window, cycle through to the next clip and update the hazard details
            clipRef++;
            onset = GetHazardOnset();
            offset = GetHazardOffset();
            hazardTimeCounter.Stop();
            hazardTimeCounter.Reset();
            hazardTimeCounter.Start();
            clipName = GetClipName();
            hazardLocation = GetHazardLocation();
        }

        print(hazardTimeCounter.ElapsedMilliseconds);
    }

    public string GetClipName()
    {
        //function to retrieve the current clip
       return HazardListScript.GetComponent<CSVReader>().myHazardList.hazard[clipRef].ClipName;
    }

    public string GetHazardLocation()
    {
        //function to retrieve the hazard location for the spawner
       return HazardListScript.GetComponent<CSVReader>().myHazardList.hazard[clipRef].Location;
    }

    public float GetHazardOnset()
    {
        //function to retrieve the hazard onset
       return HazardListScript.GetComponent<CSVReader>().myHazardList.hazard[clipRef].Onset;
    }

    public float GetHazardOffset()
    {
        // function to retrieve the hazard offset.
       return HazardListScript.GetComponent<CSVReader>().myHazardList.hazard[clipRef].Offset;
    }

    public bool CheckHazard()
    {
        //function that checks whether the hazard is active or not.
        if (hazard == false)
        {
            if (hazardTimeCounter.ElapsedMilliseconds >= onset && hazardTimeCounter.ElapsedMilliseconds <= offset)
            {
                // if hazard is false and the time is during the window, change to true
                hazard = true;
                return hazard;
            }
        return hazard;
        }
        else if (hazard == true)
        {
            if (hazardTimeCounter.ElapsedMilliseconds >= offset)
            {
                //if the timer is outside the window, turn hazard to false
                hazard = false;
                return hazard;
            }
              
       return hazard;
        }

        return hazard;
    }
    // Function to check whether the Spawner should be active or not, as well as time windows for when hazard gems should spawn.
    public bool CheckSpawn()
    {
         currentState =  HazardSpawnerScript.GetComponent<HazardSpawner>().spawnerActive;

        if (currentState == false && hazard == true)
        {
            //If the spawner isn't active and it's in the hazard window, set the spawner to active
            currentState = true;
            return currentState;
        }
        else if (currentState == true && hazard == true)
        {
            //If the spawner is active and it's in the hazard window, don't change anything
            return currentState;
        }
        else if (currentState == true && hazard == false)
        {
            //If the spawner is active but it's after the hazard onset, set the spawner to inactive
            currentState =  false;
            return currentState;
        }
        else if (currentState == false && hazard == false)
        {
            //if the spawner isn't active and there is no hazard, leave it inactive
            return currentState;
        }
        
        return currentState; 

    }

}

