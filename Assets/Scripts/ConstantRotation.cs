using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConstantRotation : MonoBehaviour {

	[SerializeField] private float speed = 0.2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0f, speed * Time.deltaTime, 0f));

		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene (0);
		}
	}
}
