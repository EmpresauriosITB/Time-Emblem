using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimations : MonoBehaviour
{

    public Animator anim;
    public GameObject heal;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //MELEE ATTACK
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            anim.SetTrigger("PunchTrigger");
        }

        //RANGE ATTACK
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            anim.SetTrigger("RangeAttack1Trigger");
        }

        //SPECIAL ATTACK
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            StartCoroutine(waitHeal());
            
        }

        //BLOCK DAMAGE
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            StartCoroutine(waitBlock());
        }

        //RECIEVE DAMAGE
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            anim.SetTrigger("LightHitTrigger");
        }

        //DIE
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            anim.SetTrigger("DeathTrigger");
        }
    }

    IEnumerator waitBlock()
    {
        anim.SetBool("Block", true);
        yield return new WaitForSeconds(2);
        anim.SetBool("Block", false);
    }

    IEnumerator waitHeal()
    {
        anim.SetTrigger("SpecialAttack1Trigger");
        heal.SetActive(true);
        yield return new WaitForSeconds(3);
        heal.SetActive(false);
    }
}
