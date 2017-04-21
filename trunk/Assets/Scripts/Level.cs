using System;
using UnityEngine;

public class Level : MonoBehaviour
{
    private static string[] levels = { "untitled" };

    public void LoadLevelById(int i) 
    {
        LoadLevelByName(levels[i]);
    }

    public void LoadLevelByName(string name)
    {
        TilemapLoader.LoadMapFromFile(name, transform);
    }
}