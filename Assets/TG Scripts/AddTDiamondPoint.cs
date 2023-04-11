using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTDiamondPoint : MonoBehaviour
{
       // Start is called before the first frame update
      public void AddTDiamondScore()
    {
        TabletScoreManager.instance.tdiamondScore ++;
        //print("Diamond Hit");
    }
}
