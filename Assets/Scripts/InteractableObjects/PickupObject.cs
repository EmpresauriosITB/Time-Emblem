using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public Camera pixelCamera;
    public bool onBoard;

    public void Start()
    {
        onBoard = false;
    }

    private void Update() {
        exitBoat();
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && onBoard == false)
        {
            GameObject obj = collider.transform.GetChild(2).gameObject;
            obj.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject child = this.gameObject.transform.GetChild(1).gameObject;
                child.SetActive(true);
                this.gameObject.GetComponent<PlayerController1>().camara = collider.gameObject.GetComponent<PlayerController1>().camara;
                gameObject.GetComponent<PlayerController1>().camara.transform.GetChild(0).GetComponent<PlayerFollow>().PlayerTransform = gameObject.transform;
                gameObject.GetComponent<PlayerController1>().setCanMove(true);
                collider.gameObject.SetActive(false);
                collider.gameObject.transform.SetParent(this.gameObject.transform.GetChild(0).gameObject.transform, true);
                pixelCamera.fieldOfView = 60f;
                StartCoroutine(waitBoard());
            }
        }
    }

    public void exitBoat() {
        if (onBoard == true){
            if(Input.GetKeyDown(KeyCode.E)){
                onBoard = false;
                pixelCamera.fieldOfView = 15f;
                GameObject playerPirate = this.transform.GetChild(0).GetChild(0).gameObject;
                playerPirate.SetActive(true);
                playerPirate.transform.parent = null;
                this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
                gameObject.GetComponent<PlayerController1>().camara.transform.GetChild(0).GetComponent<PlayerFollow>().PlayerTransform = GameObject.Find("Player").transform;
                gameObject.GetComponent<PlayerController1>().setCanMove(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameObject obj = other.transform.GetChild(2).gameObject;
            obj.SetActive(false);
        }
    }

    IEnumerator waitBoard()
    {
        yield return new WaitForSeconds(1);
        onBoard = true;
    }
}
