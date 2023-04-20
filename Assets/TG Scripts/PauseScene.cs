using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScene : MonoBehaviour
{

void Awake() {
    ResumeGame();
}

    // Start is called before the first frame update
void PauseGame ()
    {
        Time.timeScale = 0;

    }
void ResumeGame ()
    {
        Time.timeScale = 1;

    }



}
