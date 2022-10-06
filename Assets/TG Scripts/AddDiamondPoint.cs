using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDiamondPoint : MonoBehaviour
{
       // Start is called before the first frame update
      public void AddDiamondScore()
    {
        ScoreManager.instance.diamondScore ++;
        //print("Diamond Hit");
    }
}
