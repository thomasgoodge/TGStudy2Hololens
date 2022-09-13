using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CSVReader : MonoBehaviour
{
    public TextAsset textAssetData;

    [System.Serializable]

    public class Hazard
    {
        //Define data columns
        public string ClipName;
        public float Onset;
        public float Offset;
        public string Location;
    }

    [System.Serializable]

    //create an array class
    public class HazardList
    {
        public Hazard[] hazard;
    }

    //declare an instance
    public HazardList myHazardList = new HazardList();
    
    // Start is called before the first frame update
    void Start()
    {
        ReadCSV();
    }

    void ReadCSV()
    {
        //Reads in text asset and splt string based on commas and carraige returns of csv file.
        string[] data = textAssetData.text.Split(new string [] { ",", "\n" }, StringSplitOptions.None);
        //each cell is new data point in string

        int tableSize = data.Length / 4 - 1;
        
        myHazardList.hazard = new Hazard[tableSize];

        for ( int i = 0; i < tableSize; i++ )
        {
            
            myHazardList.hazard[i] = new Hazard();
            
            myHazardList.hazard[i].ClipName = data[4* (i + 1)];
            
            myHazardList.hazard[i].Onset = float.Parse(data[4 * (i + 1) + 1]);
            
            myHazardList.hazard[i].Offset = float.Parse(data[4 * (i + 1) + 2]);
            
            myHazardList.hazard[i].Location = data[4 * (i + 1) + 3];
        }


    }

 
}
