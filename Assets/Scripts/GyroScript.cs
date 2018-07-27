using UnityEngine;
using System.Collections;

public class GyroScript : MonoBehaviour {

	Quaternion currentGyro;
	public GameObject player;
	public GameObject timer;

	public float speedX;
	public float speedZ;

	public float xLowerLimit = -0.20f;
	public float xUpperLimit = 0.20f;
	public float yLowerLimit = -0.20f;
	public float yUpperLimit = 0.20f;
	public float zLowerLimit = -0.20f;
	public float zUpperLimit = 0.20f;

	BoxCollider playerBoxCollider;
	SphereCollider playerSphereCollider;
 

	void Start(){
		Input.gyro.enabled = true;
		playerBoxCollider = player.GetComponent<BoxCollider>();
		playerSphereCollider = player.GetComponent<SphereCollider>();
	}

	void Update () {
		playerBoxCollider.enabled = true;
		playerSphereCollider.enabled = true;

		currentGyro = Input.gyro.attitude;
		this.transform.localRotation = 
			Quaternion.Euler(90, 90, 0) * ( new Quaternion (-currentGyro.x, -currentGyro.y, currentGyro.z, currentGyro.w)); 
		float rX = this.transform.localRotation.x;
		float rY = this.transform.localRotation.y;
		float rZ = this.transform.localRotation.z;

		if(Time.time >= 10f){
		if (rX <= xUpperLimit && rX >= xLowerLimit){
				MoveToUp1 (0.4f);
			if (rY <= yUpperLimit && rY >= yLowerLimit) {
				MoveToUp1 (0.2f);
				//if(Time.time >= 10f){
					if (rZ >= zUpperLimit) {
						playerBoxCollider.enabled = false;
						playerSphereCollider.enabled = false;
						MoveToRight();
					}
					if (rZ <= -(zUpperLimit)) {
						playerBoxCollider.enabled = false;
						playerSphereCollider.enabled = false;
						MoveToLeft();
					}
					if (rX <= xUpperLimit /10 && rX >= xLowerLimit/10) {
						MoveToUp1 (0.4f);
						print ("Max Z!!!!!");
						if (rY <= yUpperLimit/10 && rY >= yLowerLimit/10) {
							MoveToUp1 (0.2f);
							print ("Max Y!!!!!");
						}
					}
				}
			}
		}
	}
	/* 0.2秒間隔で呼び出される？？？？だとしたら0.2秒は長くないか？？Update関数内でdeltaTimeを使って
	 コントロールするべき？？？？？？？？？？？？？？*/
	void fixedUpdate(){
	}

	void MoveToUp1(float z){
		player.transform.Translate (0, 0, z * speedZ);
	}

	void MoveToUp2(){
		player.GetComponent<Rigidbody>().AddForce(transform.forward * speedZ, ForceMode.Impulse);
	}

	void MoveToRight(){
		player.transform.Translate (1 * speedX, 0, 0);
	}
	void MoveToLeft(){
		print ("左へ曲がり餡巣");
		player.transform.Translate (-1 * speedX, 0, 0);
	}
}