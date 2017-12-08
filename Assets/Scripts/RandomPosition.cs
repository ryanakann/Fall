using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (Random.Range (-3f, 3f), transform.position.y, Random.Range (-3f, 3f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
