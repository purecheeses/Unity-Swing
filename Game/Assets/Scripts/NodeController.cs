using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour {
    float circleRadius;
    public bool hasConnected;       //是否已经被连过SS
	// Use this for initialization
	void Start () {
        hasConnected = false;
//        circleRadius = GetComponent<CircleCollider2D>().radius * transform.localScale.x;
		circleRadius = 10f;
	}
	
	// Update is called once per frame
	void Update () {
        DrawTool.DrawCircle(transform, transform.localPosition, circleRadius); 
		DrawTool.DrawCircleSolid(transform, transform.position, circleRadius); 
	}
        
}
