using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(TextToSpeech))]
public class TextToSpeechEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        TextToSpeech script = (TextToSpeech)target;
        if (GUILayout.Button("PlaySound"))
        {
            script.PlaySound();
        }
    }
}
