using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpawner : MonoBehaviour
{
    //Create containers for the dimensions of the Spawner cube
    public Vector3 centre;
    public Vector3 size;
    public Quaternion rotation;
    public GameObject itemPrefab;
    //Create counters for time and number of spheres, as well as initialising a respawn time
    public float respawnRate = 1f;
    public float respawnTime;
    private int sphereCount = 0;

    // Start is called before the first frame update
    void Start()
    {   
        StartSpawner();

    }

    // Update is called once per frame
    void Update()
    {
        //Reset the respawn time to a random number within range 
        respawnTime = Random.Range(respawnRate / 2, respawnRate * 2);
    }

    public void StartSpawner()
    {
        StartCoroutine(SpawnObject());
    }

    private IEnumerator SpawnObject()
    {
        // Coroutine will run forever whilst the game is running;
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0, 1));
            // Create a new Vector 3 position that falls within the confines of the spawn area (Range is double the size of the spawn area, so need to halve it to maintain correct ratios)
            Vector3 pos = centre + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            
            //Debug.Log(pos);
            //Create an object with these properties
            GameObject alpha = Instantiate(itemPrefab, pos, Quaternion.identity);
            sphereCount++;
           // Debug.Log(itemPrefab.ToString() + " spawned: " + sphereCount);
            yield return new WaitForSeconds(respawnTime);
        }
    }

    void OnDrawGizmosSelected()
    {
        //Visualise the spawn cubes in the Scene when clicked on (Colour and dimensions)
        Gizmos.color = new Color(0,1,0,0.5f);
        Gizmos.DrawWireCube(centre, size);
    }

}


