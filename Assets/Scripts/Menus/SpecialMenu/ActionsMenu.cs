using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsMenu : MonoBehaviour
{
    Character character;
    private string abilitiesName;
    public TextLogController textController;




    private void OnEnable()
    {
        setTextAbilities();
    }
    public void OnClick_Back()
    {
        textController.DeleteTextItems();
        MenuManager.OpenMenu(Menu.Game_Menu, gameObject);
    }

    public void setTextAbilities()
    {
        List<Abilities> listaAbilities = new List<Abilities>();
        character = MenuManager.getCharacter();        
        for (int i = 0; i < character.abilitieSet.abilities.Count; i++) {
            Abilities a = character.abilitieSet.abilities[i];
            listaAbilities.Add(a);
        }
        for(int i = 0; i < listaAbilities.Count; i++)
        {
        
            textController.LogText(listaAbilities[i]);
        }
    }
}
