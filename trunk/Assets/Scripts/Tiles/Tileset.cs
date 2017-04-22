using System.Linq;
using UnityEngine;

[ExecuteInEditMode]
public class Tileset : Singleton<Tileset>
{
    public GameObject[] tiles;

    public GameObject GetTile(int id)
    {
        try
        {
            return tiles[id - 1];

        }
        catch
        {
            return tiles[0];
        }
    }



    // Toolset 


    [HideInInspector] public  Texture TileMap;
    [HideInInspector] public string PrefabsPath;
}

