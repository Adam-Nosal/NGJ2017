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
                int i = y * map.width + x;
                GameObject tile = Resources.Load<GameObject>(Path.Combine("Tiles", map.layers[0].data[i].ToString()));
                result[x, y] = GameObject.Instantiate(
                    tile, parent);
                result[x, y].transform.localPosition = new Vector2(x, y);
            }
        }

        return result;
	}
}
