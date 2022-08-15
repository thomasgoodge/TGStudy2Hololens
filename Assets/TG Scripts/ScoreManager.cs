using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    [SerializeField] public int score = 0;

    [SerializeField] GameObject DiaSpawn;
    [SerializeField] GameObject EmeSpawn;


    
    
    //Defines a Text object to display as a Canvas, and the score container

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
    }


    void Update()
    {
        score = DiaSpawn.GetComponent<Spawner>().ObjectListLength + EmeSpawn.GetComponent<Spawner>().ObjectListLength;
        scoreText.text = "Score: " + score.ToString();
    }


    //Functions which modify the score and then output the updated score to the canvas as a string
    public void AddPoint()
    {
        score += 1;
        scoreText.text = "Score: " + score.ToString();
        //Debug.Log(score);
    }

    public void SubtractPoint()
    {
        score -= 1;
        scoreText.text = "Score: " + score.ToString();
    }

    public void HazardPoint()
    {
        score += 3;
        scoreText.text = "Score: " + score.ToString();
    }
}

