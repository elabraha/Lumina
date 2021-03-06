﻿using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{
	public Coord coordinate;
	public bool walkable = true; //must manually change this in the editor if a obsticle is placed on it.
	public bool lumin = false; //lit tile by a lamp must change manually in each lamp
	public bool available = false; // set by player movement.
	public GameObject luminObject;
	public MapGenerator map; 
	//public GameObject currplayer;
	public bool onTile = false;

	void Update() {
		if (Input.GetMouseButtonUp (1) && this.lumin && onTile) {
			print ("right click");
			print (luminObject.GetComponentInChildren <Light>().enabled + " to " + !luminObject.GetComponentInChildren <Light>().enabled);
			luminObject.GetComponentInChildren <Light>().enabled = !luminObject.GetComponentInChildren <Light>().enabled;
			AudioManager.Audio_Instance.Light.Play ();
			//luminObject.GetComponentInChildren <Behaviour>().enabled = !luminObject.GetComponentInChildren <Behaviour>().enabled;
		}
	}

	void OnTriggerEnter(Collider coll) {
		onTile = true;
		//highlightwalkableTiles ();
		print ("collide"); 
	}
	void OnTriggerExit(Collider coll) {
		onTile = false;
		//highlightwalkableTiles ();
		print ("exit"); 
	}

	void highlightwalkableTiles() {
		if (MapGenerator.Map.tiles [coordinate.x - 1, coordinate.y].GetComponent <Tile> ().walkable == true) {
			print ("??");
			MapGenerator.Map.tiles [coordinate.x - 1, coordinate.y].GetComponent <Light> ().enabled = !MapGenerator.Map.tiles [coordinate.x - 1, coordinate.y].GetComponent <Light> ().enabled;
		} else if (MapGenerator.Map.tiles [coordinate.x + 1, coordinate.y].GetComponent <Tile> ().walkable == true) {
			print ("??");
			MapGenerator.Map.tiles [coordinate.x + 1, coordinate.y].GetComponent <Light> ().enabled = !MapGenerator.Map.tiles [coordinate.x + 1, coordinate.y].GetComponent <Light> ().enabled;
		} else if (MapGenerator.Map.tiles [coordinate.x, coordinate.y - 1].GetComponent <Tile> ().walkable == true) {
			print ("??");
			MapGenerator.Map.tiles [coordinate.x, coordinate.y - 1].GetComponent <Light> ().enabled = !MapGenerator.Map.tiles [coordinate.x, coordinate.y - 1].GetComponent <Light> ().enabled;
		} else if (MapGenerator.Map.tiles [coordinate.x, coordinate.y + 1].GetComponent <Tile> ().walkable == true) {
			print ("??");
			MapGenerator.Map.tiles [coordinate.x, coordinate.y + 1].GetComponent <Light> ().enabled = !MapGenerator.Map.tiles [coordinate.x, coordinate.y + 1].GetComponent <Light> ().enabled;
		}
	}


	void OnMouseUp(){
		Debug.Log("Click!");
		AudioManager.Audio_Instance.Click.Play ();
		if(this.walkable){
			MapGenerator.Map.MoveSelectedCharacterTo (this.transform.position.x, this.transform.position.z);
		}
	}
}
