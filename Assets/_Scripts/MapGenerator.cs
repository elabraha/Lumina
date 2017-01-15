using UnityEngine;
using System.Collections;
using System;

public class MapGenerator : MonoBehaviour {
	
	public GameObject tilePrefab;
	public GameObject brickPrefab;
	public GameObject waterTilePrefab;
	public GameObject luminPrefab;
	public int MapWidth, MapHeight;
	public GameObject selectedCharacter;
	public TextAsset mapFile;
	public GameObject[,] tiles;

	public static MapGenerator Map;

	void Awake() {
		if (Map != null) {
			Debug.Log ("more than one map ERROR!!!");
		} else {
			Map = this;
		}
	}

	void Start()
	{
		//mapFile = Resources.Load("mapfile1.txt") as TextAsset;
		tiles = new GameObject[MapWidth, MapHeight];
		GenerateMap();
	}

	public void GenerateMap() {
		string[] filelines;
		filelines = mapFile.text.Split('\n');
		for (int y = 0; y < MapHeight; ++y)
		{
			char[] line = filelines [y].ToCharArray ();
			for (int x = 0; x < MapWidth; ++x)
			{

				if (line [x] == 'G') { 
					Vector3 tilePosition = new Vector3 (-MapWidth / 2 + 0.5f + x, 0, -MapHeight / 2 + 0.5f + y);
					GameObject tile = Instantiate (tilePrefab, tilePosition, Quaternion.Euler (Vector3.right * 90)) as GameObject;
					tiles [x, y] = tile;
					tile.GetComponent<Tile> ().coordinate.x = x;
					tile.GetComponent<Tile> ().coordinate.y = y;
					Tile cm = tile.GetComponent<Tile> ();
					cm.map = this;
				} else if (line [x] == 'B') {
					Vector3 tilePosition = new Vector3 (-MapWidth / 2 + 0.5f + x, 0.5f, -MapHeight / 2 + 0.5f + y);
					GameObject tile = Instantiate (brickPrefab, tilePosition, Quaternion.identity) as GameObject;
					tiles [x, y] = tile;
					tile.GetComponent<Tile> ().coordinate.x = x;
					tile.GetComponent<Tile> ().coordinate.y = y;
					tile.GetComponent<Tile> ().walkable = false;
					
				} else if (line [x] == 'W') {
					Vector3 tilePosition = new Vector3 (-MapWidth / 2 + 0.5f + x, 0, -MapHeight / 2 + 0.5f + y);
					GameObject tile = Instantiate (waterTilePrefab, tilePosition, Quaternion.Euler (Vector3.right * 90)) as GameObject;
					tiles [x, y] = tile;
					tile.GetComponent<Tile> ().coordinate.x = x;
					tile.GetComponent<Tile> ().coordinate.y = y;
					tile.GetComponent<Tile> ().walkable = false;
				} else if (line [x] == 'L') {
					Vector3 tilePosition = new Vector3 (-MapWidth / 2 + 0.5f + x, 0, -MapHeight / 2 + 0.5f + y);
					GameObject tile = Instantiate (tilePrefab, tilePosition, Quaternion.Euler (Vector3.right * 90)) as GameObject;
					Vector3 luminPosition = new Vector3 (-MapWidth / 2 + 0.5f + x, 0, -MapHeight / 2 + 0.5f + y);
					GameObject lumin = Instantiate (luminPrefab, tilePosition, Quaternion.identity) as GameObject;
					tiles [x, y] = tile;
					tile.GetComponent<Tile> ().coordinate.x = x;
					tile.GetComponent<Tile> ().coordinate.y = y;
					tile.GetComponent<Tile> ().lumin = true;
					tile.GetComponent<Tile> ().luminObject = lumin;
					Tile cm = tile.GetComponent<Tile> ();
					cm.map = this;
				}
				else {
					Debug.Log ("Wrong Char input! " + line[x]);
				} 
			}
			
		}
	}


	public void MoveSelectedCharacterTo(float x, float z){
		int mp = selectedCharacter.GetComponent<Move> ().movePower;
		float stepMove = (selectedCharacter.transform.position - new Vector3 (x, selectedCharacter.transform.position.y, z)).magnitude;
		if(stepMove == 1 && mp > 0){
		selectedCharacter.transform.position = new Vector3 (x,0, z);
			selectedCharacter.GetComponent<Move> ().movePower--;
	}
	}
}
