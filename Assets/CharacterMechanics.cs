using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMechanics : MonoBehaviour {

	public float terminalSpeed;
	private Vector3 vel;
	// Use this for initialization
	void Start () {
		//transform.position = new Vector3 (10f, 0f, 10f);
		//print (transform.GetChild (0).transform.name);
		transform.GetChild (0).transform.rotation.eulerAngles.Set (90f, 0f, 0f);
		vel = GetComponent<Rigidbody> ().velocity;
		vel = new Vector3 (0, -10f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (Mathf.Clamp (transform.position.x, -10f, 10f), transform.position.y, Mathf.Clamp (transform.position.z, -10f, 10f));

		if (Mathf.Approximately(vel.magnitude,0f) && transform.position.y < -10) {
			
		}

		if (vel.magnitude > terminalSpeed) {
			vel = new Vector3 (vel.x, -terminalSpeed, vel.z);
		}
	}

	void OnCollisionEnter (Collision other) {
		if (GetComponent<ShieldUser>().shielded == true && other.transform.root.tag == "Obstacle")
        {
			print ("Eyyyyyy");
			Destroy(other.transform.root.gameObject);
            GetComponent<ShieldUser>().shielded = false;
        }
        else
        {
			print (GetComponent<ShieldUser> ().shielded);
            SceneManager.LoadScene(0);
        }
        
	}
}
