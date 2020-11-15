using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFollowPath : MonoBehaviour
{
    public enum MovementType
    {
        MoveTowards,
        LerpTowards
    }

    public MovementType Type = MovementType.MoveTowards;
    public MovementPath MyPath;

    // controller variables
    public float current_speed;
    public float max_speed;
    public float acceleration;
    public float brake_speed;
    public bool is_moving = false;
    public bool is_braking = false;
    // ---------------------------
        
    public float MaxDistanceToGoal = 0.1f;
    public Transform target;

    public IEnumerator<Transform> pointInPath;

	public void Start ()
    {
		if(MyPath == null)
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
        if (Input.GetAxis("Horizontal") > 0)
        {
            is_moving = true;

            if (current_speed <= max_speed)
            {
                current_speed += acceleration * Time.deltaTime;
            }
        }
        else if (Input.GetAxis("Horizontal") < 0)
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

        if (is_moving == true)
        {
            if (pointInPath == null || pointInPath.Current == null)
            {
                return;
            }

            if (Type == MovementType.MoveTowards)
            {
                transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * current_speed);
            }
            else if (Type == MovementType.LerpTowards)
            {
                transform.position = Vector3.Lerp(transform.position, pointInPath.Current.position, Time.deltaTime * current_speed);
            }

            var distanceSquared = (transform.position - pointInPath.Current.position).sqrMagnitude;
            if (distanceSquared < MaxDistanceToGoal * MaxDistanceToGoal)
            {
                pointInPath.MoveNext();
            }
        }

        if (current_speed <= 0)
        {
            is_moving = false;
        }


        //Rotation Control
        float rotationSpeed = current_speed / 10;
        Vector3 targetRotation = target.position - MyPath.PathSequence[MyPath.movingTo].position;

        float singleStep = rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(targetRotation), current_speed * Time.deltaTime);
    }
}
