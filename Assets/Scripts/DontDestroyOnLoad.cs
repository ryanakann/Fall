using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour {

	static GameObject instance = null;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (GetComponent<AudioSource> ());

		if (instance == null) {
			instance = gameObject;
		} else {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
