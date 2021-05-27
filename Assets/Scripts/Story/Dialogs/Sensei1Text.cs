using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensei1Text : MonoBehaviour
{
    public Texts texts;
    bool talking = false;
    public GameObject Sensei;
    public GameObject partner;
    GameObject partner_character;
    private Sensei2Text Sensei2Text;

    private void Start()
    {
        Sensei = GameObject.Find("Sensei_Red_Temple");
        partner = GameObject.Find("Partner");
        partner_character = partner.transform.GetChild(0).gameObject;
        Sensei2Text = FindObjectOfType<Sensei2Text>();
        Sensei2Text.gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            GameObject obj = collider.transform.GetChild(2).gameObject;
            obj.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
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
                partner.GetComponent<ActivateObject>().activatePartner();
                this.GetComponent<StoryIAMovement>().enabled = false;
            }
            if (this.gameObject.Equals(partner_character))
            {
                partner.GetComponent<ActivateObject>().disableGuards();
                partner.GetComponent<ActivateObject>().activateEnemies();
                partner.GetComponent<ActivateObject>().activatePartnerFollow();
                GetComponent<Sensei1Text>().enabled = false;
                Sensei2Text.gameObject.SetActive(true);
            }
            talking = false;
            this.gameObject.GetComponent<StoryIAMovement>().Reload();
            FindObjectOfType<ControlDialogs>().ClosePoster();
        }
    }
}
