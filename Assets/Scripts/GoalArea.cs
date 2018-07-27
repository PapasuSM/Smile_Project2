using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalArea : MonoBehaviour {

	public static bool goal;

	// Use this for initialization
	void Start () {
		goal = false;		
	}
	
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player"){
			goal = true;
			//print ("Player Goal!!");
		}
	}
}
