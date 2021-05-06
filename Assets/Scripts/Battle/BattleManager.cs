using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    public enum State {StartEncounter, SelectTeam, LocateTeam, StartBattle, Battle, CharacterActive, BattleStopped}
    public State currentState = State.StartEncounter;

    public TileMap tileMap;
    private GameObject activeChar;

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
}
