using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class HazardOnsetManager : MonoBehaviour
{

    // Create counters for time and number of gems, as well as initialising a respawn time
    public bool hazard;
    public bool spawnerActive;
    private bool hazardOneSpawned;
    private bool hazardTwoSpawned;
    private bool hazardThreeSpawned;
    public Stopwatch hazardTimeCounter = new Stopwatch();

    public GameObject HazardSpawnerScript;


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
        spawnerActive = false;
        hazard = false;
        hazardTimeCounter.Start();

        //Define Onsets and Offsets here
        hazardOneOnset = 10000;
        hazardOneOffset = 12000;

        /*
        hazardTwoOnset = **;
        hazardTwoOffset = **;

        hazardThreeOnset = **;
        hazardThreeOffset = **;
         */
    }

    // Update is called once per frame
    void Update()
    {

        CheckHazard();
        CheckSpawn();
        if (hazard == true && spawnerActive == false)
        {
            HazardSpawnerScript.GetComponent<HazardSpawner>().hazardStart();

        }
        else if (hazard == false && spawnerActive == true)
        {
            HazardSpawnerScript.GetComponent<HazardSpawner>().hazardStop();

        }
    }

    public bool CheckHazard()
    {
       
        if (hazard == false)
        {
            if (hazardTimeCounter.ElapsedMilliseconds >= hazardOneOnset && hazardTimeCounter.ElapsedMilliseconds <= hazardOneOffset)
            {
                return hazard = true;
            }
            else if (hazardTimeCounter.ElapsedMilliseconds >= hazardTwoOnset && hazardTimeCounter.ElapsedMilliseconds <= hazardTwoOffset)
            {
                return hazard = true;
            }
            else if (hazardTimeCounter.ElapsedMilliseconds >= hazardThreeOnset && hazardTimeCounter.ElapsedMilliseconds <= hazardThreeOffset)
            {
                return hazard = true;
            }
            else
            {
                return hazard = false;
            }
        }
        else if (hazard == true)
        {
            if (hazardTimeCounter.ElapsedMilliseconds >= hazardOneOffset && hazardTimeCounter.ElapsedMilliseconds <= hazardTwoOnset)
            {
                return hazard = false;
            }
            else if (hazardTimeCounter.ElapsedMilliseconds >= hazardTwoOffset && hazardTimeCounter.ElapsedMilliseconds <= hazardThreeOnset)
            {
                return hazard = false;
            }
            else if (hazardTimeCounter.ElapsedMilliseconds >= hazardThreeOffset)
            {
                return hazard = false;
            }
            else 
            {
                return hazard = true;
            }
        }
    }
    // Function to check whether the Spawner should be active or not, as well as time windows for when hazard gems should spawn.

    //Currently hard coded but needs a more elegant solution!!//
    public bool CheckSpawn()
    {
        if (spawnerActive == false && hazard == true)
        {
            if (hazardOneSpawned == false)
            {
                if (hazardTimeCounter.ElapsedMilliseconds >= hazardOneOnset && hazardTimeCounter.ElapsedMilliseconds <= hazardOneOffset)
                {
                    return  spawnerActive = true;
                }
            }
            if (hazardTwoSpawned == false)
            {
                if (hazardTimeCounter.ElapsedMilliseconds >= hazardTwoOnset && hazardTimeCounter.ElapsedMilliseconds <= hazardTwoOffset)
                {
                    return  spawnerActive = true;
                }
            }
            if (hazardThreeSpawned == false)
            {
                if (hazardTimeCounter.ElapsedMilliseconds >= hazardThreeOnset && hazardTimeCounter.ElapsedMilliseconds <= hazardThreeOffset)
                {
                    return  spawnerActive = true;
                }
            }
        }
        else if (spawnerActive == true)
        {
            if (hazardTimeCounter.ElapsedMilliseconds >= hazardOneOffset)
            {
                return  spawnerActive = false;
            }
            if (hazardTimeCounter.ElapsedMilliseconds >= hazardTwoOffset)
            {
                return  spawnerActive = false; 
            }
            if (hazardTimeCounter.ElapsedMilliseconds >= hazardThreeOffset)
            {
                return  spawnerActive = false;
            }
        }
    }


}

