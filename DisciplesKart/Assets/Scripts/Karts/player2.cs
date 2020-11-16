using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour
{
    public float current_speed;
    public float max_speed;
    public float acceleration;
    public float brake_speed;
    public bool is_moving = false;
    public bool is_braking = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("player2") > 0)
        {
            is_moving = true;

            if (current_speed <= max_speed)
            {
                current_speed += acceleration * Time.deltaTime;
            }
        }
        else if (Input.GetAxis("player2") < 0)
        {
            if (current_speed >= 0)
            {
                current_speed -= brake_speed * Time.deltaTime;
            }
        }
        else
        {
            if (current_speed >= 0)
            {
                current_speed -= acceleration * Time.deltaTime;
            }
        }

        if (current_speed <= 0)
        {
            is_moving = false;
        }
    }
}
