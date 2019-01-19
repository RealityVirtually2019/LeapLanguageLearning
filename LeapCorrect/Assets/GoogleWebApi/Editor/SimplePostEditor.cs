using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(SimplePost))]
public class SimplePostEditor : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        SimplePost script = (SimplePost)target;
        if (GUILayout.Button("Upload screen"))
        {
            script.PostSimple();
        }
    }
}