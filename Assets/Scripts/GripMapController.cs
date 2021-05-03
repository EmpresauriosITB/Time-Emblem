using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterCreator))]
public class GripMapController : MonoBehaviour
{
    [SerializeField] private BoardLayout startingBoardLayout;
    [SerializeField] private Board board;
    private CharacterCreator characterCreator;
    private Player alliedPlayer;
    private Player enemyPlayer;
    private Player activePlayer;

    

    private void Awake()
    {
        SetDependecies();
        CreatePlayers();
    }

    private void CreatePlayers()
    {
        alliedPlayer = new Player(Teams.Allied, board);
        enemyPlayer = new Player(Teams.Enemy, board);

    }

    private void SetDependecies()
    {
        characterCreator = GetComponent<CharacterCreator>();
    }

    void Start() 
    {
        StartNewGame();
    }

    private void StartNewGame()
    {
        board.SetDependencies(this);
        CreateCharactersFromLayout(startingBoardLayout);
        activePlayer = alliedPlayer;
        GenerateAllPossiblePlayerMoves(activePlayer);
    }

  

    private void CreateCharactersFromLayout(BoardLayout layout)
    {
        for(int i = 0; i < layout.GetCharactersCount(); i++)
        {
            Vector2Int squareCoords = layout.GetSquareCoordsAtIndex(i);
            Teams teamType = layout.GetSquareTeamTypeAtIndex(i);
            string characterType = layout.GetSquareCharacterNameAtIndex(i);

            Type type = Type.GetType(characterType);
            CreateCharacterAndInitialize(squareCoords, teamType, type);

        }
    }

    private void CreateCharacterAndInitialize(Vector2Int squareCoords, Teams team, Type type)
    {
        Character newCharacter = characterCreator.CreateCharacter(type).GetComponent<Character>();
        newCharacter.SetData(squareCoords, team, board);

        Material teamMaterial = characterCreator.GetTeamMaterial(team);

        board.SetCharacterOnBoard(squareCoords, newCharacter);

        Player currentPlayer = team == Teams.Allied ? alliedPlayer : enemyPlayer;
        currentPlayer.AddCharacters(newCharacter);
        
    }

    private void GenerateAllPossiblePlayerMoves(Player player)
    {
        player.GenerateAllPossibleMoves();
    }

    internal void EndTurn()
    {
        GenerateAllPossiblePlayerMoves(activePlayer);
        GenerateAllPossiblePlayerMoves(GetOpponentToPlayer(activePlayer));
        ChangeActiveTeam();

    }

    private void ChangeActiveTeam()
    {
        activePlayer = activePlayer == alliedPlayer ? enemyPlayer : alliedPlayer;
    }

    private Player GetOpponentToPlayer(Player player)
    {
        return player == alliedPlayer ? enemyPlayer : alliedPlayer;
    }

    public bool IsTeamTurnActive(Teams team)
    {
        return activePlayer.team == team;
    }

}
