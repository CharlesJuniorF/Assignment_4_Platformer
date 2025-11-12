using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Transform PointA;
    public Transform PointB;

    public bool moving = false;
    private bool movingToPointA = true;

    public float minDistance = 0.01f;
    public float speed = 1.2f;

    private void Update()
    {
        if (!moving) return;
        
        CheckDirection();

        if (movingToPointA)
        {
            transform.position = Vector2.MoveTowards(transform.position, PointA.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, PointB.position, speed * Time.deltaTime);
        }
    }

    private void CheckDirection()
    {
        if (movingToPointA)
        {
            if (Vector2.Distance(transform.position, PointA.position) <= minDistance)
            {
                movingToPointA = false;
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, PointB.position) <= minDistance)
            {
                movingToPointA = true;
            }
        }
    }
}
