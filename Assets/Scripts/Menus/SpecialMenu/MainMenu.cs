using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
  
    public void OnClick_Settings()
    {
        MenuManager.OpenMenu(Menu.Setting_Menu, gameObject);
    }

    public void OnClick_Game()
    {
        MenuManager.OpenMenu(Menu.Game_Menu, gameObject);

    }

    public void OnClick_Quit()
    {

    }
}
