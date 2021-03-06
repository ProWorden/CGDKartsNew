﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedo : MonoBehaviour
{
    public GameObject kart;
    public player1 player1_script;

    public GameObject needle;

    private float START_SPEED_ANGLE = 130, MAX_SPEED_ANGLE = -135;

    public float speed;

    private float desired_pos;

    private void FixedUpdate()
    {
        speed = player1_script.current_speed;
        player1_script.current_speed = speed;

        GetSpeedRot();
    }

    public void GetSpeedRot()
    {
        desired_pos = START_SPEED_ANGLE - MAX_SPEED_ANGLE;
        float temp = speed / 20;
        needle.transform.eulerAngles = new Vector3(0, 0, (START_SPEED_ANGLE - temp * desired_pos));
    }
}
