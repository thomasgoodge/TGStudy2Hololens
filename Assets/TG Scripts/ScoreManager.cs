using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text diamondScoreText;
    public Text emeraldScoreText;

    [SerializeField] public int diamondScore = 0;
    [SerializeField] public int emeraldScore = 0;

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
        diamondScoreText.text = "Diamonds: " + diamondScore.ToString();
        emeraldScoreText.text = "Emeralds: " + emeraldScore.ToString();

    }


    void Update()
    {
        diamondScoreText.text = "Diamonds: " + diamondScore.ToString();
        emeraldScoreText.text = "Emeralds: " + emeraldScore.ToString();

    }


    //Functions which modify the score and then output the updated score to the canvas as a string
    public void AddDiamondPoint()
    {
        diamondScore ++;
        print("Diamond score = " + diamondScore);
        
    }

    public void AddEmeraldPoint()
    {
        emeraldScore ++;
        print("Emerald Score = " + emeraldScore);
    }

}

