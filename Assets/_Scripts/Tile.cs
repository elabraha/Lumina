using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{
	public Coord coordinate;
	public bool walkable = true; //must manually change this in the editor if a obsticle is placed on it.
	public bool lumin = false; //lit tile by a lamp must change manually in each lamp
	public bool available = false; // set by player movement.
	public GameObject luminObject;

//	void Awake()
//	{
//
//	}
//
//	void Start() 
//	{
//		
//	}

}
