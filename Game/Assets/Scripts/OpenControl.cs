using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenControl : MonoBehaviour {
    float maxDist;
	float minAngle;
	float time;
	float deltaDist;
	float deltaAngle;
	float currentDist;
	float currentAngle;
    public GameObject button2;
	public GameObject button1;
	public GameObject head;
	bool openning;
	Vector3 beginVec3;
	// Use this for initialization
	void Start () {
		init ();
	}

	void init(){
		maxDist = 7f;
		minAngle = 00;
		time  = 1f;
		float beginDist = Vector2.Distance (button1.transform.position, button2.transform.position);
		currentDist = beginDist;
		currentAngle = 90;
		deltaDist = (maxDist - beginDist) / time/60f;
		deltaAngle = (90f - minAngle) / time/60f;
		openning = false;
//		beginVec3 = 
		onOpenBegin ();
	}

	void FixedUpdate(){
		if (openning) {
			open ();
		}
	}

    void open() {
		if (currentAngle - deltaAngle > minAngle) {
			currentAngle -= deltaAngle;
		} else {
			currentAngle = minAngle;
			onOpenDone ();
		}
		if (currentDist + deltaDist < maxDist) {
			currentDist += deltaDist;
		} else {
			currentDist = maxDist;
			onOpenDone ();
		}

		head.transform.position = transform.position + Quaternion.AngleAxis (currentAngle, Vector3.forward) * Vector3.right * currentDist;
    }

	void onOpenBegin(){
		openning = true;
		head.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Static;
		head.GetComponent<Animator> ().Play ("headOpen");
		GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Static;
		GetComponent<Animator>().Play ("tailOpen");
	}

	void onOpenDone(){
		openning = false;
		head.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
		GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
		head.GetComponent<CrossControl> ().onCrossBegin ();
	}
}
