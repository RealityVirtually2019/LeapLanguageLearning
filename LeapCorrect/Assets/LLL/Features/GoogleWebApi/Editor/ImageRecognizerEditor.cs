using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(ImageRecognizer))]
public class ImageRecognizerEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        ImageRecognizer script = (ImageRecognizer)target;
        if (GUILayout.Button("UploadImage"))
        {
            script.UpdloadScreen();
        }
    }
}
