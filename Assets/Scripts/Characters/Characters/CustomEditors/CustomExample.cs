using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ExampleCharacter))]
public class CustomExample : CharacterCustomInspector
{
    public override void OnInspectorGUI()
    {
        DefaultFoHierarchy();
    }
}
