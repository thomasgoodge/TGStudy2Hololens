using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
    // Create containers for the dimensions of the Spawner cube
    public Vector3 centre;
    public Vector3 size;
    public GameObject spherePrefab;
    // Create counters for time and number of spheres, as well as initialising a respawn time
    private float hazardRespawnTime = 1.0f;
    private int sphereCount = 0;
    public bool hazard;
    public bool spawnerActive;
    private bool hazardOneSpawned;
    private bool hazardTwoSpawned;
    private bool hazardThreeSpawned;
    public Stopwatch hazardTimeCounter = new Stopwatch();
    //public bool GameRunning = false;

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
        hazardOneSpawned = false;
        hazardTwoSpawned = false;
        hazardThreeSpawned = false;
        hazardTimeCounter.Start();

        //Define Onsets and Offsets here
        /* hazardOneOnset = **;
         hazardOneOffset = **;

         hazardTwoOnset = **;
         hazardTwoOffset = **;

         hazardThreeOnset = **;
         hazardThreeOffset = **;
         */
    }

    // Update is called once per frame
    void Update()
    {
        // Reset the respawn time to a random number within range ( smaller range for hazard spheres to increase spawn rate)
       // if (GameRunning == true)
        //{
            
            CheckSpawn();
            CheckHazard();
        //}
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
    // Function to check whether the Spawner should be active or not, as well as time windows for when hazard spheres should spawn.

    //Currently hard coded but needs a more elegant solution!!//
    public void CheckSpawn()
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

    private void hazardStart()
    {
        StartCoroutine(SpawnHazardSphere(spawnerActive));
    }

    private void hazardStop()
    {
        //Doesn't work with the StopCoroutine function
        //StopCoroutine(SpawnHazardSphere(spawnerActive));
        StopCoroutine(SpawnHazardSphere(spawnerActive));
    }

    // Create a Coroutine to create spheres within the spawn area
    private IEnumerator SpawnHazardSphere(bool spawnerActive)
    {
        while (spawnerActive == true)
        //while (enabled) 
        {
            // Create a new Vector 3 position that falls within the confines of the spawn area (Range is double the size of the spawn area, so need to halve it to maintain correct ratios)
            Vector3 pos = centre + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            //Debug.Log(pos);
            // Create an object with these properties
            GameObject alpha = Instantiate(spherePrefab, pos, Quaternion.identity);
            sphereCount++;
            // print(spherePrefab.ToString() + " spawned: " + sphereCount);
            // Wait for the amount of time within the respawn range
            yield return new WaitForSeconds(hazardRespawnTime);
        }
        if (spawnerActive == false)
        {
            yield return null;
        }
    }

    void OnDrawGizmosSelected()
    {
        // Visualise the spawn cubes in the Scene when clicked on (Colour and dimensions)
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(centre, size);
    }

}
