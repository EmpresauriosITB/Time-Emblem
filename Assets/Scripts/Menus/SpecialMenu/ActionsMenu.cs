using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsMenu : MonoBehaviour
{
    public void OnClick_Back()
    {
        MenuManager.OpenMenu(Menu.Game_Menu, gameObject);
    }
}
