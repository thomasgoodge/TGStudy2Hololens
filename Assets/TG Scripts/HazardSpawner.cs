using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;



public class HazardSpawner : MonoBehaviour
{
    // Create containers for the dimensions of the Spawner cube
    public Vector3 centralspawn;
    public Vector3 size;
    public GameObject gemPrefab;

    // Create counters for time and number of gems, as well as initialising a respawn time
    public float hazardRespawnTime;
    public float hazardRespawnRate = 1.0f;
    private int gemCount;
    [SerializeField] public bool spawnerActive;

    public GameObject HazardOnsetManagerScript;
    public GameObject GetSpawnerLocationScript;

    public string SpawnerLocation;
    public int selectSpawner;

    public Vector3 left = new Vector3(-0.66f,-0.15f,3f);
    public Vector3 centreleft = new Vector3(-0.33f,-0.15f,3f);
    public Vector3 centre = new Vector3(0f,-0.15f,3f);
    public Vector3 centreright =new Vector3(0.33f,-0.15f,3f);
    public Vector3 right = new Vector3(0.66f,-0.15f,3f);
    public string condition;
    // Start is called before the first frame update
    void Start()
    {
        left = new Vector3(-0.66f,-0.15f,3f);
        centreleft = new Vector3(-0.33f,-0.15f,3f);
        centre = new Vector3(0f,-0.15f,3f);
        centreright =new Vector3(0.33f,-0.15f,3f);
        right = new Vector3(0.66f,-0.15f,3f);
        spawnerActive = false;
        gemCount = 0;     
        centralspawn = new Vector3(0f, -0.15f, 3f); 
        condition = SceneManager.GetActiveScene().name;
        

    }

    // Update is called once per frame
    void Update()
    {
        // Reset the respawn time to a random number within range ( smaller range for hazard gems to increase spawn rate)
        hazardRespawnTime = Random.Range(hazardRespawnRate / 2, hazardRespawnRate * 2);        
        selectSpawner =  HazardOnsetManagerScript.GetComponent<HazardOnsetManager>().hazardLocation;
        //spawnerActive = HazardOnsetManagerScript.GetComponent<HazardOnsetManager>().hazard;

       //Select which spawner to use
        if (condition == "GemsFocusedCongruent")
            {
            setSpawnerLocationCongruent();
            }
        else if (condition == "GemsFocusedIncongruent")
            {
            setSpawnerLocationIncongruent();
            }

        // Decide when to activate the spawner
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
                StartCoroutine("CorSpawnHazardGem", 0.5f);     
                gemCount++;                                 
            }

        if (!spawnerActive)
            {
                StopCoroutine("CorSpawnHazardGem");
                gemCount = 0;
            }
    
    }

    void OnDrawGizmosSelected()
    {
        // Visualise the spawn cubes in the Scene when clicked on (Colour and dimensions)
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(centralspawn, size);    
    }

    IEnumerator CorSpawnHazardGem()
    {
        while (gemCount <= 4)
            {     
                // if there are less than 5 gems, spawn a gem in the range of the spawner
                Vector3 pos = centralspawn + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
                GameObject alpha = Instantiate(gemPrefab, pos, Quaternion.identity);
                gemCount++;
                yield return new WaitForSeconds(0.5f);
            }
            
        if (gemCount > 4)
            {
                yield return new WaitForSeconds(1.0f);
            }        
    }

    public void setSpawnerLocationCongruent()
    {
        if (selectSpawner == 5)
            {
                centralspawn.x = right.x; 
            }
        if (selectSpawner == 4)
            {
                centralspawn.x = centreright.x; 
            }
        if (selectSpawner == 3)
            {
                centralspawn.x = centre.x; 
            }
        if (selectSpawner == 2)
            {
                centralspawn.x = centreleft.x; 
            }
        if (selectSpawner == 1)
            {
                centralspawn.x = left.x; 
            }
    }
    public void setSpawnerLocationIncongruent()
    {
        if (selectSpawner == 5)
            {
                centralspawn.x = left.x; 
            }
        if (selectSpawner == 4)
            {
                centralspawn.x = left.x; 
            }
        if (selectSpawner == 3)
            {
                int coinToss = Random.Range(1,2);
                if (coinToss == 1)
                {
                centralspawn.x = right.x; 
                }
                else
                {
                centralspawn.x = left.x;
                }
            }
        if (selectSpawner == 2)
            {
                centralspawn.x = right.x; 
            }
        if (selectSpawner == 1)
            {
                centralspawn.x = right.x; 
            }
    }
}

