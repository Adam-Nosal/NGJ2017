using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Level))]
public class LevelEditor : Editor {
    int levelToOpen = 0;

    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        Level level = (Level)target;
        if(GUILayout.Button("Load From File")) {
            level.LoadLevel(levelToOpen);
        }
        //levelToOpen = EditorGUILayout.IntField("Map Name", levelToOpen);
    }
}
