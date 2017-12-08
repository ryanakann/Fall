using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotScale : MonoBehaviour {

	public Vector2 scaleRange;

	// Use this for initialization
	void Start () {
		transform.eulerAngles = new Vector3 (Random.Range (0f, 360f), Random.Range (0f, 360f), Random.Range (0f, 360f));
		transform.localScale = new Vector3 (Random.Range (scaleRange.x, scaleRange.y), Random.Range (scaleRange.x, scaleRange.y), Random.Range (scaleRange.x, scaleRange.y));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
