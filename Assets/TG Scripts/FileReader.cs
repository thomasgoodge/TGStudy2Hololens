using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileReader : MonoBehaviour
{    
    public string currentClip;

    public string ReadString()
    {
        string path = "D:./PsychoPyExperiments/Study2HazardPerception/VideoName.txt";

        StreamReader reader = new StreamReader(path, true);
        currentClip = reader.ReadToEnd();
        reader.Close();

        return currentClip;
    }

     void Update()
    {
        ReadString();
       
    }

}
