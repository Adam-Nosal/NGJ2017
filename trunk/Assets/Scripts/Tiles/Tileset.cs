using UnityEngine;

[ExecuteInEditMode]
public class Tileset : Singleton<Tileset>
{
    public GameObject[] tiles;

    public GameObject GetTile(int id) {
        return tiles[id - 1];
    }
}

