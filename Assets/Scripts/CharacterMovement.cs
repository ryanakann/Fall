using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour {
	Rigidbody rb;
	[SerializeField]float thrust = (float) 30.0;
	Vector3 target;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();

		
	}
	
	// Update is called once per frame
	void Update () {

		target = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical")).normalized * thrust;
		rb.velocity = new Vector3 (target.x, rb.velocity.y, target.z);

	}

	void OnCollisionEnter(Collision other) {
		//SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}
		
}
