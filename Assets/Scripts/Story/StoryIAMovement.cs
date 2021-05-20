using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryIAMovement : MonoBehaviour
{
    public Transform[] points;
    int currentPoint;
    public float speed;
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        currentPoint = 0;
    }

    private void Update()
    {
        if (transform.position != points[currentPoint].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[currentPoint].position, speed * Time.deltaTime);
            transform.LookAt(points[currentPoint].position);
            anim.SetBool("Run", true);
        }
        else
            currentPoint = (currentPoint + 1) % points.Length;
    }
}
