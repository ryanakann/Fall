//PingPongPosition.cs
//Ryan Kann
//
//Purpose: Make levels dynamic and interesting by allowing objects to pingpong
//between two positions.
//
//How to use: Add ths as a Component to any GameObject you wish to pingpong.
//Change the speed, span, and translation axis in the Inspector.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongPosition : MonoBehaviour {

	public float speed = 10f; //The speed in units/second that the object travels
	public float span = 5f; //The number of units the object traverses before reversing
	public Vector3 translationAxis = Vector3.right; //The global axis that the object travels on.

	private Vector3 startPos;
//	private float t = 0;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = startPos + translationAxis.normalized * (Mathf.PingPong (Time.time * speed, 2 * span) - span);
	}
}
