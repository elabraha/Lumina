using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tigger : MonoBehaviour {

	// Use this for initialization
	//public GameObject parent;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		int mp = this.transform.parent.gameObject.GetComponent<Move> ().movePower;
		if (mp > 0) {
			this.GetComponent<Light>().enabled = true;
		}else {
			this.GetComponent<Light>().enabled = false;

		}
	}
	/*
	void LightChange(){
		int mp = this.transform.parent.gameObject.GetComponent<Move> ().movePower;
		if (mp > 0) {
			this.GetComponent<Light>().enabled = true;
		}else {
			this.GetComponent<Light>().enabled = false;

		}
	}*/
}
