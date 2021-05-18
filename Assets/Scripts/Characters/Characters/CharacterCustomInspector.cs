using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CharacterCustomInspector : Editor
{
    private Character character;
    private bool statsFoldout = false, currentStatsFoldout = false, specialPassiveFoldout = false, abilitiesFoldout = false;
    private bool statsNotNull, abilitySetNotNull, specialPassiveNotNull, abilitiesNotNull;
    private int indexer = 0;
    private bool currentStatsInit = false, abilitiesInit = false, passiveInit = false;

    public override void OnInspectorGUI() {
        DefaultForHierarchy();
    }

    public void DefaultForHierarchy()
    {
        character = (Character) target;

        character.stats = EditorGUILayout.ObjectField("StatsObject", character.stats, typeof(Stats), true) as Stats;
        character.specialPassive = EditorGUILayout.ObjectField("SpecialPassive", character.specialPassive, typeof(Abilities), true) as Abilities;
        character.abilitieSet = (EditorGUILayout.ObjectField("AbilitiySet", character.abilitieSet, typeof(AbilitySet), true) as AbilitySet);

        statsNotNull = character.stats != null;
        abilitySetNotNull = character.abilitieSet != null;
        specialPassiveNotNull = character.specialPassive != null;

        GUILayout.Space(10);

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Name");
        character.characterName =  EditorGUILayout.TextField(character.characterName);
        EditorGUILayout.EndHorizontal();

        if (statsNotNull) { 
            currentStatsFoldout = EditorGUILayout.Foldout(currentStatsFoldout, "Current Stats", true);
            if (currentStatsFoldout) { ShowCurrentStats(); }
        }
    }

    private void ShowCurrentStats() {
        if (!currentStatsInit) {
            character.InitCurrentStats();
            currentStatsInit = true;
        }

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Current HP");
        character.currentHp = ((int) EditorGUILayout.Slider(character.currentHp, 0, character.stats.hp));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Current Physical Power");
        character.currentPhysicalPower = ((int)EditorGUILayout.Slider(character.currentPhysicalPower, 1, character.stats.physicalPower));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Current Physical Defense");
        character.currentPhysicalDefense = ((int)EditorGUILayout.Slider(character.currentPhysicalDefense, 1, character.stats.physicalDefense));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Current Mental Power");
        character.currentMentalPower = ((int)EditorGUILayout.Slider(character.currentMentalPower, 1, character.stats.mentalPower));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Current Mental Defense");
        character.currentMentalDefense = ((int)EditorGUILayout.Slider(character.currentMentalDefense, 1, character.stats.mentalDefense));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Current Velocity");
        character.currentVelocity = ((int)EditorGUILayout.Slider(character.currentVelocity, 1, character.stats.velocity));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Current Grid Speed");
        character.currentGridSpeed = ((int)EditorGUILayout.Slider(character.currentGridSpeed, 1, character.stats.gridSpeed));
        EditorGUILayout.EndHorizontal();

        GUILayout.Space(10);
    }
}
