using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class HazardOnsetManager : MonoBehaviour
{
    // Create counters for time and number of gems, as well as initialising a respawn time
    public bool hazard;
    public float onset;
    public float offset;

    public Stopwatch hazardTimeCounter = new Stopwatch();

    public GameObject HazardSpawnerScript;
    public GameObject HazardListScript;

    //Initialise Onsets and Offsets - Has to be set in the Unity Editor - High values are to stop CheckSpawn() comparing to 0
    
    
    [SerializeField] private float hazardOneOnset;
    [SerializeField] private float hazardOneOffset;

    [SerializeField] private float hazardTwoOnset;
    [SerializeField] private float hazardTwoOffset;

    [SerializeField] private float hazardThreeOnset;
    [SerializeField] private float hazardThreeOffset;
    

    // Start is called before the first frame update
    void Start()
    {
        hazard = false;
        hazardTimeCounter.Start();

        //Define Onsets and Offsets here
        
        hazardOneOnset = 8000;
        hazardOneOffset = 10000;

        
        hazardTwoOnset = 12000;
        hazardTwoOffset = 14000;

        hazardThreeOnset = 17000;
        hazardThreeOffset = 19000;
         
    }

    // Update is called once per frame
    void Update()
    {
        bool hzrd = CheckHazard();
        bool spwn= CheckSpawn();
        if (hzrd && spwn)
        {
            //if the spawner isn't currently running and hazard == true, then start the coroutine
            HazardSpawnerScript.GetComponent<HazardSpawner>().hazardStart();
        }
        else if (!hzrd && !spwn)
        {
            //if hazard == false and spawner is active, then stop the spawner
            HazardSpawnerScript.GetComponent<HazardSpawner>().hazardStop();
        }
    }
/*
    public float GetHazardOnset()
    {
       onset =  HazardListScript.GetComponent<CSVReader>().myHazardList.hazard[1].Onset;
    }

    public float GetHazardOffset()
    {
       offset =  HazardListScript.GetComponent<CSVReader>().myHazardList.hazard[1].Offset;
    }
*/
    public bool CheckHazard()
    {
        if (hazard == false)
        {
            if (hazardTimeCounter.ElapsedMilliseconds >= hazardOneOnset && hazardTimeCounter.ElapsedMilliseconds <= hazardOneOffset)
            {
                hazard = true;
                return true;
            }
            
            else if (hazardTimeCounter.ElapsedMilliseconds >= hazardTwoOnset && hazardTimeCounter.ElapsedMilliseconds <= hazardTwoOffset)
            {
                hazard = true;
                return true;
            }
            else if (hazardTimeCounter.ElapsedMilliseconds >= hazardThreeOnset && hazardTimeCounter.ElapsedMilliseconds <= hazardThreeOffset)
            {
                hazard = true;
                return true;
            }
            

        return false;
          
        }
        else if (hazard == true)
        {
            if (hazardTimeCounter.ElapsedMilliseconds >= hazardOneOffset && hazardTimeCounter.ElapsedMilliseconds <= hazardTwoOnset)
            {
                hazard = false;
                return false;
            }
            /*
            else if (hazardTimeCounter.ElapsedMilliseconds >= hazardTwoOffset && hazardTimeCounter.ElapsedMilliseconds <= hazardThreeOnset)
            {
                hazard = false;
                return false;
            }
            else if (hazardTimeCounter.ElapsedMilliseconds >= hazardThreeOffset)
            {
                hazard = false;
                return false;
            }
            */
       return true;
        }

        return hazard;
    }
    // Function to check whether the Spawner should be active or not, as well as time windows for when hazard gems should spawn.
    public bool CheckSpawn()
    {
        bool currentState =  HazardSpawnerScript.GetComponent<HazardSpawner>().spawnerActive;

        if (currentState == false && hazard == true)
        {
            return true;
        }
        else if (currentState == true && hazard == true)
        {
            return true;
        }
        else if (currentState == true && hazard == false)
        {
            return false;
        }
        else if (currentState == false && hazard == false)
        {
            return false;
        }
        
        return currentState; 

    }

}

