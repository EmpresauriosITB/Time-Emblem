using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatesMachine : MonoBehaviour
{
    public enum State
    {
        Active,
        NotActive,
        Dead,
    }

    public State state;
    movementIA movementIA;
    List<Abilities> listAbilities = new List<Abilities>();

    IEnumerator ActiveState()
    {
        Debug.Log("Active: Enter");
        while (state == State.Active)
        {
            //COMPROBAR POSICION ENEMIGOS ABILITIES
            
            //COMPROBAR SI PUEDE HACER ABILITY
            

            foreach (Abilities a in gameObject.GetComponent<CharacterUnitController>().character.abilitieSet.abilities)
            {
                if (this.gameObject.GetComponent<CharacterUnitController>().HasActionsLeft())
                {
                    GameObject go;
                    bool flag;
                    InstanceAbilityData.instanceAbility(a, gameObject.GetComponent<CharacterUnitController>().map, null);
                    if (a.TargetAllies)
                    {
                        flag = this.gameObject.GetComponent<CharacterUnitController>().isPlayer;
                    }
                    else
                    {
                        flag = !this.gameObject.GetComponent<CharacterUnitController>().isPlayer;
                    }
                    go = movementIA.locateTarget(flag);
                    Unit u = go.gameObject.GetComponent<Unit>();
                    InstanceAbilityData.doAbility(u.tileX, u.tileY, flag, this.gameObject);
                }
                
            }
            if (this.gameObject.GetComponent<CharacterUnitController>().HasActionsLeft())
            {
                movementIA.moveIA(movementIA.setTarget());
            }

            yield return 0;
        }
        Debug.Log("Active: Exit");
        NextState();
    }

    IEnumerator NotActiveState()
    {
        Debug.Log("NotActive: Enter");
        while (state == State.NotActive)
        {
            yield return 0;
            //COMPROBAR COOLDOWN
        }
        Debug.Log("NotActive: Exit");
        NextState();
    }

    IEnumerator DeadState()
    {
        Debug.Log("Dead: Enter");
        gameObject.GetComponent<CharacterUnitController>().isDead = true;
        gameObject.SetActive(false);
        yield return 0;
        
    }

    void Start()
    {
        movementIA = gameObject.GetComponent<movementIA>();
        
        NextState();
    }

    void NextState()
    {
        string methodName = state.ToString() + "State";
        System.Reflection.MethodInfo info =
            GetType().GetMethod(methodName,
                                System.Reflection.BindingFlags.NonPublic |
                                System.Reflection.BindingFlags.Instance);
        StartCoroutine((IEnumerator)info.Invoke(this, null));
    }

}
