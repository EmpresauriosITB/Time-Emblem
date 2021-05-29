using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjects : MonoBehaviour
{
    public Texts texts;
    bool talking = false;
    public GameObject Sensei, partner, partner_character, enemie1, enemie2, enemie3, sensei2;
    LevelLoader battleLoader;

    private void Start()
    {
        Sensei = GameObject.Find("Sensei_Red_Temple");
        partner = GameObject.Find("Partner");
        partner_character = partner.transform.GetChild(0).gameObject;
        GameObject enemie = GameObject.Find("Enemies");
        enemie1 = enemie.transform.GetChild(0).GetChild(0).gameObject;
        enemie2 = enemie.transform.GetChild(1).GetChild(0).gameObject;
        enemie3 = enemie.transform.GetChild(2).GetChild(0).gameObject;
        sensei2 = enemie.transform.GetChild(3).GetChild(0).gameObject;
        battleLoader = FindObjectOfType<LevelLoader>();
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            GameObject obj = collider.transform.GetChild(2).gameObject;
            obj.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (this.gameObject.Equals(enemie1) || this.gameObject.Equals(enemie2))
                {
                    StartCoroutine(waitBattle1());
                }

                if (this.gameObject.Equals(enemie3))
                {
                    StartCoroutine(waitBattle2());
                }

                if (this.gameObject.Equals(sensei2))
                {
                    StartCoroutine(waitBattle3());
                }
                talking = true;
                this.gameObject.GetComponent<StoryIAMovement>().Stop();
                FindObjectOfType<ControlDialogs>().ActivatePoster(texts);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject obj = other.transform.GetChild(2).gameObject;
        obj.SetActive(false);
        if (talking == true)
        {
            if (this.gameObject.Equals(Sensei))
            {
                EventActivatePartner();
            }
            if (this.gameObject.Equals(partner_character))
            {
                EventPartnerFollow();
            }

            if (this.gameObject.Equals(enemie1) || this.gameObject.Equals(enemie2))
            {
                StartCoroutine(waitBattle1());
            }

            if (this.gameObject.Equals(enemie3))
            {
                StartCoroutine(waitBattle2());
            }

            if (this.gameObject.Equals(sensei2))
            {
                StartCoroutine(waitBattle3());
            }

            talking = false;
            this.gameObject.GetComponent<StoryIAMovement>().Reload();
            FindObjectOfType<ControlDialogs>().ClosePoster();
        }
    }

    public void EventActivatePartner()
    {
        partner.GetComponent<ActivateObject>().activatePartner();
        this.GetComponent<StoryIAMovement>().enabled = false;
    }

    public void EventPartnerFollow()
    {
        partner.GetComponent<ActivateObject>().disableGuards();
        partner.GetComponent<ActivateObject>().activateEnemies();
        partner.GetComponent<ActivateObject>().activatePartnerFollow();
    }

    IEnumerator waitBattle1()
    {
        yield return new WaitForSeconds(2);
        battleLoader.LoadBattle1();
    }

    IEnumerator waitBattle2()
    {
        yield return new WaitForSeconds(2);
        battleLoader.LoadBattle2();
    }

    IEnumerator waitBattle3()
    {
        yield return new WaitForSeconds(2);
        battleLoader.LoadBattle3();
    }
}
