using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IObjectTweener))]

public abstract class Character : MonoBehaviour
{
    public Board board { protected get; set; }

    public Vector2Int occupiedSquare { get; set; }
    public Teams team { get; set; }
    public bool hasMoved { get; private set; }

    public List<Vector2Int> avaliableMoves;

    private IObjectTweener tweener;

    public abstract List<Vector2Int> SelectAvaliableSquares();

    private void Awake()
    {
        avaliableMoves = new List<Vector2Int>();
        tweener = GetComponent<IObjectTweener>();
        hasMoved = false;
    }

    

    public bool isFromSameTeam (Character character)
    {
        return team == character.team;
    }

    public bool CanMoveTo (Vector2Int coords)
    {
        return avaliableMoves.Contains(coords);
    }

    public virtual void MoveCharacter (Vector2Int coords)
    {
        Vector3 targetPosition = board.CalculatePositionFromCoords(coords);
        occupiedSquare = coords;
        hasMoved = true;
        tweener.MoveTo(transform, targetPosition);
    }

    protected void TryToAddMove (Vector2Int coords)
    {
        avaliableMoves.Add(coords);
    }

    public void SetData (Vector2Int coords, Teams team, Board board)
    {
        this.team = team;
        occupiedSquare = coords;
        this.board = board;
        transform.position = board.CalculatePositionFromCoords(coords);
    }

}
