using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsMenu : MonoBehaviour
{


    public Text HP;
    public Text PhysicalPower;
    public Text PhysicalDefense;
    public Text MentalPower;
    public Text MentalDefense;
    public Text Velocity;
    public Text ForceValue;
    public Text GridSpeed;

    Character character;

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        setTextStats();
    }

    public void OnClick_Back()
    {
        MenuManager.OpenMenu(Menu.Game_Menu, gameObject);
    }


    public void setTextStats()
    {
        character = MenuManager.getCharacter();
        
        HP.text = "HP: " + character.GetHp();
        PhysicalPower.text = "Physical Power: " + character.GetPhysicalPower();
        PhysicalDefense.text = "Physical Defense: " + character.GetPhysicalDefense();
        MentalPower.text = "Mental Power: " + character.GetMentalPower();
        MentalDefense.text = "Mental Defense: " + character.GetMentalDefense();
        Velocity.text = "Velocity: " + character.GetVelocity();
        ForceValue.text = "Force Value: " + character.GetForceValue();
        GridSpeed.text = "Grid Speed: " + character.GetGridSpeed();
    }

}
