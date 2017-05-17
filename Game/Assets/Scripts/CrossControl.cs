using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossControl : MonoBehaviour {
	float time;
	float deltaDist;
	float deltaAngle;
	float currentDist;
	float currentAngle;

	public GameObject button2;
	public GameObject button1;
	public GameObject tail;
	bool crossing;
	// Use this for initialization
	void Start () {
		init ();
	}

	void init(){
		time = 1;
		float beginDist = Vector2.Distance (button1.transform.position, button2.transform.position);
		currentDist = beginDist;
		currentAngle = 180f;
		deltaAngle = 180f / time/60f;
		crossing = false;
	}

	void FixedUpdate(){
		if (crossing) {
			cross ();
		}
	}

	void cross() {
		if (currentAngle - deltaAngle > 0) {
			currentAngle -= deltaAngle;
		} else {
			currentAngle = 0;
			onCrossDone ();
		}
		tail.transform.position = transform.position + Quaternion.AngleAxis (currentAngle, Vector3.forward) * Vector3.right * currentDist;
	}

	public void onCrossBegin(){
		init ();
		crossing = true;
		tail.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Static;
		GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Static;
	}

	void onCrossDone(){
		crossing = false;
		tail.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
		GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
		tail.GetComponent<CloseControl> ().onCloseBegin ();
	}
		
}
