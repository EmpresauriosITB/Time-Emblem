using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryIAMovement : MonoBehaviour
{
    public Transform[] points;
    int currentPoint;
    public float speed;

    private void Start()
    {
        currentPoint = 0;
    }

    private void Update()
    {
        if (transform.position != points[currentPoint].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[currentPoint].position, speed * Time.deltaTime);
            transform.LookAt(points[currentPoint].position);
        }
        else
            currentPoint = (currentPoint + 1) % points.Length;
    }
}
