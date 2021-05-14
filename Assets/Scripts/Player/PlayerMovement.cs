using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  
    public Animator anim;
    public float Speed;
    public Rigidbody rb;
    Vector3 movement;
    public GameObject camara;
    public bool canMove;

    void Start() {
        anim = GetComponent<Animator>();
        camara = GameObject.Find("Camera");
    }
    private void Update()
    {
        if (canMove)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            if (x != 0f || z != 0f)
            {
                anim.SetBool("Run", true);
            }
            else
            {
                anim.SetBool("Run", false);
            }
            movement.x = -x;
            movement.z = -z;
        }
    }  
    
    public void setCanMove(bool flag)
    {
        canMove = flag;
    }

    private void FixedUpdate(){
        rb.MovePosition(rb.position + movement * Speed * Time.fixedDeltaTime);
    }   
}

