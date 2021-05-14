using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DefaultCharacter))]
public class DefaultCustomInspector : CharacterCustomInspector
{
    // Start is called before the first frame update
    public override void OnInspectorGUI()
    {
        DefaultForHierarchy();
    }
}
