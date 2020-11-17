using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerScript : MonoBehaviour
{
    public float maxCornerSpeed = 0;

    public MovementPath p1Spline;
    public MovementPath p2Spline;

    public bool switchableCorner = false;
    private bool onStraightP1 = true;
    private bool onStraightP2 = true;

    public AIFollowPath AIPlayer1;
    public player1 P1;
    private bool player1follow = true;
    private float timer1 = 0;
    private Vector3 RespawnPoint1 = new Vector3(0,0,0);
    private bool setRespawn1 = false;
    public GameObject playerOne;

    public P2FollowPath AIPlayer2;
    public player2 P2;
    private bool player2follow = true;
    private float timer2 = 0;
    private Vector3 RespawnPoint2 = new Vector3(0, 0, 0);
    private bool setRespawn2 = false;
    public GameObject playerTwo;


    private void OnTriggerStay(Collider other)
    {
       
     if (other.tag == "Kart1")
        {
            if (P1.current_speed >= maxCornerSpeed && player1follow && !setRespawn1)
            {
                player1follow = false;
            }
        }

        if (other.tag == "Kart2")
        {
            if (P2.current_speed >= maxCornerSpeed && player2follow && !setRespawn2)
            {
                player2follow = false;
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
        TestForTurn();

        if (player1follow == false && !onStraightP1)
        {
            RespawnPoint1 =  playerOne.transform.position;
            AIPlayer1.enabled = false;

            //when movement in other script to this one the velocity should be kept but it will fly in a straight line
            P1.crashed = true;

            //then call respawn 
            setRespawn1 = true;
            player1follow = true;
            
        }


        if (player2follow == false &&!onStraightP2)
        {
            RespawnPoint2 = playerTwo.transform.position;
            AIPlayer2.enabled = false;

            //when movement in other script to this one the velocity should be kept but it will fly in a straight line
            P2.crashed = true;

            //then call respawn 
            setRespawn2 = true;
            player2follow = true;

        }
    }

    void Respawn()
    {
        if(setRespawn1)
        {
            timer1 += Time.deltaTime;

            if (timer1 >= 1)
            {
                P1.current_speed = 0;
                P1.crashed = false;

                //teleport player to start of corner
                playerOne.transform.position = RespawnPoint1;
                AIPlayer1.enabled = true;

                //reset timer
                timer1 = 0;
                setRespawn1 = false;
            }
        }

        if (setRespawn2)
        {
            timer2 += Time.deltaTime;

            if (timer2 >= 1)
            {
                P2.current_speed = 0;
                P2.crashed = false;

                //teleport player to start of corner
                playerTwo.transform.position = RespawnPoint2;
                AIPlayer2.enabled = true;

                //reset timer
                timer2 = 0;
                setRespawn2 = false;
            }
        }

    }

    void TestForTurn()
    {
        if(switchableCorner)
        {
            if (p1Spline.altRight)
            {
                onStraightP1 = false;
            }
            else
            {
                onStraightP1 = true;
            }

            if (p2Spline.altLeft)
            {
                onStraightP2 = true;
            }
            else
            {
                onStraightP2 = false;
            }
        }
        else
        {
            onStraightP1 = false;
            onStraightP2 = false;
        }
   


        
    }
}
