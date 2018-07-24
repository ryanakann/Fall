//RandomPosition.cs
//Ryan Kann
//
//Purpose: Make any object rotate. Most of the time, only aesthetic, however
//can also make avoiding an obstacle a little bit harder.
//
//How to use: Add as Component of any GameObject, and set the rotateSpeed,
//rotateAxis, and clockwise bool appropriately in the Inspector.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObject : MonoBehaviour {

	public float rotateSpeed = 10f; //Degrees per second of rotation
	public Vector3 rotateAxis = Vector3.up; //About which axis the object rotates
	public bool clockwise = true; //Which way the object rotates

	// Update is called once per frame
	void Update () {
		//transform.Rotate (Vector3.up * Time.deltaTime * rotateSpeed);
		transform.RotateAround(transform.position, rotateAxis * (clockwise ? 1 : -1), Time.deltaTime * rotateSpeed);
	}
}
