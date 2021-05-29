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
    public CardSet player;

    public DropZone board;
    public GameObject hand;

    void Start() {}

    void Update() {
        if (BattleData.CheckIfPlayerWins()) { Debug.Log("PlayerWins"); }
        if (BattleData.CheckIfEnemyWins()) { Debug.Log("EnemyWins"); }
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
       
        instantiateCards();
        board.updateLimitNum(player.forceValue);
        currentState = GameStates.BattleManagerStates.SelectTeam;
    }

    private void instantiateCards() {
        for (int i = 0; i < player.cards.Count; i++) {
            GameObject go = player.cards[i];
            go.transform.position = Vector3.zero;
            go = GameObject.Instantiate(go);
            go.transform.parent = hand.transform;
        }

    }

    private void LocateUnits() {
        tileMap.Init(this);
        InstantiatePlayers();
        InstantiateBattleData();
        currentState = GameStates.BattleManagerStates.StartBattle;
    }

    private void InstantiateBattleData() {
        GameObject teamManager = this.gameObject.transform.parent.GetChild(0).gameObject;
        GameObject playerTeam = teamManager.transform.GetChild(0).gameObject;
        GameObject enemyTeam = teamManager.transform.GetChild(1).gameObject;
        SetTeamInBattleData(playerTeam, true);
        SetTeamInBattleData(enemyTeam, false);
    }

    private void SetTeamInBattleData(GameObject team, bool isPlayer) {
        for (int i = 0; i < team.transform.childCount; i++) {
            GameObject go = team.transform.GetChild(i).gameObject;
            if (isPlayer) { BattleData.playerTeam.Add(go); }
            else { BattleData.enemyTeam.Add(go); }
        }
    }

    public void InstantiatePlayers() {
        int x = tileMap.tileSet.playerInitX;
        int y = tileMap.tileSet.playerInitY;
        for (int i = 0; i < pt.Count; i++) {
            GameObject go = pt[i];
            Vector3 v = new Vector3(x, pt[i].gameObject.transform.position.y, y);
            Transform t = go.transform;
            t.position = v;
            go.GetComponent<CharacterUnitController>().InitBattleManager(this, tileMap);
            GameObject goInit = GameObject.Instantiate(go, t);
            goInit.transform.parent = this.gameObject.transform.parent.GetChild(0).GetChild(0);
            tileMap.OccupyTile(x,y);
            x ++;
        }
    }

    private List<GameObject> asignarBMToGameObjects(List<GameObject> list) {
        List<GameObject> listGameObjects = new List<GameObject>();
        foreach (GameObject obj in list) {
            obj.GetComponent<CharacterUnitController>().InitBattleManager(this, tileMap);
            listGameObjects.Add(obj);
        }
        return listGameObjects;
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
            CharacterUnitController charInfo = activeChar.GetComponent<CharacterUnitController>();
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
        CharacterUnitController charInfo = activeChar.GetComponent<CharacterUnitController>();
        Unit unit = activeChar.GetComponent<Unit>();

        PathFind.setAllowedToCLickTiles(charInfo.currentGridSpeed, unit.tileX, unit.tileY, true, tileMap, TileState.moving, null);
    }

    public void SetCurrentaActiveCharacter(GameObject character) {
        if (isCurrentPlayerActive()) { DefocusCharacter(); }
        activeChar = character;
        tileMap.setSelectedUnit(activeChar);
    }

    public void DefocusCharacter() {
        CharacterUnitController charInfo = activeChar.GetComponent<CharacterUnitController>();
        Unit unit = activeChar.GetComponent<Unit>();

        PathFind.setAllowedToCLickTiles(charInfo.currentGridSpeed ,unit.tileX, unit.tileY, false, tileMap, TileState.nothing, null);

        activeChar = null;
        currentState = GameStates.BattleManagerStates.Battle;
    }
}
