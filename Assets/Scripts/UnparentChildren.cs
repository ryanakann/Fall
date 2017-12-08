using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnparentChildren : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		for (int i = 0; i < transform.childCount; i++) {
			transform.GetChild (i).parent = null;
		}
		//Destroy (gameObject);
	}
}
