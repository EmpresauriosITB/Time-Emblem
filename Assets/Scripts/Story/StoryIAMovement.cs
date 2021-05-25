using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryIAMovement : MonoBehaviour
{
    public Transform[] points;
    int currentPoint;
    public float speed;
    public Animator anim;
    bool canMove = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
        currentPoint = 0;
    }

    private void Update()
    {
        if(canMove == true)
        {
            if (transform.position != points[currentPoint].position)
            {
                transform.position = Vector3.MoveTowards(transform.position, points[currentPoint].position, speed * Time.deltaTime);
                transform.LookAt(points[currentPoint].position);
                anim.SetBool("Idle", false);
                anim.SetBool("Run", true);
            }
            else currentPoint = (currentPoint + 1) % points.Length;
        } else
        {
            anim.SetBool("Idle", true);
            anim.SetBool("Run", false);
            transform.position = Vector3.MoveTowards(transform.position, points[currentPoint].position, speed * 0);
        }
        
    }

    public void Stop()
    {
        canMove = false;
        Debug.Log("Me paro");
    }

    public void Reload()
    {
        Debug.Log("Continuo");
        canMove = true;
    }
}
