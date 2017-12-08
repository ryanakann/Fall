using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {

	public static AudioSource myAS;

	// Use this for initialization
	void Start () {
		myAS = GetComponent<AudioSource> ();
	}
	
	public static void Play () {
		myAS.Play ();
	}

	public static void SetPitch (float p) {
		myAS.pitch = p;
	}
}
