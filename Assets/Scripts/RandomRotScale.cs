//RandomPosition.cs
//Ryan Kann
//
//Purpose: Give any GameObject a random Rotation and Scale to add variety.
//
//How to use: Add as Component of any GameObject, and change the scaleRange
//appropriately

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotScale : MonoBehaviour {

	public Vector2 scaleRange;

	// Use this for initialization
	void Start () {
		transform.eulerAngles = new Vector3 (Random.Range (0f, 360f), Random.Range (0f, 360f), Random.Range (0f, 360f));
		transform.localScale = new Vector3 (Random.Range (scaleRange.x, scaleRange.y), Random.Range (scaleRange.x, scaleRange.y), Random.Range (scaleRange.x, scaleRange.y));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
