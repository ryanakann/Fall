using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicLevelStart : MonoBehaviour {

	private Transform player;
	private Transform goal;
	private Vector3 vel;
	private Vector3 offset;

	private int i = 0;

	private float rotateSpeed = 33f;

	public bool intro = true;

	private float xRef = 0f, yRef = 0f, zRef = 0f;

	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		if (intro) {
			//player.GetComponent<Rigidbody> ().useGravity = false;
			player.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			goal = GameObject.FindGameObjectWithTag ("Goal").transform;
			//transform.parent = null;
			transform.position = goal.position - new Vector3 (0f, 0f, 50f);

			transform.LookAt (goal);
		} else {
			player.transform.position = Vector3.up * 75f;
			player.GetComponent<Rigidbody> ().velocity = Vector3.down * 5;
			transform.eulerAngles.Set (90f, 0f, 0f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		float xzDamp = 3f;
		float yDamp = 6f;
		if (intro) {
			transform.RotateAround (new Vector3 (0f, 0f, 0f), Vector3.up, rotateSpeed * Time.deltaTime);
			float xTarg = Mathf.SmoothDamp (transform.position.x, 0f, ref xRef, xzDamp);
			float yTarg = Mathf.SmoothDamp (transform.position.y, player.transform.position.y + 100f, ref yRef, yDamp);
			float zTarg = Mathf.SmoothDamp (transform.position.z, 0f, ref zRef, xzDamp);
			transform.position = new Vector3 (xTarg, yTarg, zTarg);
			transform.eulerAngles += new Vector3 (10 * Time.deltaTime, 0f, 0f);
			transform.eulerAngles = new Vector3 (Mathf.Clamp (transform.eulerAngles.x, 0f, 90f), transform.eulerAngles.y, transform.eulerAngles.z);
			if (-player.transform.position.y + transform.position.y > 0.5f) {
				intro = false;
				print (transform.position);
				offset = transform.position - player.position;
				PlayCamera ();
			}
			//print ("Radius: " + Mathf.Sqrt (transform.position.x * transform.position.x + transform.position.z * transform.position.z) + "\t\tyDamp: " + yDamp + "\txzDamp: " + xzDamp);
		} else {
			if (i == 0) {
				print (Time.time);
				i++;
			}
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (90f, 0f, 0f), 2 *Time.deltaTime);
			float xTarg = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref xRef, 2f);
			float yTarg = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref yRef, 2f);
			float zTarg = Mathf.SmoothDamp (transform.position.z, player.transform.position.z, ref zRef, 2f);
			transform.position = new Vector3 (xTarg, yTarg, zTarg);
		}
	}

	void PlayCamera () {
		//transform.position = player.position + offse5t;
	}
}
