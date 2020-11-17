using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Arrow : MonoBehaviour
{
    public MovementPath m_path;
    public GameObject p2_arrow;

    // Update is called once per frame
    void Update()
    {
        if (m_path.altRight == false)
        {
            Debug.Log("R is going straight");
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (m_path.altRight == true)
        {
            Debug.Log("R is going left");
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
    }
}
