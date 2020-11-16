using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_FollowPath : MonoBehaviour
{
    public enum MovementType
    {
        MoveTowards,
        LerpTowards
    }

    public MovementType Type = MovementType.MoveTowards;
    public MovementPath MyPath;

    // controller variables
    public player2 player_2;
    // ---------------------------

    public float MaxDistanceToGoal = 0.1f;
    public Transform target;

    public IEnumerator<Transform> pointInPath;

    public void Start()
    {
        if (MyPath == null)
        {
            Debug.LogError("No Path Set", gameObject);
            return;
        }

        pointInPath = MyPath.GetNextPathPoint();
        pointInPath.MoveNext();

        if (pointInPath.Current == null)
        {
            Debug.LogError("No points", gameObject);
            return;
        }

        transform.position = pointInPath.Current.position;
    }

    void Update()
    {

        if (player_2.is_moving == true)
        {
            if (pointInPath == null || pointInPath.Current == null)
            {
                return;
            }

            if (Type == MovementType.MoveTowards)
            {
                transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * player_2.current_speed);
            }
            else if (Type == MovementType.LerpTowards)
            {
                transform.position = Vector3.Lerp(transform.position, pointInPath.Current.position, Time.deltaTime * player_2.current_speed);
            }

            var distanceSquared = (transform.position - pointInPath.Current.position).sqrMagnitude;
            if (distanceSquared < MaxDistanceToGoal * MaxDistanceToGoal)
            {
                pointInPath.MoveNext();
            }
        }

        //Rotation Control
        float rotationSpeed = player_2.current_speed / 10;
        Vector3 targetRotation = target.position - MyPath.PathSequence[MyPath.movingTo].position;

        float singleStep = rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(targetRotation), player_2.current_speed * Time.deltaTime);
    }
}
