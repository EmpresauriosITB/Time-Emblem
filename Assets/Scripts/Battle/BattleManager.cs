using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour {
    public GameStates.BattleManagerStates currentState = GameStates.BattleManagerStates.StartEncounter;

    private bool conGoNextState = false;
    public bool isDefocused = false;

    public TileMap tileMap;
    private GameObject activeChar;
    public List<GameObject> pt;
    public PlayerData player;

    public DropZone board;

    void Start() {}

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
                LocateUnits();
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

    public void allowToGoNextState() {
        conGoNextState = true;
    }

    private void StartEncounter() {
        
        MenuManager.OpenMenu(Menu.Drag_Menu, null);
        MenuManager.SetBattleManager(this);
        currentState = GameStates.BattleManagerStates.SelectTeam;
        
        board.updateLimitNum(player.forceValue); 
    }

    private void LocateUnits() {
        tileMap.Init(this);
        BattleData.enemyTeam = asignarBMToGameObjects(tileMap.getEnemies());
        pt = InstantiatePlayers();
        BattleData.playerTeam = pt;
        currentState = GameStates.BattleManagerStates.StartBattle;
    }

    public List<GameObject> InstantiatePlayers() {
        int x = tileMap.tileSet.playerInitX;
        int y = tileMap.tileSet.playerInitY;
        List<GameObject> targets = new List<GameObject>();
        for (int i = 0; i < pt.Count; i++) {
            GameObject go = pt[i];
            Vector3 v = new Vector3(x, y, pt[i].gameObject.transform.position.x);
            go.transform.position = v;
            go.GetComponent<CharacterUnitController>().InitBattleManager(this);
            GameObject.Instantiate(go);
            x ++;
            targets.Add(go);
        }

        return targets;
    }

    private List<GameObject> asignarBMToGameObjects(List<GameObject> list) {
        foreach (GameObject obj in list) {
            obj.GetComponent<CharacterUnitController>().InitBattleManager(this);
        }
        return list;
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
        for (int i = 0; i < pt.Count; i++) {
            CharacterUnitController controller = pt[i].GetComponent<CharacterUnitController>();
            Unit unit = pt[i].GetComponent<Unit>();

            controller.setCurrentActiveCharacter += SetCurrentaActiveCharacter;
            tileMap.OccupyTile(unit.tileX, unit.tileY);
        }
        tileMap.activevate = true;
        currentState = GameStates.BattleManagerStates.Battle;
    }

    private void Next() {
        if (conGoNextState) {
            switch(currentState) {
                case GameStates.BattleManagerStates.SelectTeam:
                    currentState = GameStates.BattleManagerStates.LocateTeam;
                    MenuManager.OpenMenu(Menu.Drag_Menu, MenuManager.dragMenu);
                    break;
                case GameStates.BattleManagerStates.LocateTeam:
                    currentState = GameStates.BattleManagerStates.StartBattle;
                    break; 
            }
            conGoNextState = false;
        }
    }

    private void CheckNoCurrentActivePlayer() {
        if (isCurrentPlayerActive()) {
            Character charInfo = activeChar.GetComponent<CharacterUnitController>().character;
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

    public void ShowMovementTiles() {
        Character charInfo = activeChar.GetComponent<CharacterUnitController>().character;
        Unit unit = activeChar.GetComponent<Unit>();

        PathFind.setAllowedToCLickTiles(charInfo.currentGridSpeed, unit.tileX, unit.tileY, true, tileMap, TileState.moving, null);
    }

    public void SetCurrentaActiveCharacter(GameObject character) {
        if (isCurrentPlayerActive()) { DefocusCharacter(); }
        activeChar = character;
        tileMap.setSelectedUnit(activeChar);
    }

    public void DefocusCharacter() {
        Character charInfo = activeChar.GetComponent<CharacterUnitController>().character;
        Unit unit = activeChar.GetComponent<Unit>();

        PathFind.setAllowedToCLickTiles(charInfo.currentGridSpeed ,unit.tileX, unit.tileY, false, tileMap, TileState.nothing, null);

        activeChar = null;
        currentState = GameStates.BattleManagerStates.Battle;
    }
}
