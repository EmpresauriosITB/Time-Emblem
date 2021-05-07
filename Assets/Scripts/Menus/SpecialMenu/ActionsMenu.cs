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
        Debug.Log(character);
        Debug.Log(character.GetAbilitiesSet().abilities.Count);
            
        for (int i = 0; i < character.GetAbilitiesSet().abilities.Count; i++) {
            Abilities a = AbilityCommon.abilitiesReference[(int)character.GetAbilitiesSet().abilities[i]];
            listaAbilities.Add(a);

            Debug.Log(listaAbilities[i]);
        }
        for(int i = 0; i < listaAbilities.Count; i++)
        {
            abilitiesName = listaAbilities[i].GetName();
            Debug.Log(abilitiesName);
            textController.LogText(abilitiesName);
        }
    }
}
