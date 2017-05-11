using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public GameObject targetNode;		//target node to get swing
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ClickEvent ();
	}

	void ClickEvent(){
		if (Input.GetMouseButtonDown(0)) {
			if (GetComponent<DistanceJoint2D> ()) {
				Destroy (GetComponent<DistanceJoint2D> ());
			}
			DistanceJoint2D joint = gameObject.AddComponent<DistanceJoint2D> ();
			joint.connectedBody = targetNode.GetComponent<Rigidbody2D> ();
			Debug.Log ("aaaa");
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		Debug.Log ("bbbb");
		targetNode = col.gameObject;
	}
}
