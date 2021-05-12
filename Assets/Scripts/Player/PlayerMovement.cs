using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator anim;

    public float Speed;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    void Start() {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        playerMovement();
    }

    void playerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(-hor, 0f, -ver).normalized;

        if(direction.magnitude >= 0.1f)
        {

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float targetAngleV = Mathf.Atan(direction.y) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            //Debug.Log($"TargetA: {targetAngle}; angle: {angle}");
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            anim.SetBool ("Run", true);
            controller.Move(direction.normalized * Speed * Time.deltaTime);
        } else {
            anim.SetBool("Run", false);
        }
    }
}

