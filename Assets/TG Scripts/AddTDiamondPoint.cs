using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTDiamondPoint : MonoBehaviour
{
       // Start is called before the first frame update
      public void AddTDiamondScore()
    {
        //for the Tablet level, add on diamond point in the score manager
        TabletScoreManager.instance.tdiamondScore ++;
        //print("Diamond Hit");
    }
}
