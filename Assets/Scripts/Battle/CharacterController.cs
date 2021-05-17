using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    public Character character;
    public int actionNum;
    private int actionsLeft;
    
    public float timeToNextActivePeriod;


    public delegate void SetCurrentActiveCharacter(GameObject activeChar);
    public event SetCurrentActiveCharacter setCurrentActiveCharacter;


    void Start() {}
    
	void OnMouseUp() {
		setCurrentActiveCharacter(this.gameObject);
	}

    public bool canCharBeActivated() {
        return timeToNextActivePeriod < Time.deltaTime;
    }

    public void ResetCooldown() {
        timeToNextActivePeriod = Time.deltaTime + character.currentVelocity;
    }

    public bool HasActionsLeft() {
        return actionsLeft < 0;
    }

    public void resetActions() {
        actionsLeft = actionNum;
    }

    public void doAction() {
        
    }
}
