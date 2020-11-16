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
    public float timer = 0;
    public Vector3 RespawnPoint = new Vector3(0,0,0);
    private bool setRespawn = false;
    public GameObject playerOne;


    private void OnTriggerStay(Collider other)
    {
       
     if (other.tag == "Kart1")
        {
            bollision = true;
            if (P1.current_speed >= maxCornerSpeed && player1follow && !setRespawn)
            {
                player1follow = false;
            }
        }
    }

    private void LateUpdate()
    {
        FallenOff();
        Respawn();
    }

    void FallenOff()
    {
        if(player1follow == false)
        {
            RespawnPoint =  playerOne.transform.position;
            AIPlayer1.enabled = false;

            //when movement in other script to this one the velocity should be kept but it will fly in a straight line
            P1.crashed = true;

            //then call respawn 
            setRespawn = true;
            player1follow = true;
            
        }
    }

    void Respawn()
    {
        if(setRespawn)
        {
            timer += Time.deltaTime;

            if (timer >= 1)
            {
                P1.current_speed = 0;
                P1.crashed = false;

                //teleport player to start of corner
                playerOne.transform.position = RespawnPoint;
                AIPlayer1.enabled = true;

                //reset timer
                timer = 0;
                setRespawn = false;
            }
        }
     
    }
}
