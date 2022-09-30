using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class HazardOnsetManager : MonoBehaviour
{
    // Create counters for time and number of gems, as well as initialising a respawn time
    public bool hazard;
    public bool currentState;

    [SerializeField] public Stopwatch hazardTimeCounter = new Stopwatch();

    public GameObject HazardSpawnerScript;
    public GameObject HazardListScript;
    public GameObject FileReaderScript;


    public string clipName;
    public int location;
    public int hazardLocation;
    public float onset;
    public float offset;
    public float length;
    public int clipRef;
    [SerializeField]public string currentClip;
    [SerializeField] public long timer;
    //string[] hazardList = HazardListScript.GetComponent<CSVReader>().myHazardList.hazard.ClipName;

    // Start is called before the first frame update
    void Start()
    {
        currentState = false;
        hazard = false;
        clipName = GetClipName();
        length = GetClipLength();
        hazardLocation = GetHazardLocation();
        onset = GetHazardOnset();
        offset = GetHazardOffset();
    }
// Update is called once per frame
    void Update()
    {
        timer = hazardTimeCounter.ElapsedMilliseconds;
        hazard = CheckHazard();
        currentState = CheckSpawn();
        clipRef = GetClipIndex();
        currentClip = GetCurrentClip();     

        if (clipName != currentClip )
        {
            clipRef = GetClipIndex();
            onset = GetHazardOnset();
            offset = GetHazardOffset();
            clipName = GetClipName();
            hazardLocation = GetHazardLocation();
            length = GetClipLength();
            StopwatchReset();
            StopwatchStart();
        }
        
        if (hazardTimeCounter.ElapsedMilliseconds >= length || Input.GetKey("n")) // Input just for debugging
            {
                clipRef = GetClipIndex();
                onset = GetHazardOnset();
                offset = GetHazardOffset();
                clipName = GetClipName();
                hazardLocation = GetHazardLocation();
                length = GetClipLength();
                StopwatchReset();
                StopwatchStart();
            }
        //print(hazardTimeCounter.ElapsedMilliseconds);
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
            else
            {
                return hazard;
            }
        
        }
        else if (hazard == true)
        {
            if (hazardTimeCounter.ElapsedMilliseconds >= offset)
            {
                //if the timer is outside the window, turn hazard to false
                hazard = false;
                return hazard;
            }
            else
            {
                return hazard;
            }
        }
        return hazard;
    }
    // Function to check whether the Spawner should be active or not, as well as time windows for when hazard gems should spawn.
    public bool CheckSpawn()
    {
        currentState = HazardSpawnerScript.GetComponent<HazardSpawner>().spawnerActive;

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
    
    public string GetCurrentClip()
    {
        return FileReaderScript.GetComponent<FileReader>().currentClip;
    }

    public int GetClipIndex()
    {
        return HazardListScript.GetComponent<CSVReader>().CurrentClipIndex();
    }
    
    public string GetClipName()
    {
        //function to retrieve the current clip
       return HazardListScript.GetComponent<CSVReader>().myHazardList.hazard[clipRef].ClipName;
    }

    public int GetHazardLocation()
    {
        //function to retrieve the hazard location for the spawner
       return  HazardListScript.GetComponent<CSVReader>().myHazardList.hazard[clipRef].Location;
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

    public float GetClipLength()
    {
        // function to retrieve the hazard offset.
       return HazardListScript.GetComponent<CSVReader>().myHazardList.hazard[clipRef].Length;
    }
    public void StopwatchStart()
    {
        //Function to start the stopwatch when the button is pressed
       hazardTimeCounter.Start();
    }

    public void StopwatchReset()
    {
       hazardTimeCounter.Stop();
       hazardTimeCounter.Reset();
    }

}

