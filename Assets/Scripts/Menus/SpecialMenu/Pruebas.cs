using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pruebas : MonoBehaviour
{
    public GameObject character;
    void Start()
    {
        MenuManager.setCharacter(character);
        MenuManager.OpenMenu(Menu.Drag_Menu, gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
