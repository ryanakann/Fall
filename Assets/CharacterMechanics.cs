using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMechanics : MonoBehaviour {

	public float terminalSpeed;
	private Vector3 vel;
	//private Vector3 prevVel;

	//private bool extraLife = false;
	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (10f, 0f, 10f);
		print (transform.GetChild (0).transform.name);
		transform.GetChild (0).transform.rotation.eulerAngles.Set (90f, 0f, 0f);
		vel = GetComponent<CharacterController> ().velocity;
		vel = new Vector3 (0, -1f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		//prevVel = vel;
		transform.position = new Vector3 (Mathf.Clamp (transform.position.x, 5f, 15f), transform.position.y, Mathf.Clamp (transform.position.z, 5f, 15f));

		if (Mathf.Approximately(vel.magnitude,0f) && transform.position.y < -10) {
			
		}

		if (vel.magnitude > terminalSpeed) {
			vel = new Vector3 (0, -terminalSpeed, 0);
		}
	}

	void OnControllerColliderHit (ControllerColliderHit other) {
		print ("Controller Collision");
		SceneManager.LoadScene (0);
	}
		/*
		if (other.gameObject.name == "Power_SlowSpeed") { //If the player collides with a Slow Speed powerup
			Destroy (other.gameObject); //Destroy the power up gameObject (also stops the player for a brief moment - resetting their velocity
		} 
		else if (other.gameObject.name == "Power_ExtraLife") {
			Destroy (other.gameObject);
			extraLife = true;
		}
			
		else //Collision with other block
		{
			if (extraLife) {
				Destroy (other.gameObject);
				extraLife = false;
			} 
			else {
				SceneManager.LoadScene (0);
			}
		}
	}

	/*
	void OnCollisionEnter (Collision other) {
		if (other.gameObject.name == "Sphere") {
			//pass
		} 
		else {
			SceneManager.LoadScene (0);
		}

	}
	*/
}
