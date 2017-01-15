using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMove : MonoBehaviour {
	public MapGenerator map; 
	public Coord coordinate;
	public bool walkable = true; //must manually change this in the editor if a obsticle is placed on it.
	public bool lumin = false; //lit tile by a lamp must change manually in each lamp
	public bool available = false; // set by player movement.
	// Use this for initialization
	void OnMouseUp(){
		Debug.Log("Click!");
		if(this.walkable){
<<<<<<< HEAD
			map.GetComponent<MapGenerator>().MoveSelectedCharacterTo (this.transform.position.x, this.transform.position.z);
=======
			map.MoveSelectedCharacterTo (this.transform.position.x, this.transform.position.z);
>>>>>>> 78586dc40978f60bc7dd25678a0157a3c1b508eb
		}
	}

}
