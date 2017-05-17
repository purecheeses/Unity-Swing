using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseControl : MonoBehaviour {
	float maxDist;
	float minAngle;
	float time;
	float deltaDist;
	float deltaAngle;
	public GameObject button2;
	public GameObject button1;
	public GameObject head;
	// Use this for initialization
	void Start () {
		maxDist = 10f;
		minAngle = 0;
		time  = 4f;
		deltaDist = (maxDist - button2.GetComponent<DistanceJoint2D> ().distance) / time/60f;
		deltaAngle = (button2.GetComponent<SliderJoint2D> ().angle - minAngle) / time/60f;
		button2.GetComponent<DistanceJoint2D>().autoConfigureDistance = false;
		button2.GetComponent<SliderJoint2D> ().autoConfigureAngle = false;
		GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
	}

	// Update is called once per frame
	void Update () {
		//        open();
	}

	void FixedUpdate(){
		close ();
	}

	void close() {
		float distance = button2.GetComponent<DistanceJoint2D>().distance;
		float angle = button2.GetComponent<SliderJoint2D> ().angle;
		if (distance +deltaDist <= maxDist) {
			button2.GetComponent<DistanceJoint2D> ().distance += deltaDist;
		} else {
			button2.GetComponent<DistanceJoint2D> ().enabled = false;
			if (button2.GetComponent<FixedJoint2D> () == null) {
				button2.AddComponent<FixedJoint2D> ();
				button2.GetComponent<FixedJoint2D> ().connectedBody = button1.GetComponent<Rigidbody2D> ();
			}
		}
		if (angle - deltaAngle >= minAngle) {
			button2.GetComponent<SliderJoint2D> ().angle -= deltaAngle;
			head.transform.rotation = Quaternion.Euler (0, 0, 0);
		} else {
			button2.GetComponent<SliderJoint2D> ().enabled = false;
		}
	}
}
