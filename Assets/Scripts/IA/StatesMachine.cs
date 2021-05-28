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
                    if (calculateDifference(u, a.Range))
                    {
                        InstanceAbilityData.doAbility(u.tileX, u.tileY, flag, this.gameObject);
                    }
                    
                }
                
            }
            if (this.gameObject.GetComponent<CharacterUnitController>().HasActionsLeft())
            {
                movementIA.moveIA(movementIA.setTarget());
            }

            yield return 0;
        }
        NextState();
    }

    IEnumerator NotActiveState()
    {
        while (state == State.NotActive)
        {
            
            if (this.gameObject.GetComponent<CharacterUnitController>().checkTime())
            {
                state = StatesMachine.State.Active;
            }
            yield return 0;           
        }
        NextState();
    }

    IEnumerator DeadState()
    {

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

    bool calculateDifference(Unit u, int range)
    {
        Unit ia = this.gameObject.GetComponent<Unit>();
        
        int difX = Mathf.Abs(u.tileX - ia.tileX);
        int difY = Mathf.Abs(u.tileY - ia.tileY);

        int suma = difX + difY;

        return suma <= range;
    }

}
