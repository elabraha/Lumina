using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {

	public GameObject TilePrefab;
	public int MapWidth, MapHeight;
	public GameObject selectedCharacter;
	public GameObject[,] tiles;

	void Start()
	{
		tiles = new GameObject[MapWidth, MapHeight];
		GenerateMap();
	}

	public void GenerateMap() {
		for (int x = 0; x < MapWidth; ++x)
		{
			for (int y = 0; y < MapHeight; ++y)
			{
				Vector3 tilePosition = new Vector3(-MapWidth/2 + 0.5f + x, 0, -MapHeight / 2 + 0.5f + y);
				GameObject tile = Instantiate(TilePrefab, tilePosition, Quaternion.Euler(Vector3.right * 90)) as GameObject;
				tiles[x, y] = tile;
				tile.GetComponent<Tile>().coordinate.x = x;
				tile.GetComponent<Tile>().coordinate.y = y;
				ClickMove cm = tile.GetComponent<ClickMove> ();
				cm.map = this;
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
