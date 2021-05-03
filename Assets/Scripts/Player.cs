using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public Teams team { get; set;}
    public Board board { get; set; }
    public List<CharacterTest> activeCharacters { get; private set; }

    public Player(Teams team, Board board)
    {
        this.board = board;
        this.team = team;
        activeCharacters = new List<CharacterTest>();
    }

    public void AddCharacters(CharacterTest character)
    {
        if (!activeCharacters.Contains(character))
            activeCharacters.Add(character);
    }

    public void RemoveCharacter (CharacterTest character)
    {
        if (activeCharacters.Contains(character))
            activeCharacters.Remove(character);
    }

    public void GenerateAllPossibleMoves()
    {
        foreach(var character in activeCharacters)
        {
            if (board.HasCharacter(character))
                character.SelectAvaliableSquares();
        }
    }
}
