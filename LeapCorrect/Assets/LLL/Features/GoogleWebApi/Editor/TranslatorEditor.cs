using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Translator))]
public class TranslatorEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        Translator script = (Translator)target;
        if (GUILayout.Button("PlaySound"))
        {
            script.Translate();
        }
    }
}
