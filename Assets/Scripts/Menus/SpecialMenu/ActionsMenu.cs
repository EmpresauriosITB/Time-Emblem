using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsMenu : MonoBehaviour
{
    GameObject character;
    private string abilitiesName;
    public TextLogController textController;
    public BattleManager bm;




    private void OnEnable()
    {
        setTextAbilities();
    }


    public void OnClick_Back()
    {
        textController.DeleteTextItems();
        MenuManager.OpenMenu(Menu.Game_Menu, gameObject);
        bm.ShowMovementTiles();
    }

    public void setTextAbilities()
    {
        List<Abilities> listaAbilities = new List<Abilities>();
        character = MenuManager.getCharacter();
        Character currentChar = character.GetComponent<CharacterController>().character;      
        for (int i = 0; i < currentChar.abilitieSet.abilities.Count; i++) {
            Abilities a = currentChar.abilitieSet.abilities[i];
            listaAbilities.Add(a);
        }
        for(int i = 0; i < listaAbilities.Count; i++)
        {
        
            textController.LogText(listaAbilities[i], character);
        }
    }
}
