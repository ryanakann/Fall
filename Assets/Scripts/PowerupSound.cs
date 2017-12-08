using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSound : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			GetComponent<AudioSource> ().Play ();
			GetComponent<MeshRenderer> ().enabled = false;
			//Destroy (gameObject, 0.5f);
		}
	}
}
