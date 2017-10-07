using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUser : MonoBehaviour {
    public bool shielded;

	// Use this for initialization
	void Start () {
        shielded = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Powerup"))
        {
            shielded = true;
        }
        
    }
}
