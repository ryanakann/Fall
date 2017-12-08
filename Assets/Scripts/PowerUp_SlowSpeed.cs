using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_SlowSpeed : MonoBehaviour {



	/*private bool triggered = false; //Activated
	private int tick = 0; //Counter
	//private Collider col; //Collider that activates the trigger (usually player)
	private float t = 1f; //Current timeScale
	private float change = 1f; //Direction of change of timeScale (either 1 or -1)
	//private float mod = .1f;
	// Use this for initialization
	void Start () {
		
	}*/
	
	// Update is called once per frame
	/*void Update () {
		//print ("TimeScale: " + t);
		//if (Camera.main.gameObject.GetComponent<CinematicLevelStart> ()) {
			//if (!Camera.main.gameObject.GetComponent<CinematicLevelStart> ().intro) {
				gradualChange (change);
			//}
		//}

		if (triggered == true) {
			change = -1f;
			tick++;
		}

		if (tick > 400) { //Max time for power up to be active
			tick = 0; //Reset tick, triggered, and change
			triggered = false;
			change = 1f;

		}
			
	}*/

	void Start () {
		//Time.timeScale = 2f;
	}

	void Update () {
		//print ("TS: " + Time.timeScale);
	}

	void OnTriggerEnter (Collider p) { //Trigger detection
//		print ("Collected Power Up: Slow Speed");
		//print (p);
		//col = p;
		//normSpeed = Time.timeScale;

		//GetComponent<MeshRenderer>().enabled = false;
		StartCoroutine("SlowSpeed");
	}

	IEnumerator SlowSpeed () {
		float startScale = Time.timeScale;
		float targScale = Time.timeScale * 0.4f;
		int msToSlow = 60;
		int msToStay = 4000;
		/*print ("Start Scale: " + startScale + "\tTarget Scale: " + targScale);
		for (int i = 0; i < msToSlow; i++) {
			Time.timeScale = Mathf.Ping(startScale, targScale, i/msToSlow);
			yield return new WaitForSeconds (0.001f);
			print ("Time Scale: " + Time.timeScale);
		}
		yield return new WaitForSeconds (msToStay / 1000);
		for (int i = 0; i < msToSlow; i++) {
			Time.timeScale = Mathf.Lerp (targScale, startScale, i/msToSlow);
			yield return new WaitForSeconds (0.001f);
			print ("Time Scale: " + Time.timeScale);
		}*/

		float startTime = Time.time;
//		int iter = 0;

		float t = startTime;
		for (int i = 0; i < msToSlow; i++) {
			t = Mathf.Lerp (startScale, targScale, (float)i / msToSlow);
			Time.timeScale = t;
			//print (i/msToSlow + "\tt: " + t);
			//print("Slowing down... i: " + i + "\tmsToSlow: " + msToSlow);
			yield return new WaitForSeconds (0.001f * t);
		}
		//print ("Out of loop");
		t = targScale;
		Time.timeScale = t;
		yield return new WaitForSeconds (msToStay / 1000 * t);
		for (int i = 0; i < msToSlow; i++) {
			t = Mathf.Lerp (targScale, startScale, (float)i / msToSlow);
			Time.timeScale = t;
			//print (i/msToSlow + "\tt: " + t);
			//print("Speeding up...");
			yield return new WaitForSeconds (0.001f * t);
		}
		t = startScale;
		//print (t);
		Time.timeScale = t;
	}

	/*void gradualChange (float x){   //x = 1 or -1 depending on rate of change
		print("Gradual change");
		t += x/(100);				//Gradually changes Time.timeScale to .4 or 1 instead of an instant change (looks nicer)
		if (t < .4f) { //Min
			t = .4f;
		}
		if (t > 1f) { //Max
			t = 1f;
		}
		Time.timeScale = t;
	}*/
}
