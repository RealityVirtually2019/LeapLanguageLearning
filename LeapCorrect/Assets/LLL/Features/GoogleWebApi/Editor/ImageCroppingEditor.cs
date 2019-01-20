using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ImageCropping))]
public class ImageCroppingEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        ImageCropping script = (ImageCropping)target;
        if (GUILayout.Button("Crop"))
        {
            script.ImageCrop();
        }
    }
}
