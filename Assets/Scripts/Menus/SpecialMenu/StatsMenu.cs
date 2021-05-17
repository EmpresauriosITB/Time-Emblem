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
        
        HP.text = "HP: " + character.currentHp;
        PhysicalPower.text = "Physical Power: " + character.currentPhysicalPower;
        PhysicalDefense.text = "Physical Defense: " + character.currentPhysicalDefense;
        MentalPower.text = "Mental Power: " + character.currentMentalPower;
        MentalDefense.text = "Mental Defense: " + character.currentMentalDefense;
        Velocity.text = "Velocity: " + character.currentVelocity;
        ForceValue.text = "Force Value: " + character.stats.forceValue;
        GridSpeed.text = "Grid Speed: " + character.currentGridSpeed;
    }

}
