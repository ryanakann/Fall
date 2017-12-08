using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class ShieldUser : MonoBehaviour {
    public bool shielded;

	public PostProcessingProfile normalPP;
	public PostProcessingProfile shieldedPP;

	// Use this for initialization
	void Start () {
        shielded = false;
	}

	public void SetShieldedProfile (bool shield) {
		//transform.GetChild(0).GetComponent<PostProcessingBehaviour> ().profile = (shield ? shieldedPP : normalPP);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Shield"))
        {
            shielded = true;
			SetShieldedProfile (true);
//			print ("Collected Power Up: Shield");
        }
        
    }
}
