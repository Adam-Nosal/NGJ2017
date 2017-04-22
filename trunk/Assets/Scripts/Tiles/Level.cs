using System;
using UnityEngine;

public class Level : Singleton<Level>
{
    private static string[] levels = { "uboat" };
    public MapObject mapObject;

    private void Start()
    {
        LoadLevelById(0);
    }

    public void LoadLevelById(int i) 
    {
        LoadLevelByName(levels[i]);
    }

    public void LoadLevelByName(string name)
    {
        mapObject = TilemapLoader.LoadMapFromFile(name, transform);
    }

    public void ReplaceInRoom(int room, GameObject old, GameObject fresh)
    {
        mapObject.rooms[room].Remove(old);
        mapObject.rooms[room].Add(fresh);
    }
}