using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public GameObject targetNode;		//target node to get swing
	bool connectState = true;
    float speed = 10;
	// Use this for initialization
	void Start () {
        resetVelocity(speed);
	}
	
	// Update is called once per frame
	void Update () {
		ClickEvent ();
        DrawTool.DrawLine(transform, transform.position, GetComponent<DistanceJoint2D>().connectedBody.transform.position);
	}

    void resetVelocity(float speed) { 
        Vector2 vec = gameObject.GetComponent<Rigidbody2D>().velocity.normalized;
        gameObject.GetComponent<Rigidbody2D>().velocity = vec * speed;
    }

	void ClickEvent(){
		if (Input.GetMouseButtonDown(0)) {
            //if (connectState)
            //{
            //    connectState = !connectState;
            //    releaseRope();
            //}
            //else
            //{
            //    connectState = !connectState;
            //    makeRope();
            //}
            releaseRope();
            makeRope();
		}
	}

	void releaseRope(){
		if (GetComponent<DistanceJoint2D> ()) {
			Destroy (GetComponent<DistanceJoint2D> ());
		}
	}

	void makeRope(){
		DistanceJoint2D joint = gameObject.AddComponent<DistanceJoint2D> ();
		joint.connectedBody = targetNode.GetComponent<Rigidbody2D> ();
        //resetVelocity(speed);
	}
	void OnTriggerEnter2D(Collider2D col){
		targetNode = col.gameObject;
	}
}
