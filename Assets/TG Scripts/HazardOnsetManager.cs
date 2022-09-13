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
        
        //Define Onsets and Offsets here (ms)
        
        hazardOneOnset = 5000;
        hazardOneOffset = 8000;
        
        hazardTwoOnset = 15000;
        hazardTwoOffset = 19000;

        hazardThreeOnset = 24000;
        hazardThreeOffset = 30000;
        
    }

    // Update is called once per frame
    void Update()
    {
        hazard = CheckHazard();
        currentState = CheckSpawn();
    }

    public float GetHazardOnset()
    {
       onset =  HazardListScript.GetComponent<CSVReader>().myHazardList.hazard[1].Onset;
    }

    public float GetHazardOffset()
    {
       offset =  HazardListScript.GetComponent<CSVReader>().myHazardList.hazard[1].Offset;
    }

    public bool CheckHazard()
    {
        if (hazard == false)
        {
            if (hazardTimeCounter.ElapsedMilliseconds >= hazardOneOnset && hazardTimeCounter.ElapsedMilliseconds <= hazardOneOffset)
            {
                hazard = true;
                return hazard;
            }
            
            else if (hazardTimeCounter.ElapsedMilliseconds >= hazardTwoOnset && hazardTimeCounter.ElapsedMilliseconds <= hazardTwoOffset)
            {
                hazard = true;
                return hazard;
            }
            else if (hazardTimeCounter.ElapsedMilliseconds >= hazardThreeOnset && hazardTimeCounter.ElapsedMilliseconds <= hazardThreeOffset)
            {
                hazard = true;
                return hazard;
            }

        return hazard;
          
        }
        else if (hazard == true)
        {
            if (hazardTimeCounter.ElapsedMilliseconds >= hazardOneOffset && hazardTimeCounter.ElapsedMilliseconds <= hazardTwoOnset)
            {
                hazard = false;
                return hazard;
            }
            
            else if (hazardTimeCounter.ElapsedMilliseconds >= hazardTwoOffset && hazardTimeCounter.ElapsedMilliseconds <= hazardThreeOnset)
            {
                hazard = false;
                return hazard;
            }
            else if (hazardTimeCounter.ElapsedMilliseconds >= hazardThreeOffset)
            {
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

