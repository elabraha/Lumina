using UnityEngine;
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

//	void Awake()
//	{
//
//	}
//
//	void Start() 
//	{
//		
//	}
	void Update() {
		if (Input.GetMouseButtonUp (1) && this.lumin && onTile) {
			luminObject.GetComponentInChildren <Light>().enabled = !luminObject.GetComponentInChildren <Light>().enabled;
		}
	}

	void OnCollisionEnter() {
		onTile = true;
	}
	void OnCollisionEnd() {
		onTile = false;
	}


	void OnMouseUp(){
		Debug.Log("Click!");
		if(this.walkable){
			map.MoveSelectedCharacterTo (this.transform.position.x, this.transform.position.z);
		}
	}
}
