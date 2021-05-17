using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    public enum State {StartEncounter, SelectTeam, LocateTeam, StartBattle, Battle, CharacterActive, BattleStopped}
    public State currentState = State.StartEncounter;

    private bool conGoNextState = true;

    public TileMap tileMap;
    private GameObject activeChar;

    public GameObject playerTeam;

    
    void Start()
    {
        
    }

    
    void Update() {
        CheckState();
    }

    private void CheckState() {
        switch (currentState) {
            case State.StartEncounter:
                StartEncounter();
                break;
            case State.SelectTeam:
                Next();
                break;
            case State.LocateTeam:
                Next();
                break;
            case State.StartBattle:
                StartBattle();
                break;
            case State.Battle:
                CheckNoCurrentActivePlayer();
                break;           
            case State.CharacterActive:
                
                break;
            case State.BattleStopped:
                ReaunudeGame();
                break;
        }
    }

    private void StartEncounter() {
        tileMap.Init(this);
        currentState = State.SelectTeam;
    }

    private void StartBattle() {
        CharacterController controller = playerTeam.GetComponent<CharacterController>();
        Unit unit = playerTeam.GetComponent<Unit>();

        controller.setCurrentActiveCharacter += SetCurrentaActiveCharacter;
        tileMap.OccupyTile(unit.tileX, unit.tileY);

        currentState = State.Battle;
    }

    private void Next() {
        if (conGoNextState) {
            switch(currentState) {
                case State.SelectTeam:
                    currentState = State.LocateTeam;
                    break;
                case State.LocateTeam:
                    currentState = State.StartBattle;
                    break; 
            }
            //conGoNextState = false;
        }
    }

    private void CheckNoCurrentActivePlayer() {
        if (isCurrentPlayerActive()) {
            Character charInfo = activeChar.GetComponent<CharacterController>().character;
            Unit unit = activeChar.GetComponent<Unit>();

            PathFind.setAllowedToCLickTiles(charInfo.currentGridSpeed ,unit.tileX, unit.tileY, true, tileMap);

            MenuManager.setCharacter(activeChar);
            MenuManager.OpenMenu(Menu.Game_Menu, gameObject);

            currentState = State.CharacterActive;
        }
    }

    public bool isCurrentPlayerActive() {
        return activeChar != null;
    }

    private void ReaunudeGame() {}


    public void SetCurrentaActiveCharacter(GameObject character) {
        if (activeChar != null) { DefocusCharacter(); }
        activeChar = character;  
        tileMap.setSelectedUnit(activeChar);  
    }

    public void DefocusCharacter() {
        Character charInfo = activeChar.GetComponent<CharacterController>().character;
        Unit unit = activeChar.GetComponent<Unit>();

        PathFind.setAllowedToCLickTiles(charInfo.currentGridSpeed ,unit.tileX, unit.tileY, false, tileMap);

        activeChar = null;
        currentState = State.Battle;
    }
}
