using UnityEngine;

[ExecuteInEditMode]
public class Tileset : MonoBehaviour
{
    public static Tileset instance { get; private set; }

    public GameObject[] tiles;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public GameObject GetTile(int id) {
        return tiles[id - 1];
    }
}

