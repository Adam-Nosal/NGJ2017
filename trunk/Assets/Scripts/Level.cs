using System;
using UnityEngine;

public class Level : MonoBehaviour
{
    private static string[] levels = { "untitled" };

    public void LoadLevel(int i) 
    {
        TilemapLoader.LoadMapFromFile(levels[i], transform);
    }
}