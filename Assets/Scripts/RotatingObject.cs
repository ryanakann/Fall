using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObject : MonoBehaviour {

	public float rotateSpeed = 10f;
	public Vector3 rotateAxis = Vector3.up;
	public bool clockwise = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Rotate (Vector3.up * Time.deltaTime * rotateSpeed);
		transform.RotateAround(transform.position, rotateAxis * (clockwise ? 1 : -1), Time.deltaTime * rotateSpeed);
	}
}
