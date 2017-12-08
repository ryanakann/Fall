using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMechanics : MonoBehaviour {

	public float terminalSpeed;
	public float gravityScale = -1f;
	private Rigidbody rb;
	private float maxRange = 4.2f;
	private float mostRecentSpeed;
	//private Vector3 prevVel;

	//private bool extraLife = false;
	// Use this for initialization
	void Awake () {
		Time.timeScale = 1;
		//transform.position = new Vector3 (10f, 0f, 10f);
		//print (transform.GetChild (0).transform.name);
		//transform.GetChild (0).transform.rotation.eulerAngles.Set (90f, 0f, 0f);
		rb = GetComponent<Rigidbody> ();
		rb.AddForce (Vector3.down * 5, ForceMode.Impulse);
		//rb.velocity = Vector3.down * 5;
		//print (rb.velocity);
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity += Vector3.up * gravityScale * Time.deltaTime;
		mostRecentSpeed = rb.velocity.y;
		if (Input.GetKeyDown (KeyCode.R) || Input.GetKeyDown(KeyCode.Escape)) {
			SceneManager.LoadScene (0);
		}
		/*if (Input.GetKeyDown (KeyCode.P)) {
			Time.timeScale *= 2;
		}*/
		transform.position = new Vector3 (Mathf.Clamp (transform.position.x, -maxRange, maxRange), transform.position.y, Mathf.Clamp (transform.position.z, -maxRange, maxRange));

		//if (Mathf.Approximately(rb.velocity.magnitude,0f) && transform.position.y < -10) {
			
		//}

		if (rb.velocity.magnitude > terminalSpeed) {
			rb.velocity = new Vector3 (rb.velocity.x, -terminalSpeed, rb.velocity.z);
		}

//		print (rb.velocity.y);
	}
		
	void OnCollisionEnter (Collision other) {
		if (GetComponent<ShieldUser>().shielded == true) //&& other.transform.root.tag == "Obstacle")
        {
			Destroy(other.transform.root.gameObject);
            GetComponent<ShieldUser>().shielded = false;
			GetComponent<ShieldUser>().SetShieldedProfile (false);

			//rb.velocity = Vector3.zero;
			//rb.AddForce (Vector3.down * 10, ForceMode.Impulse);
			rb.velocity = Vector3.up * mostRecentSpeed * 0.75f;

			if (PlaySound.myAS != null) {
				PlaySound.SetPitch (0.5f);
				PlaySound.Play ();
			}
        }
        else
        {
			if (PlaySound.myAS != null) {
				PlaySound.SetPitch (1f);
				PlaySound.Play ();
			}
			Time.timeScale = 1;
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
        }
        
	}
}