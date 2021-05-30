using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IATalk : MonoBehaviour
{
    public void Start()
    {
    }

    private void Update() {
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                
            }
        }
    }
}
