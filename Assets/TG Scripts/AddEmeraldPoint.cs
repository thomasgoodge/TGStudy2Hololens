using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddEmeraldPoint : MonoBehaviour
{
     public void AddEmeraldScore()
    {
        ScoreManager.instance.emeraldScore ++;
        //print("Emerald Hit");
    }

}
