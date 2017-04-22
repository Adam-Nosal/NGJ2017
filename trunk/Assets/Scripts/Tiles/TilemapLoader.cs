using UnityEngine;
using System.IO;

public class TilemapLoader
{
    public static GameObject[,] LoadMapFromFile(string file, Transform parent)
	{
        string json = Resources.Load<TextAsset>(file).text;
		Map map = JsonUtility.FromJson<Map>(json);

        GameObject[,] result = new GameObject[map.width, map.height];

        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                for (int layIndex = 0; layIndex < map.layers.Length; layIndex++)
                {
                    int i = y * map.width + x;
                    if (Tileset.Instance != null)
                    {
                        int idx;
                        try
                        {
                            if (map.layers[layIndex].data != null)
                            {
                                idx = map.layers[layIndex].data[i];
                                if (idx == 0)
                                    continue;



                                GameObject tile = Tileset.Instance.GetTile(map.layers[layIndex].data[i]);
                                TileData tData = tile.AddComponent<TileData>();
                                tData.RoomID = map.layers[layIndex].properties.RoomID;
                                result[x, y] = GameObject.Instantiate(tile, parent);
                                result[x, y].transform.localPosition = new Vector2(x, y);
                            }
                            else
                                continue;
                        }
                        catch
                        {
                            Debug.LogWarning("Error during Level Loading");
                        }

                    }
                }
            }
        }

        return result;
	}
}
