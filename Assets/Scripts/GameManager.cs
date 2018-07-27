using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject player;
	public GameObject start;
	public GameObject startWall;

	// Use this for initialization
	void Start () {
		Transform startposi = start.transform;
		Instantiate (player, startposi.position, Quaternion.identity);

		Invoke ("destroy", 10);
	}

	void destroy(){
		Destroy (startWall);
	}
}
