using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {
    public GameStates.BattleManagerStates currentState = GameStates.BattleManagerStates.StartEncounter;

    private bool conGoNextState = true;
    public bool isDefocused = false;

    public TileMap tileMap;
    private GameObject activeChar;

    public GameObject playerTeam;
    public GameObject enemyTeam;

    
    void Start()
    {
        
    }

    
    void Update() {
        CheckState();
    }

    private void CheckState() {
        switch (currentState) {
            case GameStates.BattleManagerStates.StartEncounter:
                StartEncounter();
                break;
            case GameStates.BattleManagerStates.SelectTeam:
                Next();
                break;
            case GameStates.BattleManagerStates.LocateTeam:
                Next();
                break;
            case GameStates.BattleManagerStates.StartBattle:
                StartBattle();
                break;
            case GameStates.BattleManagerStates.Battle:
                CheckNoCurrentActivePlayer();
                break;           
            case GameStates.BattleManagerStates.CharacterActive:
                CheckDefocusingAction();
                break;
            case GameStates.BattleManagerStates.BattleStopped:
                ReaunudeGame();
                break;
        }
    }

    private void StartEncounter() {
        tileMap.Init(this);
        currentState = GameStates.BattleManagerStates.SelectTeam;
        BattleData.enemyTeam.Add(enemyTeam);
        enemyTeam.GetComponent<CharacterController>().InitBattleManager(this);
        playerTeam.GetComponent<CharacterController>().InitBattleManager(this);
    }

    private void CheckDefocusingAction() {
        if (isDefocused) {
            DefocusCharacter();
            MenuManager.OpenMenu(Menu.Deactivate_Menus, null);
            isDefocused = false;
            currentState = GameStates.BattleManagerStates.Battle;
        }
    }

    private void StartBattle() {
        CharacterController controller = playerTeam.GetComponent<CharacterController>();
        Unit unit = playerTeam.GetComponent<Unit>();

        controller.setCurrentActiveCharacter += SetCurrentaActiveCharacter;
        tileMap.OccupyTile(unit.tileX, unit.tileY);

        currentState = GameStates.BattleManagerStates.Battle;
    }

    private void Next() {
        if (conGoNextState) {
            switch(currentState) {
                case GameStates.BattleManagerStates.SelectTeam:
                    currentState = GameStates.BattleManagerStates.LocateTeam;
                    break;
                case GameStates.BattleManagerStates.LocateTeam:
                    currentState = GameStates.BattleManagerStates.StartBattle;
                    break; 
            }
            //conGoNextState = false;
        }
    }

    private void CheckNoCurrentActivePlayer() {
        if (isCurrentPlayerActive()) {
            Character charInfo = activeChar.GetComponent<CharacterController>().character;
            Unit unit = activeChar.GetComponent<Unit>();

            PathFind.setAllowedToCLickTiles(charInfo.currentGridSpeed ,unit.tileX, unit.tileY, true, tileMap, TileState.moving, null);

            MenuManager.setCharacter(activeChar);
            MenuManager.OpenMenu(Menu.Game_Menu, null);

            currentState = GameStates.BattleManagerStates.CharacterActive;
        }
    }

    public bool isCurrentPlayerActive() {
        return activeChar != null;
    }

    private void ReaunudeGame() {

    }


    public void SetCurrentaActiveCharacter(GameObject character) {
        if (isCurrentPlayerActive()) { DefocusCharacter(); }
        activeChar = character;  
        tileMap.setSelectedUnit(activeChar);  
    }

    public void DefocusCharacter() {
        Character charInfo = activeChar.GetComponent<CharacterController>().character;
        Unit unit = activeChar.GetComponent<Unit>();

        PathFind.setAllowedToCLickTiles(charInfo.currentGridSpeed ,unit.tileX, unit.tileY, false, tileMap, TileState.nothing, null);

        activeChar = null;
        currentState = GameStates.BattleManagerStates.Battle;
    }
}
