using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDiamondPoint : MonoBehaviour
{
       // Start is called before the first frame update
      public void AddDiamondScore()
    {
        //In the score Manager, add one point to the diamond score
        ScoreManager.instance.diamondScore ++;
        //print("Diamond Hit");
    }
}
