using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class HazardOnsetCheck : MonoBehaviour
{

    public Stopwatch hazardTimeCounter = new Stopwatch();
    public bool hazard;
    public bool hazardActive;
    public bool spawnerActive;
    public bool counterActive; 

    //Initialise Onsets and Offsets - Has to be set in the Unity Editor - High values are to stop CheckSpawn() comparing to 0
    [SerializeField] private float hazardOneOnset;
    [SerializeField] private float hazardOneOffset;

    private float hazardTwoOnset;
    private float hazardTwoOffset;

    private float hazardThreeOnset;
    private float hazardThreeOffset;

    // Start is called before the first frame update
    void Start()
    {
        hazard = false;
        
        hazardOneSpawned = false;
        hazardTwoSpawned = false;
        hazardThreeSpawned = false;
        

        //Define Onsets and Offsets here
        hazardOneOnset = 3000;
        hazardOneOffset = 4000;
        
        hazardTwoOnset = 12000;
        hazardTwoOffset = 14000;

        hazardThreeOnset = 20000;
        hazardThreeOffset = 22000;
    }

   public void CheckHazard()
    {
        if (hazard == false)
        {
            if (hazardTimeCounter.ElapsedMilliseconds >= hazardOneOnset && hazardTimeCounter.ElapsedMilliseconds <= hazardOneOffset)
            {
                hazard = true;
            }
            else if (hazardTimeCounter.ElapsedMilliseconds >= hazardTwoOnset && hazardTimeCounter.ElapsedMilliseconds <= hazardTwoOffset)
            {
                hazard = true;
            }
            else if (hazardTimeCounter.ElapsedMilliseconds >= hazardThreeOnset && hazardTimeCounter.ElapsedMilliseconds <= hazardThreeOffset)
            {
                hazard = true;
            }
            else
            {
                hazard = false;
            }
        }
        else if (hazard == true)
        {
            if (hazardTimeCounter.ElapsedMilliseconds >= hazardOneOffset && hazardTimeCounter.ElapsedMilliseconds <= hazardTwoOnset)
            {
                hazard = false;
                hazardOneSpawned =  true;
            }
            else if (hazardTimeCounter.ElapsedMilliseconds >= hazardTwoOffset && hazardTimeCounter.ElapsedMilliseconds <= hazardThreeOnset)
            {
                hazard = false;
            }
            else if (hazardTimeCounter.ElapsedMilliseconds >= hazardThreeOffset)
            {
                hazard = false;
            }
        }
    }


    
    // Function to check whether the Spawner should be active or not, as well as time windows for when hazard gems should spawn.

    //Currently hard coded but needs a more elegant solution!!//
    public void CheckSpawn()
    {

        if (counterActive == true)
        {
            if (spawnerActive == false && hazard == true)
            {
                if (hazardOneSpawned == false)
                {
                    if (hazardTimeCounter.ElapsedMilliseconds >= hazardOneOnset && hazardTimeCounter.ElapsedMilliseconds <= hazardOneOffset)
                    {
                        spawnerActive = true;
                        hazardStart();
                        hazardOneSpawned = true;
                    }
                }
                if (hazardTwoSpawned == false)
                {
                    if (hazardTimeCounter.ElapsedMilliseconds >= hazardTwoOnset && hazardTimeCounter.ElapsedMilliseconds <= hazardTwoOffset)
                    {
                        spawnerActive = true;
                        hazardStart();
                        hazardTwoSpawned = true;
                    }
                }
                if (hazardThreeSpawned == false)
                {
                    if (hazardTimeCounter.ElapsedMilliseconds >= hazardThreeOnset && hazardTimeCounter.ElapsedMilliseconds <= hazardThreeOffset)
                    {
                        spawnerActive = true;
                        hazardStart();
                        hazardThreeSpawned = true;
                    }
                }
            }
            else if (spawnerActive == true)
            {
                if (hazardTimeCounter.ElapsedMilliseconds >= hazardOneOffset)
                {
                    spawnerActive = false;
                    hazardStop();
                }
                if (hazardTimeCounter.ElapsedMilliseconds >= hazardTwoOffset)
                {
                    spawnerActive = false;
                    hazardStop();
                }
                if (hazardTimeCounter.ElapsedMilliseconds >= hazardThreeOffset)
                {
                    spawnerActive = false;
                    hazardStop();
                }
            }
        }
    }


}
