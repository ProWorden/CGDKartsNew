using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Arrow : MonoBehaviour
{
    public MovementPath m_path;
    public GameObject p1_arrow;

    // Update is called once per frame
    void Update()
    {
        if (m_path.altLeft == false)
        {
            Debug.Log("L is going straight");
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (m_path.altLeft == true)
        {
            Debug.Log("L is going left");
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
    }
}
