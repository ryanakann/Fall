using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindHandler : MonoBehaviour {

	bool playing;
	float startVel = 0;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		playing = false;
		GetComponent<AudioSource> ().volume = 0;
		if (GameObject.FindWithTag("Player") != null)
			rb = GameObject.FindWithTag ("Player").GetComponent<Rigidbody> ();
	}	
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<CinematicLevelStart>()) {
			if (GetComponent<CinematicLevelStart> ().intro == false) {
				if (!playing) {
					GetComponent<AudioSource> ().Play ();
					startVel = rb.velocity.y;
				}

				GetComponent<AudioSource> ().volume = Mathf.Clamp(Mathf.Abs (rb.velocity.y - startVel) / Mathf.Abs (50 - startVel), 0f, 2f);

				GetComponent<AudioSource> ().pitch = Time.timeScale;

				playing = true;
			}
		}
	}
}
