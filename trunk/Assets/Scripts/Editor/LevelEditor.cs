using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Level))]
public class LevelEditor : Editor {
    string levelToOpen = "untitled";

    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        Level level = (Level)target;
        levelToOpen = EditorGUILayout.TextField("Map Name", levelToOpen);
        if(GUILayout.Button("Load From File")) {
            level.LoadLevelByName(levelToOpen);
        }
    }
}
