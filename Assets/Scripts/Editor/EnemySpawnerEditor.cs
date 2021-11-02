using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemySpawner))]
public class EnemySpawnerEditor : Editor {
    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        EnemySpawner enemySpawnerScript = (EnemySpawner) target;
        if (GUILayout.Button("New Waypoint")) {
            //GameObject newWaypoint  =
            enemySpawnerScript.CreateNewWaypoint();
            //newWaypoint.name = "Waypoint";
        }
    }

}
