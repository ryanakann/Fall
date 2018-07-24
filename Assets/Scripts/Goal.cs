//Goal.cs
//Ryan Kann
//
//Purpose: Ensures that the Player properly transitions to the next level.
//
//How to use: Add as a component to any GameObject with a Collider (with Trigger
//checked), and with the "Goal" tag. A prefab for this already exists called
//"Goal". The only thing you have to be cogniscent of is that the "isLastLevel"
//bool should only be checked on the last level, as it will replace the level
//transition with a special one. Also make sure there is a UI Textbox called
//"LastLevel" with whatever text you want it to display at the end. If you don't
//want text at the end, you still need this, just set the text to "".

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Goal : MonoBehaviour {

	public bool isLastLevel = false;

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			//changeLevel ();
			StartCoroutine("changeLevel");
		}
	}

	IEnumerator changeLevel() {
		/*//Vector3 amount = GameObject.FindWithTag ("Player").GetComponent<Rigidbody> ().velocity / 30;
		for (int i = 0; i < 20; i++) {
//			print (GameObject.FindWithTag ("Player").transform.GetChild (0).GetComponent<AudioSource> ().volume);
			GameObject.FindWithTag ("Player").transform.GetChild(0).GetComponent<AudioSource>().volume -= 1/4;
			if (GameObject.FindWithTag ("Player").transform.GetChild(0).GetComponent<AudioSource>().volume <= 0)
				break;
			
			yield return new WaitForSeconds (0.1f);
		}*/
		yield return null;

		if (!isLastLevel) {
			Time.timeScale = 1;
			if (SceneManager.GetActiveScene ().buildIndex < SceneManager.sceneCountInBuildSettings - 1) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
			} else {
				SceneManager.LoadScene (0);
			}
		} else {
			GameObject.Find ("LastLevel").GetComponent<Text> ().enabled = true;
			yield return new WaitForSeconds (8);
			GameObject.Find ("LastLevel").GetComponent<Text> ().enabled = false;

			RenderSettings.fogEndDistance = 200;
			yield return new WaitForSeconds (9.3f);
			SceneManager.LoadScene (0);
		}
	}
}
