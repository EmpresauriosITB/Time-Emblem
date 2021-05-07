using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

[CustomEditor(typeof(TileSet))]
public class TileDataEditor : Editor
{

    public override void OnInspectorGUI()
    {
        TileSet set = (TileSet) target;

        base.OnInspectorGUI();

        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("X");
        set.changeArrayLenghtX(EditorGUILayout.IntField(set.GetX()));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Y");
        set.changeArrayLenghtY(EditorGUILayout.IntField(set.GetY()));
        GUILayout.EndHorizontal();

    }

   
}
