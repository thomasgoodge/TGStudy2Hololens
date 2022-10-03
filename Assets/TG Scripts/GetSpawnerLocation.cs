using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSpawnerLocation : MonoBehaviour
{

    [SerializeField] public string SpawnerLocationTag;
    public string SpawnerLocation;
    [SerializeField] public GameObject spawner;

    public float left = -0.66f;
    public float centreleft = -0.33f;
    public float centre = 0f;
    public float centreright = 0.33f;
    public float right = 0.66f;

    // Start is called before the first frame update
    void Start()
    {

        SpawnerLocationTag = spawner.tag;
        SpawnerLocation = SpawnerLocationTag.ToString();

    }

    
}
