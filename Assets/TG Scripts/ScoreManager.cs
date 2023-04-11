using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text diamondScoreText;
    public Text emeraldScoreText;

    [SerializeField] public int diamondScore = 0;
    [SerializeField] public int emeraldScore = 0;

    public string finalDiamondScore;
    public string finalEmeraldScore;
    public string condition;

    public GameObject DataLoggerScript;
    public GameObject EmeHazardSpawnerScript;
    public GameObject DiaHazardSpawnerScript;

    public int diamondsSpawned;
    public int emeraldsSpawned;


    //Defines a Text object to display as a Canvas, and the score container

    private void Awake()
    {
        instance = this;
        condition = SceneManager.GetActiveScene().name;

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

        WriteString();
        
        diamondsSpawned = DiaHazardSpawnerScript.GetComponent<Spawner>().ObjectListLength;
        emeraldsSpawned = EmeHazardSpawnerScript.GetComponent<Spawner>().ObjectListLength;


    }


    //Functions which modify the score and then output the updated score to the canvas as a string
 

    public void AddEmeraldPoint()
    {
        emeraldScore ++;
        //print("Emerald Score = " + emeraldScore);
    }

    public void AddDiamondPoint()
    {
        diamondScore ++;
        //print("Diamond Score = " + diamondScore);
    }


    public void WriteString()
    {

        string path = Application.persistentDataPath + "/" + condition + "_score.txt";

        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(diamondScoreText.text);
        writer.WriteLine(emeraldScoreText.text);
        writer.WriteLine("Total Diamonds: " + diamondsSpawned);
        writer.WriteLine("Total Emeralds: " +emeraldsSpawned);

        writer.Close();
        //StreamReader reader = new StreamReader(path);
        //Debug.Log(reader.ReadToEnd());
        //reader.Close();
    }


}

