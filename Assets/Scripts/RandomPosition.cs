//RandomPosition.cs
//Ryan Kann
//
//Purpose: Give any GameObject a random position at a certain elevation to
//add variety to each level attempt. Designed for Powerups specifically, but
//can be added to any GameObject.
//
//How to use: Add as Component to any GameObject you wish to have a random
//position on level start.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (Random.Range (-3f, 3f), transform.position.y, Random.Range (-3f, 3f));
	}
}
