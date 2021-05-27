using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObject : MonoBehaviour
{

    GameObject partner;
    GameObject enemies;
    GameObject guards;
    GameObject partnerFollow;

    private void Start()
    {
        partner = GameObject.Find("Partner").transform.GetChild(0).gameObject;
        partnerFollow = GameObject.FindGameObjectWithTag("Player").transform.GetChild(3).GetChild(0).gameObject;
        guards = GameObject.Find("Guards");
        enemies = GameObject.Find("Enemies");
    }
    public void activatePartner()
    {
        partner.gameObject.SetActive(true);
    }

    public void activatePartnerFollow()
    {
        partner.gameObject.SetActive(false);
        partnerFollow.gameObject.SetActive(true);
    }

    public void activateEnemies() {
        for (int i = 0; i < enemies.transform.childCount; i++)
        {
            GameObject enemie = enemies.transform.GetChild(i).gameObject;
            enemie.gameObject.SetActive(true);
        }        
    }

    public void disableGuards() {
        guards.gameObject.SetActive(false);
    }
}
