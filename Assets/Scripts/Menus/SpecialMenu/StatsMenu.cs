using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsMenu : MonoBehaviour
{

    public Text HP;
    public Character character;


    private void Start()
    {
        setTextStats();
    }



    public void OnClick_Back()
    {
        MenuManager.OpenMenu(Menu.Game_Menu, gameObject);
    }


    public void setTextStats()
    {
   
        HP.text = "HP: " + character.GetHp()
 ;
    }

}
