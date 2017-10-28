using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_SlowSpeed : MonoBehaviour {

	private bool triggered = false; //Activated
	private int tick = 0; //Counter
	//private Collider col; //Collider that activates the trigger (usually player)
	private float t = 1f; //Current timeScale
	private float change = 1f; //Direction of change of timeScale (either 1 or -1)
	//private float mod = .1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//print ("TimeScale: " + t);
		gradualChange(change);
		if (triggered == true) {
			
			change = -1f;
			tick++;
		}

		if (tick > 400) { //Max time for power up to be active
			tick = 0; //Reset tick, triggered, and change
			triggered = false;
			change = 1f;

		}
			
	}

	void OnTriggerEnter (Collider p) { //Trigger detection
		print ("Collected Power Up: Slow Speed");
		//print (p);
		triggered = true; //Set as activated
		//col = p;
		GetComponent<MeshRenderer>().enabled = false;

	}

	void gradualChange (float x){   //x = 1 or -1 depending on rate of change
		t += x/(100);				//Gradually changes Time.timeScale to .4 or 1 instead of an instant change (looks nicer)
		if (t < .4f) { //Min
			t = .4f;
		}
		if (t > 1f) { //Max
			t = 1f;
		}
		Time.timeScale = t;
	}
}
