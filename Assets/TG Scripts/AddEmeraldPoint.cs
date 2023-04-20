using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddEmeraldPoint : MonoBehaviour
{
     public void AddEmeraldScore()
    {
        //In the ScoreManager object, add one point to the emerald score
        ScoreManager.instance.emeraldScore ++;
        //print("Emerald Hit");
    }

}
