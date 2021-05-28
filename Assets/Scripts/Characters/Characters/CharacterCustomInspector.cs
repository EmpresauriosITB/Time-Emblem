using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CharacterCustomInspector : Editor
{
    private Character character;
    public override void OnInspectorGUI() {
        DefaultForHierarchy();
    }

    public void DefaultForHierarchy()
    {
        character = (Character) target;

        character.stats = EditorGUILayout.ObjectField("StatsObject", character.stats, typeof(Stats), true) as Stats;
        character.specialPassive = EditorGUILayout.ObjectField("SpecialPassive", character.specialPassive, typeof(Abilities), true) as Abilities;
        character.abilitieSet = (EditorGUILayout.ObjectField("AbilitiySet", character.abilitieSet, typeof(AbilitySet), true) as AbilitySet);

        GUILayout.Space(10);

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Name");
        character.characterName =  EditorGUILayout.TextField(character.characterName);
        EditorGUILayout.EndHorizontal();
    }
}
