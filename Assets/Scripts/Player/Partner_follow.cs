using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partner_follow : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Run()
    {
        anim.SetBool("Run", true);
    }

    public void StopRun()
    {
        anim.SetBool("Run", false);
    }
}
