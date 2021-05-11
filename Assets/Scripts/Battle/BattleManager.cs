using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    public enum State {StartEncounter, SelectTeam, LocateTeam, StartBattle, Battle, CharacterActive, BattleStopped}
    public State currentState = State.StartEncounter;

    public TileMap tileMap;
    private GameObject activeChar;

    public GameObject playerTeam;

    public delegate void SetAllowedToClick(int x, int y);
    public event SetAllowedToClick setAllowedToClick;

    public delegate void DisableAllowedToCLick();
    public event DisableAllowedToCLick disableAllowedToCLick;

    public delegate void SetCharacterActive(bool flag);
    public event SetCharacterActive setCharacterActive;

    
    void Start()
    {
        
    }

    
    void Update()
    {
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
                DefocusCharacter();
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

        playerTeam.GetComponent<CharacterController>().setCurrentActiveCharacter += SetCurrentaActiveCharacter;

        currentState = State.Battle;
    }

    private void Next() {
        // if ()
        switch(currentState) {
            case State.SelectTeam:
                currentState = State.LocateTeam;
                break;
            case State.LocateTeam:
                currentState = State.StartBattle;
                break;
        }
    }

    private void CheckNoCurrentActivePlayer() {
        if (activeChar != null) {
            //Enseñar UI Character

            
            currentState = State.CharacterActive;
        }
    }

    private void ReaunudeGame() {}


    public void SetCurrentaActiveCharacter(GameObject character) {
        activeChar = character;
        setCharacterActive(true);    
        tileMap.setSelectedUnit(activeChar);
        Character charInfo = character.GetComponent<CharacterController>().character;
        
        Unit unit = character.GetComponent<Unit>();
        setAllowedToCLickTiles(charInfo.GetGridSpeed() ,unit.tileX, unit.tileY, -1, -1);

        MenuManager.setCharacter(charInfo);
        MenuManager.OpenMenu(Menu.Game_Menu, gameObject);
    }

    public void DefocusCharacter() {
        //if (!haveActions()) {
        //    activeChar = null;

        //    currentState = State.Battle;
        //}
    }

    private void setAllowedToCLickTiles(float movementsLeft, int x, int y, int latestX, int latestY) {
        if (movementsLeft < 0) {
            for (int i = 0; i < tileMap.graph[x,y].neighbours.Count; i++) {
                int currentX = tileMap.graph[x,y].neighbours[i].x;
                int currentY = tileMap.graph[x,y].neighbours[i].y;
                if (latestX != currentX && latestY != currentY) {
                    if (tileMap.isWalkable(x,y)) {
                        setAllowedToClick(currentX, currentY);
                        setAllowedToCLickTiles(movementsLeft - 1, currentX, currentY, x, y);
                    }
                }
            }
        }
    }

    
}
