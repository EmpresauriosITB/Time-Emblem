using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlliedCharacter : Character
{

    private Vector2Int[] directions = new Vector2Int[] {

        new Vector2Int(1, 1),
        new Vector2Int(1, -1),
        new Vector2Int(-1, 1),
        new Vector2Int(-1, -1),
        Vector2Int.left, 
        Vector2Int.up, 
        Vector2Int.right, 
        Vector2Int.down };

    public override List<Vector2Int> SelectAvaliableSquares()
    {
        avaliableMoves.Clear();
        float range = Board.BOARD_SIZE;
        foreach (var direction in directions)
        {
            for (int i = 1; i <= range; i++)
            {
                Vector2Int nextCoords = occupiedSquare + direction * i;
                Character character = board.GetCharacterOnSquare(nextCoords);
                if (!board.CheckIfCoordinatedAreOnBoard(nextCoords))
                    break;
                if (character == null)
                    TryToAddMove(nextCoords);
                else if (!character.isFromSameTeam(this))
                {
                    TryToAddMove(nextCoords);
                    break;
                }
                else if (character.isFromSameTeam(this))
                    break;              
            }
        }
        return avaliableMoves;
    }


}
