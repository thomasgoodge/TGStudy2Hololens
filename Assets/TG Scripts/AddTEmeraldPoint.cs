using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTEmeraldPoint : MonoBehaviour
{
     public void AddTEmeraldScore()
    {
        TabletScoreManager.instance.temeraldScore ++;
        //print("Emerald Hit");
    }

}
