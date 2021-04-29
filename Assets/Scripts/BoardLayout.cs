using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Scriptable Objects/Board/Layout")]
public class BoardLayout : ScriptableObject
{
   [Serializable]
   private class BoardSquareSetup
    {
        public Vector2Int position;
        public Characters characterType;
        public Teams teamType;
    }

    [SerializeField] private BoardSquareSetup[] boardSquare;

    public int GetCharactersCount()
    {
        return boardSquare.Length;
    }

    public Vector2Int GetSquareCoordsAtIndex (int index)
    {
        if(boardSquare.Length <= index)
        {
            Debug.LogError("Index of character is out of range");
            return new Vector2Int(-1, -1);
        }
        return new Vector2Int(boardSquare[index].position.x - 1, boardSquare[index].position.y - 1);
    }

    public string GetSquareCharacterNameAtIndex (int index)
    {
        if (boardSquare.Length <= index)
        {
            Debug.LogError("Index of character is out of range");
            return "";
        }
        return boardSquare[index].characterType.ToString();
    }

    public Teams GetSquareTeamTypeAtIndex(int index)
    {
        if (boardSquare.Length <= index)
        {
            Debug.LogError("Index of character is out of range");
            return Teams.Enemy;
        }
        return boardSquare[index].teamType;
    }
}
