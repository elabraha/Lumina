using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public AudioSource Good;
	public AudioSource Bad;
	public AudioSource Click;
	public AudioSource Light;

	public static AudioManager Audio_Instance;

	void Awake() {
		Audio_Instance = this;
	}
}
