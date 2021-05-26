using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObject : MonoBehaviour
{

    GameObject partner;

    private void Start()
    {
        partner = this.gameObject.transform.GetChild(0).gameObject;
    }
    public void activateObject()
    {
        partner.gameObject.SetActive(true);
    }
}
