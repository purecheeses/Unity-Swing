using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public GameObject targetNode;		//target node to get swing
	bool connectState = true;
    float speed = 10;
    RaycastHit2D[] ray;
    int hitNumber = 0;//检测返回与直线相交的物体数量//
    float minDistance = 3f;
	// Use this for initialization
	void Start () {
        resetVelocity(speed);
        ray = new RaycastHit2D[1];
        GetComponent<LineRenderer>().SetColors(Color.red, Color.yellow);
	}
	
	// Update is called once per frame
	void Update () {
		ClickEvent ();
        drawRope();
        makeRayCast();              //设置探测的辅助线
	}

    void drawRope() {
        if (GetComponent<DistanceJoint2D>())
        {
            DrawTool.DrawLine(transform, transform.position, GetComponent<DistanceJoint2D>().connectedBody.transform.position);
        }
    }

    void resetVelocity(float speed) { 
        Vector2 vec = gameObject.GetComponent<Rigidbody2D>().velocity.normalized;
        gameObject.GetComponent<Rigidbody2D>().velocity = vec * speed;
    }

	void ClickEvent()
    {
#if UNITY_STANDALONE_WIN ||UNITY_STANDALONE_OSX
        if (Input.GetMouseButtonDown(0))
        {
            operation();
        }
        if (Input.GetMouseButton(0)) {
            reduceRope();
        }

#endif       
#if UNITY_ANDROID ||UNITY_IPHONE
        if (Input.touchCount > 0&& Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            operation();
        }
#endif
    }

    void reduceRope() {
        if (!GetComponent<DistanceJoint2D>())
            return;

        float dist = GetComponent<DistanceJoint2D>().distance;
        float deltaDist = 0.05f;
        if (dist - deltaDist >= minDistance) {
            GetComponent<DistanceJoint2D>().distance -= deltaDist;
        }
    }

    void operation() {
        if (connectState)
        {
            connectState = !connectState;
            releaseRope();
        }
        else
        {
            connectState = !connectState;
            makeRope();
        }
        //releaseRope();
        //makeRope();
    }

	void releaseRope(){
		if (GetComponent<DistanceJoint2D> ()) {
			Destroy (GetComponent<DistanceJoint2D> ());
		}
	}

	void makeRope(){
        if (targetNode != null && targetNode.GetComponent<NodeController>().hasConnected == false) {
            DistanceJoint2D joint = gameObject.AddComponent<DistanceJoint2D>();
            joint.connectedBody = targetNode.GetComponent<Rigidbody2D>();
            targetNode.GetComponent<NodeController>().hasConnected = true;      //每个点只能连一次
        }


        //resetVelocity(speed);
	}
    //void OnTriggerEnter2D(Collider2D col){
    //    targetNode = col.gameObject;
    //}

    void makeRayCast() { 
        Vector2 pos1 = new Vector2(transform.position.x,transform.position.y);
        float length = 5f;
        Vector2 pos2 = new Vector2(pos1.x + length,pos1.y + length );
        hitNumber =  Physics2D.LinecastNonAlloc(pos1, pos2,ray, 1 << LayerMask.NameToLayer("Bombs"));
        Debug.DrawLine(pos1, pos2, Color.red, 0.1f);
        if (hitNumber>0) {
            targetNode = ray[0].transform.gameObject;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "terrain")
        {
            Debug.Log("lose");
            Application.LoadLevel("scene1");
        }
    }
}
