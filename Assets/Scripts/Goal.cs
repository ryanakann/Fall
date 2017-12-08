using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Goal : MonoBehaviour {

	public bool isLastLevel = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			//changeLevel ();
			StartCoroutine("changeLevel");
		}
	}

	/*void changeLevel(){
		if (SceneManager.GetActiveScene ().buildIndex < SceneManager.sceneCountInBuildSettings - 1) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		} else {
			SceneManager.LoadScene (0);
		}
	}*/

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
