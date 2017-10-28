using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMechanics : MonoBehaviour {

	public float terminalSpeed;
	private Rigidbody rb;
	private float maxRange = 4.2f;
	//private Vector3 prevVel;

	//private bool extraLife = false;
	// Use this for initialization
	void Start () {
		//transform.position = new Vector3 (10f, 0f, 10f);
		//print (transform.GetChild (0).transform.name);
		transform.GetChild (0).transform.rotation.eulerAngles.Set (90f, 0f, 0f);
		rb = GetComponent<Rigidbody> ();
		rb.AddForce (Vector3.down * 5, ForceMode.Impulse);
		//print (rb.velocity);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R) || Input.GetKeyDown(KeyCode.Escape)) {
			SceneManager.LoadScene (0);
		}
		transform.position = new Vector3 (Mathf.Clamp (transform.position.x, -maxRange, maxRange), transform.position.y, Mathf.Clamp (transform.position.z, -maxRange, maxRange));

		if (Mathf.Approximately(rb.velocity.magnitude,0f) && transform.position.y < -10) {
			
		}

		if (rb.velocity.magnitude > terminalSpeed) {
			rb.velocity = new Vector3 (rb.velocity.x, -terminalSpeed, rb.velocity.z);
		}
	}
		
	void OnCollisionEnter (Collision other) {
		if (GetComponent<ShieldUser>().shielded == true) //&& other.transform.root.tag == "Obstacle")
        {
			Destroy(other.transform.root.gameObject);
            GetComponent<ShieldUser>().shielded = false;
			rb.velocity = Vector3.zero;
			rb.AddForce (Vector3.down * 10, ForceMode.Impulse);
        }
        else
        {
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
        }
        
	}
}