using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public Text LeftCoinText;
    public Text RightCoinText;
    public int coinright = 0;
    public int coinleft = 0;

    // Update is called once per frame
    void Update()
    {
        RightCoinText.text = "Golden Nuggets : " + coinright;
        LeftCoinText.text = "Golden Nuggets : " + coinleft;
    }
}
