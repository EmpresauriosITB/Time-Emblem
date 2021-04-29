using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterCreator : MonoBehaviour
{
    [SerializeField] private GameObject[] charactersPrefabs;
    [SerializeField] private Material alliedMaterial;
    [SerializeField] private Material enemyMaterial;

    private Dictionary<string, GameObject> nameToCharacterDict = new Dictionary<string, GameObject>();

    private void Awake()
    {
        foreach (var character in charactersPrefabs)
        {
            nameToCharacterDict.Add(character.GetComponent<Character>().GetType().ToString(), character);
        }
    }

    public GameObject CreateCharacter(Type type)
    {
        GameObject prefab = nameToCharacterDict[type.ToString()];
        if (prefab)
        {
            GameObject newCharacter = Instantiate(prefab);
            return newCharacter;
        }
        return null;
    }

    public Material GetTeamMaterial (Teams team)
    {
        return team == Teams.Allied ? alliedMaterial : enemyMaterial;
    }
}
