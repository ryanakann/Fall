using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongPosition : MonoBehaviour {

	public float speed = 10f;
	public float span = 5f;
	public Vector3 translationAxis = Vector3.right;

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
