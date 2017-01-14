using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLight : MonoBehaviour {
	public Light ConnectLight;

	void start(){
		ConnectLight.enabled = false;
	}
	void OnTriggerEnter(){
		ConnectLight.enabled = true;
	}

	void OnTriggerExit(){
		ConnectLight.enabled = false;
	}


}
