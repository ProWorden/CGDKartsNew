using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerScript : MonoBehaviour
{
    public float maxCornerSpeed = 0;
    public AIFollowPath AIPlayer1;
    public player1 P1;
    private bool player1follow = true;
    public bool bollision = false;
    

   private void OnTriggerStay(Collider other)
    {
       
     if (other.tag == "Kart1")
        {
            bollision = true;
            if (P1.current_speed >= maxCornerSpeed)
            {
                player1follow = false;
            }
        }
    }

    private void Update()
    {
        FallenOff();
    }

    void FallenOff()
    {
        if(player1follow == false)
        {
            AIPlayer1.enabled = false;

            //when movement is in other cript to this one the velocity should be kept but it will fly in a straight line
            P1.crashed = true;

            //then call respawn after a timer
        }
    }
}
