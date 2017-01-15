using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour {
	public int TeamNumber;
	public int TeamCharacterNumber;
	public bool InMyTurn = false; 
	public bool BePunched = false;

	//if merge 2 teammater, MemberPower = 2 
	public int MemberPower = 1; 


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (this.InMyTurn == true) {
			foreach (Transform child in this.gameObject.transform) {
				if (child.tag == "Halo") {
					child.gameObject.SetActive (true);
				}

			}
		}else {
			foreach (Transform child in this.gameObject.transform)
			{
					if (child.tag == "Halo") {
						child.gameObject.SetActive (false);
					}

			}

		}
	}


	void OnTriggerEnter(Collider other)
	{	
		if(other.gameObject.tag == "Player"){
			if (other.gameObject.GetComponent<Team> ().TeamNumber == this.TeamNumber) {
				//Do stuff
				AudioManager.Audio_Instance.Good.Play ();
				//check which one has smaller
				if(this.InMyTurn){
				if (other.gameObject.GetComponent<Team> ().TeamCharacterNumber > this.TeamCharacterNumber) {
					//destory this object and it's light
					//change other's side and color and memberPower
					other.gameObject.transform.localScale += new Vector3 (0.15f, 0.15f, 0.15f);
					other.gameObject.transform.GetComponentInChildren<Light> ().range += 10;
						other.gameObject.GetComponent<Team> ().MemberPower += this.MemberPower;
				
					Destroy (this.gameObject.transform.GetChild (0).gameObject);
					Destroy (this.gameObject);
					//play music/animation?
						
				} else {
					this.gameObject.transform.localScale += new Vector3 (0.15f, 0.15f, 0.15f);
					this.gameObject.transform.GetComponentInChildren<Light> ().range += 10;
						this.gameObject.GetComponent<Team> ().MemberPower += other.gameObject.GetComponent<Team> ().MemberPower;
					Destroy (other.gameObject.transform.GetChild (0).gameObject);
					Destroy (other.gameObject);
				}

			}
				} else {
				//if tigger with  enemy
				AudioManager.Audio_Instance.Bad.Play ();
				if (this.InMyTurn) {
					if (other.gameObject.GetComponent<Team> ().BePunched == false) {
						this.gameObject.GetComponent<Move> ().movePower += 3;
						other.gameObject.GetComponent<Team> ().BePunched = true;
					} 
				} else{
					if(other.gameObject.GetComponent<Team>().InMyTurn != true){
					other.gameObject.GetComponent<Team> ().BePunched = true;
					}
				}
			}
		}
	}
}
