using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBase : MonoBehaviour {
	/*
	public GameObject Player1Char1;  //order 0
	public GameObject Player1Char2;	 //order 1
	public GameObject Player1Char3;	//2
	public GameObject Player2Char1;//3
	public GameObject Player2Char2;//4
	public GameObject Player2Char3;//5
	*/
	public GameObject[] AllCharacters;
	public GameObject map;
	public GameObject player1Canvas;
	public GameObject player2Canvas;
	private int characterOrder = 0; // start from Player1Char1
	// Use this for initialization
	void Start () {
		for (int i = 0; i < AllCharacters.Length; ++i) {
			AllCharacters[i].GetComponent<Move>().movePower = 0;
			AllCharacters[i].GetComponent<Team>().MemberPower = 1;
			AllCharacters[i].GetComponent<Team>().BePunched = false;

		}
	}
	
	// Update is called once per frame
	void Update () {
		int oldchar = characterOrder; 
		while(AllCharacters[characterOrder] == null){
			++characterOrder;
			characterOrder %= AllCharacters.Length;
			if(AllCharacters[characterOrder] != null){
			AllCharacters[characterOrder].GetComponent<Move>().movePower = 3;
			}
		}

		if (Input.GetKeyDown ("space")|| AllCharacters[characterOrder].GetComponent<Move>().movePower <= 0) {
			//if player press space, then switch character
			//
			AllCharacters[characterOrder].GetComponent<Move>().movePower = 0;
			++characterOrder;
			characterOrder %= AllCharacters.Length;

			while(AllCharacters[characterOrder] == null){
				++characterOrder;
				characterOrder %= AllCharacters.Length;
			}
			AllCharacters[characterOrder].GetComponent<Move>().movePower = 3;

		}

		map.GetComponent<MapGenerator>().selectedCharacter = AllCharacters[characterOrder];
		if(AllCharacters[characterOrder].GetComponent<Team>().BePunched==true){
			AllCharacters [characterOrder].GetComponent<Team> ().BePunched = false;
			AllCharacters [characterOrder].GetComponent<Move> ().movePower = 0;
		}
		AllCharacters [characterOrder].GetComponent<Team> ().InMyTurn = true; 
		if (AllCharacters [characterOrder].GetComponent<Team> ().TeamNumber == 0) {
			player1Canvas.SetActive (true);
			player2Canvas.SetActive (false);
		} else {
			player1Canvas.SetActive (false);
			player2Canvas.SetActive (true);
		}

		if (oldchar != characterOrder) {
			for (int i = 0; i < AllCharacters.Length; ++i) {
				if (AllCharacters [i] != null) {
					
					//AllCharacters [i].GetComponent<Team> ().BePunched = false;
					AllCharacters [i].GetComponent<Team> ().InMyTurn = false;

				}
			}
			AllCharacters [characterOrder].GetComponent<Team> ().InMyTurn = true; 
		} else {
			AllCharacters [oldchar].GetComponent<Team> ().InMyTurn = true; 

		}

	}
}
