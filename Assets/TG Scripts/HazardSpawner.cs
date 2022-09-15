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
        spawnerActive = false;
        gemCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Reset the respawn time to a random number within range ( smaller range for hazard gems to increase spawn rate)
        hazardRespawnTime = Random.Range(hazardRespawnRate / 2, hazardRespawnRate * 2);        
        if (HazardOnsetManagerScript.GetComponent<HazardOnsetManager>().hazard == true)
        {
            spawnerActive = true;
        }
        else if (HazardOnsetManagerScript.GetComponent<HazardOnsetManager>().hazard == false)
        {
            spawnerActive = false;
        }
        //if the spawner is active from the HazardOnsetManager script
        while (spawnerActive && gemCount <= 3)
        {
            StartCoroutine("CorSpawnHazardGem", 1.0f);
            //SpawnHazardGem();
            gemCount++;
        }
        if (!spawnerActive)
        {
            StopCoroutine("CorSpawnHazardGem");
            gemCount = 0;
        }
       // print("Spawner script status = " + spawnerActive);
       //print(HazardOnsetManagerScript.GetComponent<HazardOnsetManager>().hazardTimeCounter.ElapsedMilliseconds);
    }

    void OnDrawGizmosSelected()
    {
        // Visualise the spawn cubes in the Scene when clicked on (Colour and dimensions)
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(centre, size);
    }

    IEnumerator CorSpawnHazardGem()
    {
      while (gemCount <= 4)
            {
            // if there are less than 5 gems, spawn a gem in the range of the spawner
            Vector3 pos = centre + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            GameObject alpha = Instantiate(gemPrefab, pos, Quaternion.identity);
            gemCount++;
            yield return new WaitForSeconds(1.0f);
            }
        if (gemCount > 4);
            {
            yield return null;
            }        
    }
    public void SpawnHazardGem()
    {
            // if there are less than 5 gems, spawn a gem in the range of the spawner
            Vector3 pos = centre + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            GameObject alpha = Instantiate(gemPrefab, pos, Quaternion.identity);
    }




}

