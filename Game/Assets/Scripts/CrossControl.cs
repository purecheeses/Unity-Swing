using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossControl : MonoBehaviour {
	public GameObject tail;
	public GameObject button1;
	public GameObject button2;
	public bool crossing;
	// Use this for initialization
	void Start () {
		crossing = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (crossing) {
			Cross ();
		}
	}

	void Cross(){
		
	}
}
