using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMenu : MonoBehaviour
{
    public void onClick_Back()
    {
        MenuManager.OpenMenu(Menu.Start_Menu, gameObject);
    }
}

