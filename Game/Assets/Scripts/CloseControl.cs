using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseControl : MonoBehaviour {
	float minDist;
	float minAngle;
	float time;
	float deltaDist;
	float deltaAngle;
	float currentDist;
	float currentAngle;
	public GameObject button2;
	public GameObject button1;
	public GameObject head;
	bool isClosing ;
	// Use this for initialization
	void Start () {
		init ();
	}

	void init(){
		isClosing = false;
		minAngle = 90;
		minDist = 2;
		time  = 2f;
		float beginDist = Vector2.Distance (button1.transform.position, button2.transform.position);
		Debug.Log (beginDist);
		currentDist = beginDist;
		currentAngle = 180;
		deltaDist = ( beginDist - minDist) / time/60f;
		deltaAngle = (180f - minAngle) / time/60f;
		isClosing = false;
	}
		
	void FixedUpdate(){
		if (isClosing) {
			close ();
		}
	}

	void close() {
		if (currentAngle - deltaAngle > minAngle) {
			currentAngle -= deltaAngle;
		} else {
			currentAngle = minAngle;
			onCloseDone ();
		}
		if (currentDist - deltaDist > minDist) {
			currentDist -= deltaDist;
		} else {
			currentDist = minDist;
			onCloseDone ();
		}

		head.transform.position = transform.position + Quaternion.AngleAxis (currentAngle, Vector3.forward) * Vector3.right * currentDist;
	}

	public void onCloseBegin(){
		init ();
		isClosing = true;
		head.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Static;
		GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Static;
		head.GetComponent<Animator> ().Play ("headClose");
		GetComponent<Animator>().Play ("tailClose");
	}

	void onCloseDone(){
		isClosing = false;
		head.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
		GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
	}
}
