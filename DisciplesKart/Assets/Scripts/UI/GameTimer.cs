using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{

    public float current_time = 0;
    public float starting_time = 30;
    public Text txt;

    // Start is called before the first frame update
    void Start()
    {
        current_time = starting_time;
    }

    // Update is called once per frame
    void Update()
    {
        current_time -= 1 * Time.deltaTime;
        txt.text = current_time.ToString("0");

      /*  if (current_time <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        */
    }
}

