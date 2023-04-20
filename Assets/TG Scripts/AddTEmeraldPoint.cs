using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTEmeraldPoint : MonoBehaviour
{
     public void AddTEmeraldScore()
    {
     //for the tablet level, add one emerald point in the scoremanager
        TabletScoreManager.instance.temeraldScore ++;
        //print("Emerald Hit");
    }

}
