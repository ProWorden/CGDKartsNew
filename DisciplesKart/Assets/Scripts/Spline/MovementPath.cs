using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPath : MonoBehaviour
{
    public enum PathTypes
    {
        linear,
        loop,
    }

    public PathTypes PathType;
    public int movementDirection = 1;
    public int movingTo = 0;
    public Transform[] PathSequence;
    public bool LeftKart = false;
    public bool RightKart = false;
    public MovementPath[] LeftPaths;
    public MovementPath[] RightPaths;
    public MovementPath[] SharedPaths;

    private int LEFT = 2;
    private int RIGHT = 2;

    public bool altLeft = false;
    public bool altRight = false;

    /*public void OnDrawGizmos()
    {
        if (PathSequence == null || PathSequence.Length < 2)
        {
            return;
        }

        for (int i = 1; i < PathSequence.Length; i++)
        {
            Gizmos.DrawLine(PathSequence[i - 1].position, PathSequence[i].position);
        }

        if (PathType == PathTypes.loop)
        {
            Gizmos.DrawLine(PathSequence[0].position, PathSequence[PathSequence.Length - 1].position);
        }
    }*/

    public IEnumerator<Transform> GetNextPathPoint()
    {
        if (PathSequence == null || PathSequence.Length < 1)
        {
            yield break;
        }

        while (true)
        {
            yield return PathSequence[movingTo];

            if (PathSequence.Length == 1)
            {
                continue;
            }

            if (PathType == PathTypes.linear)
            {
                if (movingTo <= 0)
                {
                    movementDirection = 1;
                }
                else if (movingTo >= PathSequence.Length - 1)
                {
                    movingTo = 0;
                    NextSpline();
                }
            }

            movingTo = movingTo + movementDirection;

            if (PathType == PathTypes.loop)
            {
                if (movingTo >= PathSequence.Length)
                {
                    movingTo = 0;
                }
                if (movingTo < 0)
                {
                    movingTo = PathSequence.Length - 1;
                }
            }
        }
    }

    void NextSpline()
    {
        movingTo = 0;

        #region Left Kart Path Swapping

        if (LeftKart)
        {
            if (LEFT == 2)
            {
                PathSequence = SharedPaths[0].PathSequence;
                LEFT = 3;
                return;
            }
            if(LEFT == 3)
            {
                PathSequence = LeftPaths[1].PathSequence;
                LEFT = 4;
                return;
            }

            //Left
            if (LEFT == 4 && altLeft)
            {
                PathSequence = LeftPaths[2].PathSequence;
                LEFT = 5;
                return;
            }
            if (LEFT == 5 )
            {
                PathSequence = SharedPaths[1].PathSequence;
                LEFT = 6;
                return;
            }
            //If LEFT == 14 then track joins to here
            if (LEFT == 6)
            {
                PathSequence = LeftPaths[13].PathSequence;
                LEFT = 7;
                return;
            }
            //   ----> Final Section

            //Straight
            if (LEFT == 4 && !altLeft)
            {
                PathSequence = LeftPaths[3].PathSequence;
                LEFT = 11;
                return;
            }
            if (LEFT == 11)
            {
                PathSequence = SharedPaths[2].PathSequence;
                LEFT = 12;
                return;
            }
            if (LEFT == 12)
            {
                PathSequence = LeftPaths[4].PathSequence;
                LEFT = 13;
                return;
            }

            //Left
            if (LEFT == 13 && altLeft)
            {
                PathSequence = LeftPaths[5].PathSequence;
                LEFT = 14;
                return;
            }
            if (LEFT == 14)
            {
                PathSequence = SharedPaths[4].PathSequence;
                LEFT = 6;
                return;
            }
            //   ---> Joins Section 6

            //Straight
            if (LEFT == 13 && !altLeft)
            {
                PathSequence = LeftPaths[6].PathSequence;
                LEFT = 15;
                return;
            }

            //Left
            if (LEFT == 15 && altLeft)
            {
                PathSequence = LeftPaths[7].PathSequence;
                LEFT = 18;
                return;
            }
            // ---> Joins Section 10

            //Straight
            if (LEFT == 15 && !altLeft)
            {
                PathSequence = LeftPaths[8].PathSequence;
                LEFT = 16;
                return;
            }
            if (LEFT == 16)
            {
                PathSequence = SharedPaths[3].PathSequence;
                LEFT = 17;
                return;
            }
            if (LEFT == 17)
            {
                PathSequence = LeftPaths[9].PathSequence;
                LEFT = 18;
                return;
            }
            //   ---> Joins Section 10

            //Section 10
            if (LEFT == 18)
            {
                PathSequence = LeftPaths[10].PathSequence;
                LEFT = 7;
                return;
            }
            //   ---> Join Final Section
            
            
            //Final Section
            if (LEFT == 7)
            {
                PathSequence = LeftPaths[11].PathSequence;
                LEFT = 8;
                return;
            }
            if (LEFT == 8)
            {
                PathSequence = SharedPaths[5].PathSequence;
                LEFT = 9;
                return;
            }
            if (LEFT == 9)
            {
                PathSequence = LeftPaths[12].PathSequence;
                LEFT = 10;
                return;
            }
            if (LEFT == 10)
            {
                PathSequence = LeftPaths[14].PathSequence;
                LEFT = 2;
                return;
            }
        }

        #endregion

        #region Right Kart Path Swapping

        if (RightKart)
        {
            if (RIGHT == 2)
            {
                PathSequence = SharedPaths[0].PathSequence;
                RIGHT = 3;
                return;
            }
            if (RIGHT == 3)
            {
                PathSequence = RightPaths[1].PathSequence;
                RIGHT = 4;
                return;
            }

            //Left
            if (RIGHT == 4 && altRight)
            {
                PathSequence = RightPaths[2].PathSequence;
                RIGHT = 5;
                return;
            }
            if (RIGHT == 5)
            {
                PathSequence = SharedPaths[1].PathSequence;
                RIGHT = 6;
                return;
            }
            //If RIGHT == 14 then track joins to here
            if (RIGHT == 6)
            {
                PathSequence = RightPaths[13].PathSequence;
                RIGHT = 7;
                return;
            }
            //   ----> Final Section

            //Straight
            if (RIGHT == 4 && !altRight)
            {
                PathSequence = RightPaths[3].PathSequence;
                RIGHT = 11;
                return;
            }
            if (RIGHT == 11)
            {
                PathSequence = SharedPaths[2].PathSequence;
                RIGHT = 12;
                return;
            }
            if (RIGHT == 12)
            {
                PathSequence = RightPaths[4].PathSequence;
                RIGHT = 13;
                return;
            }

            //Left
            if (RIGHT == 13 && altRight)
            {
                PathSequence = RightPaths[5].PathSequence;
                RIGHT = 14;
                return;
            }
            if (RIGHT == 14)
            {
                PathSequence = SharedPaths[4].PathSequence;
                RIGHT = 6;
                return;
            }
            //   ---> Joins Section 6

            //Straight
            if (RIGHT == 13 && !altRight)
            {
                PathSequence = RightPaths[6].PathSequence;
                RIGHT = 15;
                return;
            }

            //Left
            if (RIGHT == 15 && altRight)
            {
                PathSequence = RightPaths[7].PathSequence;
                RIGHT = 18;
                return;
            }
            // ---> Joins Section 10

            //Straight
            if (RIGHT == 15 && !altRight)
            {
                PathSequence = RightPaths[8].PathSequence;
                RIGHT = 16;
                return;
            }
            if (RIGHT == 16)
            {
                PathSequence = SharedPaths[3].PathSequence;
                RIGHT = 17;
                return;
            }
            if (RIGHT == 17)
            {
                PathSequence = RightPaths[9].PathSequence;
                RIGHT = 18;
                return;
            }
            //   ---> Joins Section 10

            //Section 10
            if (RIGHT == 18)
            {
                PathSequence = RightPaths[10].PathSequence;
                RIGHT = 7;
                return;
            }
            //   ---> Join Final Section


            //Final Section
            if (RIGHT == 7)
            {
                PathSequence = RightPaths[11].PathSequence;
                RIGHT = 8;
                return;
            }
            if (RIGHT == 8)
            {
                PathSequence = SharedPaths[5].PathSequence;
                RIGHT = 9;
                return;
            }
            if (RIGHT == 9)
            {
                PathSequence = RightPaths[12].PathSequence;
                RIGHT = 10;
                return;
            }
            if (RIGHT == 10)
            {
                PathSequence = RightPaths[14].PathSequence;
                RIGHT = 2;
                return;
            }
        }
        #endregion

    }

    void Update()
    {
        if (LeftKart)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                altLeft = !altLeft;
            }
        }
        if (RightKart)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                altRight = !altRight;
            }
        }
    }
}