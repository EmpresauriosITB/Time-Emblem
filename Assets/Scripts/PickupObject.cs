using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
   void OnTriggerStay(Collider collider){
       if(collider.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E)) {
           GameObject child = this.gameObject.transform.GetChild(0).gameObject;
            child.SetActive(true);
            Destroy(collider.gameObject);
       }
   }
}
