using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AbilityCustomInspector : Editor {

    private Abilities abilities;
    private bool abilityFoldout = false;
    private bool abilityNotNull;

    public void SetAbility(Abilities abilities) {
        this.abilities = abilities;
    }

    public Abilities ShowGeneralInformation(Abilities abilities) {
        Abilities a = abilities;
        abilityNotNull = abilities != null;

        abilityFoldout = EditorGUILayout.Foldout(abilityFoldout, "General Information", true);
        if (abilityFoldout && abilityNotNull) {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Name");
            a.SetName(EditorGUILayout.TextField(a.GetName()));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Power");
            a.SetPower(EditorGUILayout.IntField(a.GetPower()));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Description");
            a.SetDescription(EditorGUILayout.TextField(a.GetDescription()));
            EditorGUILayout.EndHorizontal();
        }
        return a;
    }

}
