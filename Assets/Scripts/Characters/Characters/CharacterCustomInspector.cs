using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Character))]
public abstract class CharacterCustomInspector : Editor
{
    private Character character;
    private bool statsFoldout = false, currentStatsFoldout = false, specialPassiveFoldout = false, abilitiesFoldout = false;
    private bool statsNotNull, abilitySetNotNull, specialPassiveNotNull, abilitiesNotNull;
    private int indexer = 0;
    private bool currentStatsInit = false, abilitiesInit = false, passiveInit = false;

    public void DefaultForHierarchy()
    {
        character = (Character)target;

        character.stats = EditorGUILayout.ObjectField("StatsObject", character.GetStats(), typeof(Stats), true) as Stats;
        character.specialPassiveSettings = EditorGUILayout.ObjectField("SpecialPassive", character.GetSpecialPassiveSettings(), typeof(SpecialPassiveSettings), true) as SpecialPassiveSettings);
        character.abilitieSet = (EditorGUILayout.ObjectField("AbilitiySet", character.GetAbilitiesSet(), typeof(AbilitySet), true) as AbilitySet);

        statsNotNull = character.GetStats() != null;
        abilitySetNotNull = character.GetAbilitiesSet() != null;
        specialPassiveNotNull = character.GetSpecialPassiveSettings() != null;

        GUILayout.Space(10);

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Name");
        character.SetName(EditorGUILayout.TextField(character.GetName()));
        EditorGUILayout.EndHorizontal();

        if (statsNotNull) { 
            statsFoldout = EditorGUILayout.Foldout(statsFoldout, "Stats", true);
            if (statsFoldout) { ShowStats(); }

            currentStatsFoldout = EditorGUILayout.Foldout(currentStatsFoldout, "Current Stats", true);
            if (currentStatsFoldout) { ShowCurrentStats(); }
        }

        if (specialPassiveNotNull) {
            specialPassiveFoldout = EditorGUILayout.Foldout(specialPassiveFoldout, "Special Passive", true);
            if (specialPassiveFoldout) { ShowSpecialPassive(); }
        }

        if (abilitySetNotNull) {
            abilitiesFoldout = EditorGUILayout.Foldout(abilitiesFoldout, "Abilities", true);
            if (abilitiesFoldout) { ShowAbilities(); }
        }
    }


    private void ShowStats() {
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("HP");
        character.SetHp(EditorGUILayout.FloatField(character.GetHp()));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Physical Power");
        character.SetPhysicalPower(EditorGUILayout.FloatField(character.GetPhysicalPower()));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Physical Defense");
        character.SetPhysicalDefense(EditorGUILayout.FloatField(character.GetPhysicalDefense()));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Mental Power");
        character.SetMentalPower(EditorGUILayout.FloatField(character.GetMentalPower()));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Mental Defense");
        character.SetMentalDefense(EditorGUILayout.FloatField(character.GetMentalDefense()));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Velocity");
        character.SetVelocity(EditorGUILayout.FloatField(character.GetVelocity()));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Force Value");
        character.SetForceValue(EditorGUILayout.FloatField(character.GetForceValue()));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Grid Speed");
        character.SetGridSpeed(EditorGUILayout.FloatField(character.GetGridSpeed()));
        EditorGUILayout.EndHorizontal();

        GUILayout.Space(10);
    }

    private void ShowCurrentStats() {
        if (!currentStatsInit) {
            character.InitCurrentStats();
            currentStatsInit = true;
        }

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Current HP");
        character.SetCurrentHp((int) EditorGUILayout.Slider(character.GetCurrentHp(), 0, character.GetHp()));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Current Physical Power");
        character.SetCurrentPhysicalPower((int)EditorGUILayout.Slider(character.GetCurrentPhysicalPower(), 1, character.GetPhysicalPower()));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Current Physical Defense");
        character.SetCurrentPhysicalDefense((int)EditorGUILayout.Slider(character.GetCurrentPhysicalDefense(), 1, character.GetPhysicalDefense()));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Current Mental Power");
        character.SetCurrentMentalPower((int)EditorGUILayout.Slider(character.GetCurrentMentalPower(), 1, character.GetMentalPower()));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Current Mental Defense");
        character.SetCurrentMentalDefense((int)EditorGUILayout.Slider(character.GetCurrentMentalDefense(), 1, character.GetMentalDefense()));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Current Velocity");
        character.SetCurrentVelocity((int)EditorGUILayout.Slider(character.GetCurrentVelocity(), 1, character.GetVelocity()));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Current Grid Speed");
        character.SetCurrentGridSpeed((int)EditorGUILayout.Slider(character.GetCurrentGridSpeed(), 1, character.GetGridSpeed()));
        EditorGUILayout.EndHorizontal();

        GUILayout.Space(10);
    }

    private void ShowSpecialPassive() {
        if (!passiveInit)
        {
            character.InitSpecialPassive();
            passiveInit = true;
        }

        character.specialPassiveSettings.specialPassiveId = (SpecialPassiveCommon.SpecialPassiveId) EditorGUILayout.EnumFlagsField("SpecialPassive", character.specialPassiveSettings.specialPassiveId);

        character.UpdatePassiveScript();
    }

    private void ShowAbilities() {

        if (!abilitiesInit)
        {
            character.InitAbilities();
            abilitiesInit = true;
        }

        character.abilitieSet.abilities[indexer] = (AbilityCommon.AbiltiesId) EditorGUILayout.EnumFlagsField("Ability", character.abilitieSet.abilities[indexer]);

        EditorGUILayout.BeginHorizontal();
        if (indexer != 0) {
            if (GUILayout.Button("Previous")) {
                indexer--;
            }
        }
        if (indexer != character.GetAbilitiesSet().abilities.Count -1) {
            if (GUILayout.Button("Next")) {
                indexer++;
            }
        }
        EditorGUILayout.EndHorizontal();

        character.UpdateAbilityScript(indexer);
    }
}
