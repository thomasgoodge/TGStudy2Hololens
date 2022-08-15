using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    //This could probably be done smoothly and efficiently with a Stopwatch!
    public bool isRunning;
    public Text timer;
    public float timeKeeper = 0.0f;

    //Define the text to displayed on the canvas, and a timekeeper variable to update whilst the app is running

    void Awake()
    {
        timer = GetComponent<Text>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        //Update timeKeeper with the deltaTime function and then output it as a string to the Canvas
        timeKeeper += Time.time;
            if (isRunning == true)
            timer.text = Time.time.ToString("#.00");
        //Debug.Log(timer.text);
    }

    public void StartTimer()
    {
        isRunning = true;
    }

}

