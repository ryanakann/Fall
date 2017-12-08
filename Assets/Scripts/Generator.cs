using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour {

	public Rect playArea;
    public float refreshHeight = 10f;
    public float obstacleDensity = 4f;

	public Text scoreText;
	public GameObject obstacle1;

	private List<GameObject> regionObjects;
	public GameObject player;

	private bool newRegion = false;

	private Vector3 offset;
	private Vector3 startPos;

	// Use this for initialization
	void Start () {
		offset = new Vector3 (10f, 0f, 10f);
		startPos = transform.position;
        GenerateObstacles(player.transform.position.y - refreshHeight / 10);
    }
	
	// Update is called once per frame
	void Update () {
		scoreText.text = (((int)(startPos.y-player.transform.position.y) / 10) + 7).ToString();

        if ((int)Mathf.Abs(player.transform.position.y) % (int)refreshHeight < (int)(refreshHeight /10)) {
			if (newRegion == false) {
                //print ("New Region!");
                
                GenerateObstacles(player.transform.position.y - refreshHeight);
                newRegion = true;
            }
		}
        else
        {
			newRegion = false;
		}

/*		if (player.transform.position.y > -refreshHeight + 100f) {
			player.transform.position = new Vector3 (player.transform.position.x, -refreshHeight + 100f, player.transform.position.z);
		} */
	}

	void GenerateObstacles (float currentHeight) {
		regionObjects = new List<GameObject> (0);

		for (int i = 0; i < (int)(obstacleDensity/2*refreshHeight); i++) {
			bool unique = true;
			int loopCounter = 0;
			Vector3 randomPos = Vector3.zero;
			do {
				unique = true;
				randomPos = new Vector3(Random.Range(playArea.xMin, playArea.xMax), Random.Range(currentHeight - refreshHeight, currentHeight), Random.Range(playArea.yMin, playArea.yMax));
				foreach (var item in regionObjects) {
					if ((randomPos-item.transform.position).magnitude <= 5) {
						unique = false;
					}
				}
				loopCounter++;
			} while (!unique && loopCounter <= 300);

			GameObject newObj = Instantiate (obstacle1, randomPos - offset, Quaternion.identity) as GameObject; 
			regionObjects.Add (newObj);
			//newObj.transform.localScale *= (1 / 100);
		}
	}
}
