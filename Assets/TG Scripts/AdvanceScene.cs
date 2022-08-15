using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class AdvanceScene : MonoBehaviour
{
    public void AdvanceLevel(string sceneIndex)
    {
       //Function that Loads the scene from the string given in the Unity Editor - needs to match level name exactly to function
       SceneManager.LoadScene(sceneIndex);
    }


}



