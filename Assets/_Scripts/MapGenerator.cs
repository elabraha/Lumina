using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {

	public Transform TilePrefab;
	public int MapWidth, MapHeight;

	public Tile[,] tiles;

	void Start()
	{
		GenerateMap();
		tiles = new Tile[MapWidth, MapHeight];
	}

	public void GenerateMap() {
		for (int x = 0; x < MapWidth; ++x)
		{
			for (int y = 0; y < MapHeight; ++y)
			{
				Vector3 tilePosition = new Vector3(-MapWidth/2 + 0.5f + x, 0, -MapHeight / 2 + 0.5f + y);
				Tile tile = Instantiate(TilePrefab, tilePosition, Quaternion.Euler(Vector3.right * 90)) as Tile;
				tiles[x, y] = tile;
				tile.coordinate.x = x;
				tile.coordinate.y = y;
			}
			
		}
	}
}
