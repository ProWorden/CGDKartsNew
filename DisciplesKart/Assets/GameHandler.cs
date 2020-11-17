using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public Text LeftCoinText;
    public Text RightCoinText;
    public int coinright = 0;
    public int coinleft = 0;

    // Update is called once per frame
    void Update()
    {
        RightCoinText.text = " " + coinright;
        LeftCoinText.text = " " + coinleft;

        if (coinleft == 80)
        {
            SceneManager.LoadScene(4);
        }
        else if (coinright == 80)
        {
            SceneManager.LoadScene(3);
        }

    }
}
