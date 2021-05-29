using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjects1 : MonoBehaviour
{
    public Texts texts;
    bool talking = false;
    public GameObject dragon;
    LevelLoader battleLoader;

    private void Start()
    {
        dragon = GameObject.Find("DragonEnemie");
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
                if (this.gameObject.Equals(dragon))
                {
                    StartCoroutine(waitBattle());
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
            if (this.gameObject.Equals(dragon))
            {
                StartCoroutine(waitBattle());
            }

            talking = false;
            this.gameObject.GetComponent<StoryIAMovement>().Reload();
            FindObjectOfType<ControlDialogs>().ClosePoster();
        }
    }

    IEnumerator waitBattle()
    {
        yield return new WaitForSeconds(2);
        battleLoader.LoadNextLevel();
        Debug.Log("EMPIEZA BATALLA");
    }
}
