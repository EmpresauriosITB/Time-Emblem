using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameMenu : MonoBehaviour
{

    public void OnClick_Stats()
    {
        MenuManager.OpenMenu(Menu.Stats_Menu, gameObject);
    }

    public void OnClick_Abilities()
    {
        MenuManager.OpenMenu(Menu.Actions_Menu, gameObject);
    }
    public void OnClick_Drag()
    {
        MenuManager.OpenMenu(Menu.Drag_Menu, gameObject);
    }

    public void OnClick_Back()
    {
        MenuManager.OpenMenu(Menu.Game_Menu, gameObject);
    }

    
}
