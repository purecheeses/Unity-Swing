using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenControl : MonoBehaviour {
    float maxDist;
    public GameObject tail;
	// Use this for initialization
	void Start () {
        maxDist = 10f;
        GetComponent<DistanceJoint2D>().autoConfigureDistance = false;
        tail.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
	}
	
	// Update is called once per frame
	void Update () {
        open();
	}

    void open() {
        float distance = GetComponent<DistanceJoint2D>().distance;
        if (distance + 0.2 <= maxDist) {
            GetComponent<DistanceJoint2D>().distance += 0.5f;
        }
    }
}
