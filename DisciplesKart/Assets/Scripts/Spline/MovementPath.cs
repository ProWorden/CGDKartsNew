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
    public MovementPath S2;
    public MovementPath S3;
    public MovementPath S4;


    private int PATH = 2;

    public void OnDrawGizmos()
    {
        if(PathSequence == null || PathSequence.Length < 2)
        {
            return;
        }

        for (int i = 1; i < PathSequence.Length; i++)
        {
            Gizmos.DrawLine(PathSequence[i - 1].position, PathSequence[i].position);
        }

        if(PathType == PathTypes.loop)
        {
            Gizmos.DrawLine(PathSequence[0].position, PathSequence[PathSequence.Length - 1].position);
        }
    }

    public IEnumerator<Transform> GetNextPathPoint()
    {
        if (PathSequence == null || PathSequence.Length < 1)
        {
            yield break;
        }

        while (true)
        {
            yield return PathSequence[movingTo];

            if(PathSequence.Length == 1)
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
                    if (PATH == 2)
                    {
                        PathSequence = S2.PathSequence;
                    }
                    if (PATH == 3)
                    {
                        PathSequence = S3.PathSequence;
                    }
                    if (PATH == 4)
                    {
                        PathSequence = S4.PathSequence;
                    }


                    PATH++;
                }
            }

            movingTo = movingTo + movementDirection;


            if(PathType == PathTypes.loop)
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

	void Update () {
		
	}
}
