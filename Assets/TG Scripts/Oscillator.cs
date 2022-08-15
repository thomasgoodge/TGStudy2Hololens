using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    //Script to make an object move between two points defined in the Unity playspace

    Vector3 startingPostiion;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor;
    [SerializeField] float period = 6f;

    // Start is called before the first frame update
    void Start()
    {
        startingPostiion = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Oscillate();
    }

    public void Oscillate()
    {
        if (period <= Mathf.Epsilon) { return; } //can't compare two floats - Epsilion is smallest possible unit in Unity to compare to
        float cycles = Time.time / period; // continually growing over time
        const float tau = Mathf.PI * 2; // constant value of 6.283 
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = (rawSinWave + 1f) / 2f; // recalculated to go from 0 : 1 as opposed to sign wave -1 : 1

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPostiion + offset;
    }
}
