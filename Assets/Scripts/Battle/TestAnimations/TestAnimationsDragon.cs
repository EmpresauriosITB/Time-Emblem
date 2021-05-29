using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimationsDragon : MonoBehaviour
{

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //MELEE ATTACK (BITE)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            anim.SetTrigger("attack1");
        }

        //RANGE ATTACK (FLAMETHROWER)
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            anim.SetTrigger("breatheFire");
        }

        //SPECIAL ATTACK
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            anim.SetTrigger("tailWhipR");

        }

        //FLY
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            anim.SetTrigger("flyAttack");
        }

        //RECIEVE DAMAGE
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            anim.SetTrigger("gotHit1");
        }

        //DIE
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            anim.SetTrigger("death");
        }
    }
}