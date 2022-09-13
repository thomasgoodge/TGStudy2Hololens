using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
    // Create containers for the dimensions of the Spawner cube
    public Vector3 centre;
    public Vector3 size;
    public GameObject gemPrefab;
    // Create counters for time and number of gems, as well as initialising a respawn time
    public float hazardRespawnTime;
    public float hazardRespawnRate = 1.0f;
    private int gemCount;
    [SerializeField] public bool spawnerActive;
    public GameObject HazardOnsetManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        gemCount = 0;
        StartCoroutine(SpawnHazardGem(spawnerActive));
        print("Coroutine started");
    }

    // Update is called once per frame
    void Update()
    {
        // Reset the respawn time to a random number within range ( smaller range for hazard gems to increase spawn rate)
        hazardRespawnTime = Random.Range(hazardRespawnRate / 2, hazardRespawnRate * 2);        
        spawnerActive = HazardOnsetManagerScript.GetComponent<HazardOnsetManager>().currentState;

        if (spawnerActive)
        {
            if (gemCount < 5)
            {
            Vector3 pos = centre + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            GameObject alpha = Instantiate(gemPrefab, pos, Quaternion.identity);
            gemCount++;
            new WaitForSeconds(0.8f);
            
            }
            
          
        }
        else if (!spawnerActive)
        {
            gemCount = 0;
        }

       // print("Spawner script status = " + spawnerActive);
       //print(HazardOnsetManagerScript.GetComponent<HazardOnsetManager>().hazardTimeCounter.ElapsedMilliseconds);
    }

    // Create a Coroutine to create gems within the spawn area
    public IEnumerator SpawnHazardGem(bool spawnerActive)
    {        
        while (spawnerActive) 
        {
            // Create a new Vector 3 position that falls within the confines of the spawn area (Range is double the size of the spawn area, so need to halve it to maintain correct ratios)
            Vector3 pos = centre + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            //Debug.Log(pos);
            // Create an object with these properties
            GameObject alpha = Instantiate(gemPrefab, pos, Quaternion.identity);

            //gemCount++;
            print("Gems spawned = " + gemCount);
            // Wait for the amount of time within the respawn range
            yield return new WaitForSeconds(hazardRespawnTime);
        } 
                
    }

    void OnDrawGizmosSelected()
    {
        // Visualise the spawn cubes in the Scene when clicked on (Colour and dimensions)
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(centre, size);
    }

    public void StopwatchStart()
    {
        HazardOnsetManagerScript.GetComponent<HazardOnsetManager>().hazardTimeCounter.Start();
    }

    public void hazardStart()
    {
        StartCoroutine(SpawnHazardGem(spawnerActive));
        spawnerActive = true;    
    }

    public void hazardStop()
    {
        StopCoroutine(SpawnHazardGem(spawnerActive));
        spawnerActive = false;
    }
    
}
