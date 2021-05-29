using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableObjects1 : MonoBehaviour
{
    public Texts texts;
    bool talking = false;
    public GameObject dragon, enemie1;
    LevelLoader battleLoader;

    private void Start()
    {
        dragon = GameObject.Find("DragonEnemie");
        battleLoader = FindObjectOfType<LevelLoader>();
        GameObject enemie = GameObject.Find("Enemies");
        enemie1 = enemie.transform.GetChild(0).GetChild(0).gameObject;
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            GameObject obj = collider.transform.GetChild(2).gameObject;
            obj.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (this.gameObject.Equals(enemie1))
                {
                    StartCoroutine(waitBattle());
                }

                if (this.gameObject.Equals(dragon))
                {
                    StartCoroutine(waitBattleDragon());
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

            if (this.gameObject.Equals(enemie1))
            {
                StartCoroutine(waitBattle());
            }

            if (this.gameObject.Equals(dragon))
            {
                StartCoroutine(waitBattleDragon());
            }

            talking = false;
            this.gameObject.GetComponent<StoryIAMovement>().Reload();
            FindObjectOfType<ControlDialogs>().ClosePoster();
        }
    }

    IEnumerator waitBattle()
    {
        yield return new WaitForSeconds(2);
        battleLoader.LoadBattle4();
    }

    IEnumerator waitBattleDragon()
    {
        yield return new WaitForSeconds(2);
        battleLoader.LoadBattle5();
    }
}
