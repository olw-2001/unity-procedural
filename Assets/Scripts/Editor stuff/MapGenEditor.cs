using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(MapGenerate))]
public class MapGenEditor : Editor
{
    public override void OnInspectorGUI() {
        MapGenerate mapGen = (MapGenerate)target;

        if(DrawDefaultInspector()) {
            if(mapGen.autoUpdate) {
                mapGen.GenerateNoise();
            }
        }

        if(GUILayout.Button("Generate map")) {
            mapGen.GenerateNoise();
        }
    }
}
