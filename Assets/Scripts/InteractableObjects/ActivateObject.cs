using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObject : MonoBehaviour
{

    public GameObject partner;

    private void Start()
    {
        partner = GameObject.FindGameObjectWithTag("Partner");
        partner.gameObject.SetActive(false);
    }
    public void activateObject()
    {
        partner.gameObject.SetActive(true);
    }
}
