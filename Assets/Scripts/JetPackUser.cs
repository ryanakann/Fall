using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPackUser : MonoBehaviour {
	public bool jetpack;
	public float fuel;
	public Transform jetPackUI;
	public float jetPackWidth;

	// Use this for initialization
	void Start () {
		jetPackUI = GameObject.Find ("JetpackUI").transform;
		jetpack = false;
		fuel = 0f;
		jetPackUI.localScale = new Vector3 (0, jetPackUI.localScale.y, jetPackUI.localScale.z);
		//jetPackUI.gameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && fuel > 0f) {
			GetComponent<AudioSource> ().Play ();
		} else if (Input.GetKeyUp (KeyCode.Space) || fuel <= 0f) {
			GetComponent<AudioSource> ().Stop ();
		}

		if (Input.GetKey (KeyCode.Space)) 
		{
			if (fuel > 0f) {
				fuel -= Time.deltaTime * 20;
//				print ("Fuel Level: " + fuel);
				if (GetComponent<Rigidbody>().velocity.y < 0)
					GetComponent <Rigidbody> ().AddForce (new Vector3 (0f, 70f, 0f));
				jetPackUI.localScale = new Vector3 ((fuel / 100f), jetPackUI.localScale.y, jetPackUI.localScale.z);
			} else {
				jetPackUI.localScale = new Vector3 (0, jetPackUI.localScale.y, jetPackUI.localScale.z);
			}
		}

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name.Contains("JetPack"))
		{
			jetpack = true;
			fuel = 100f;
//			print ("Collected Power Up: JetPack");
//			print ("Fuel Level: " + fuel);
			jetPackUI.localScale = new Vector3 (1, jetPackUI.localScale.y, jetPackUI.localScale.z);
			//jetPackUI.gameObject.SetActive(true);
		}

	}
}
