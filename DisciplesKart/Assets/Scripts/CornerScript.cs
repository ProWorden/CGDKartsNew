using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerScript : MonoBehaviour
{
    public float maxCornerSpeed = 0;
    public AIFollowPath player1;
    private bool player1follow = true;
    public bool bollision = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FallenOff();
    }

    void OnTriggerEnter(Collider collision)
    {
        bollision = true;
        /*if (collision.tag == "Kart1")
        {
            
            if (player1.current_speed >= maxCornerSpeed)
            {
                player1follow = false;
            }
        }*/
    }

    void FallenOff()
    {
        if(player1follow == false)
        {
            player1.enabled = false;
        }
    }
}
