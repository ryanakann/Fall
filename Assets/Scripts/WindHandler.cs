using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindHandler : MonoBehaviour {

	bool playing;

	// Use this for initialization
	void Start () {
		playing = false;
		GetComponent<AudioSource> ().volume = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<CinematicLevelStart>()) {
			if (GetComponent<CinematicLevelStart> ().intro == false) {
				if (!playing)
					GetComponent<AudioSource> ().Play ();

				GetComponent<AudioSource> ().volume += Time.deltaTime * 0.1f;


				playing = true;
			}
		}
	}
}
