using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SquareSelectorCreator))]
public class Board : MonoBehaviour
{
    public const int BOARD_SIZE = 8;

    [SerializeField] private Transform startTransform;
    [SerializeField] private float squareSize;

    private CharacterTest[,] grid;
    private CharacterTest selectedCharacter;
    private GripMapController controller;
    private SquareSelectorCreator squareSelector;

    private void Awake()
    {
        squareSelector = GetComponent<SquareSelectorCreator>();
        CreateGrid();

    }

    public void SetDependencies(GripMapController controller)
    {
        this.controller = controller;
    }

    private void CreateGrid()
    {
        grid = new CharacterTest[BOARD_SIZE, BOARD_SIZE];
    }
  

    public CharacterTest GetCharacterOnSquare(Vector2Int nextCoords)
    {
        if (CheckIfCoordinatedAreOnBoard(nextCoords))
            return grid[nextCoords.x, nextCoords.y];
        return null;
    }

    public Vector3 CalculatePositionFromCoords(Vector2Int coords)
    {
        return startTransform.position + new Vector3(coords.x * squareSize, 0f, coords.y * squareSize);
    }

    internal void OnSquareSelecter(Vector3 inputPosition)
    {
        Vector2Int coords = CalculateCoordFromPosition(inputPosition);
        CharacterTest character = GetCharacterOnSquare(coords);
        if (selectedCharacter)
        {
            if (character != null && selectedCharacter == character)
                DeselectCharacter();
            else if (character != null && selectedCharacter != character && controller.IsTeamTurnActive(character.team))
                SelectedCharacter(character);
            else if (selectedCharacter.CanMoveTo(coords))
                OnSelectedPieceMoved(coords, selectedCharacter);
        }
        else
        {
            if (character != null && controller.IsTeamTurnActive(character.team))
                SelectedCharacter(character);
        }

    }

    

    private void SelectedCharacter(CharacterTest character)
    {
        selectedCharacter = character;
        List<Vector2Int> selection = selectedCharacter.avaliableMoves;
        ShowSelectionSquares(selection);
    }

    private void ShowSelectionSquares(List<Vector2Int> selection)
    {
        Dictionary<Vector3, bool> squaresData = new Dictionary<Vector3, bool>();
        for (int i = 0; i <selection.Count; i++)
        {
            Vector3 position = CalculatePositionFromCoords(selection[i]);
            bool isSquareFree = GetCharacterOnSquare(selection[i]) == null;
            squaresData.Add(position, isSquareFree);
        }
        squareSelector.ShowSelection(squaresData);
    }

    private void DeselectCharacter()
    {
        selectedCharacter = null;
        squareSelector.ClearSelection();
    }

    private void OnSelectedPieceMoved(Vector2Int coords, CharacterTest character)
    {
        UpdateBoardOnCharacterMoved(coords, character.occupiedSquare, character, null);
        selectedCharacter.MoveCharacter(coords);
        DeselectCharacter();
        EndTurn();
    }

    

    private void EndTurn()
    {
        controller.EndTurn();
    }

    private void UpdateBoardOnCharacterMoved(Vector2Int newCoords, Vector2Int oldCoords, CharacterTest newCharacter, CharacterTest oldCharacter)
    {
        grid[oldCoords.x, oldCoords.y] = oldCharacter;
        grid[newCoords.x, newCoords.y] = newCharacter;
    }


    public bool CheckIfCoordinatedAreOnBoard(Vector2Int coords)
    {
        if (coords.x < 0 || coords.y < 0 || coords.x >= BOARD_SIZE || coords.y >= BOARD_SIZE)
            return false;
        return true;
    }

    private Vector2Int CalculateCoordFromPosition(Vector3 inputPosition)
    {
        int x = Mathf.FloorToInt(inputPosition.x / squareSize) + BOARD_SIZE / 2;
        int y = Mathf.FloorToInt(inputPosition.z / squareSize) + BOARD_SIZE / 2;

        return new Vector2Int(x, y);

    }

    public bool HasCharacter(CharacterTest character)
    {
        for(int i = 0; i < BOARD_SIZE; i++)
        {
            for (int j = 0; j < BOARD_SIZE; j++)
            {
                if (grid[i, j] == character)
                    return true;
            }
        }

        return false;
    }

    public void SetCharacterOnBoard(Vector2Int coords, CharacterTest character)
    {
        if (CheckIfCoordinatedAreOnBoard(coords))
            grid[coords.x, coords.y] = character;
    }
}
