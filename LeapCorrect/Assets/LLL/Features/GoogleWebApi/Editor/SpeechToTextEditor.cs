using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor; 
public class SpeechToTextEditor : Editor {

public override void OnInspectorGUI(){
	DrawDefaultInspector();
        DrawDefaultInspector();
        SpeechToText script = (SpeechToText)target;
        if (GUILayout.Button("PlaySound"))
        {
           // script.PlaySound();
        }
    }

}
