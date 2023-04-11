using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TabletScoreManager : MonoBehaviour
{
    public static TabletScoreManager instance;
    public Text TdiamondScoreText;
    public Text TemeraldScoreText;

    [SerializeField] public int tdiamondScore = 0;
    [SerializeField] public int temeraldScore = 0;

    public string tfinalDiamondScore;
    public string tfinalEmeraldScore;
    public string condition;

    public GameObject DataLoggerScript;
    public GameObject tEmeHazardSpawnerScript;
    public GameObject tDiaHazardSpawnerScript;

    public int TdiamondSpawned;
    public int TemeraldSpawned;


    //Defines a Text object to display as a Canvas, and the score container

    private void Awake()
    {
        instance = this;
        condition = SceneManager.GetActiveScene().name;

    }
    // Start is called before the first frame update
    void Start()
    {
        TdiamondScoreText.text = "Diamonds: " + tdiamondScore.ToString();
        TemeraldScoreText.text = "Emeralds: " + temeraldScore.ToString();
    }


    void Update()
    {
        TdiamondScoreText.text = "Diamonds: " + tdiamondScore.ToString();
        TemeraldScoreText.text = "Emeralds: " + temeraldScore.ToString();
        TdiamondSpawned = tDiaHazardSpawnerScript.GetComponent<TabletSpawner>().ObjectListLength;
        TemeraldSpawned = tEmeHazardSpawnerScript.GetComponent<TabletSpawner>().ObjectListLength;

        WriteTString();
        
        

    }


    //Functions which modify the score and then output the updated score to the canvas as a string
 

    public void AddTEmeraldPoint()
    {
        temeraldScore ++;
        //print("Emerald Score = " + emeraldScore);
    }

    public void AddTDiamondPoint()
    {
        tdiamondScore ++;
        //print("Diamond Score = " + diamondScore);
    }


    public void WriteTString()
    {
        string path = Application.persistentDataPath + "/" + condition + "_tabletscore.txt";

        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(TdiamondScoreText.text);
        writer.WriteLine(TemeraldScoreText.text);
        writer.WriteLine("Total Diamonds: " + TdiamondSpawned);
        writer.WriteLine("Total Emeralds: " + TemeraldSpawned);

        writer.Close();
        //StreamReader reader = new StreamReader(path);
        //Debug.Log(reader.ReadToEnd());
        //reader.Close();
    }


}

